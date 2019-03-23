using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Ude;

namespace AcTools.Core.Subtitles.SRT
{
    public class SrtFile
    {
        private String _Filename = String.Empty;

        public String Filename
        {
            get { return _Filename; }
        }

        private String _Charset = String.Empty;

        public String Charset
        {
            get { return _Charset; }
        }

        private float _Confidence = float.NaN;

        public float CharsetConfidence
        {
            get { return _Confidence; }
        }

        private List<String> _Warnings = new List<String>();

        public List<String> Warnings
        {
            get { return _Warnings; }
        }

        private List<SrtLine> _Lines;

        public List<SrtLine> Lines
        {
            get { return _Lines; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SrtFile()
        {

        }

        /// <summary>
        /// Instantiate an object and load an srt file
        /// </summary>
        /// <param name="fileName"></param>
        public SrtFile(String fileName)
        {
            Load(fileName);
        }

        /// <summary>
        /// Load Srt file
        /// </summary>
        /// <param name="fileName"></param>
        public void Load(String fileName)
        {
            //set the private filename
            _Filename = fileName;

            //first clear the contents and warnings
            _Lines = new List<SrtLine>();
            _Warnings = new List<string>();

            //collect the unused objects
            GC.Collect();

            //First check the encoding
            using (FileStream fs = File.OpenRead(_Filename))
            {
                ICharsetDetector cdet = new CharsetDetector();
                cdet.Feed(fs);
                cdet.DataEnd();
                if (cdet.Charset != null)
                {
                    Debug.WriteLine(String.Format("Charset: {0}, confidence: {1}", cdet.Charset, cdet.Confidence));
                    _Charset = cdet.Charset;
                    _Confidence = cdet.Confidence;
                }
                else
                {
                    throw new Exception("No charset could be detected!");
                }
            }

            // open the file with the determined encoding
            Encoding fileEncoding = Encoding.GetEncoding(_Charset);
            List<String> fileLines = new List<String>();
            using (StreamReader srtReader = new StreamReader(_Filename, fileEncoding))
            {
                //Read the file contents in a list of strings                
                while (!srtReader.EndOfStream)
                {
                    fileLines.Add(srtReader.ReadLine());
                }
            }

            Int32 dummyInt32 = 0;
            // 0 - No parsing
            // 1 - Parsed Number
            // 2 - Parsed Time
            // 3 - Parsed Text
            Int32 parsingState = 0;
            //Parse the data
            Boolean hasSubmittedNewLine = false;
            SrtLine myLine = new SrtLine();
            foreach (String line in fileLines)
            {
                switch (parsingState)
                {
                    case 0:
                        // we expect number
                        if (String.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }
                        if(Int32.TryParse(line.Trim(), out dummyInt32))
                        {
                            myLine.Number = dummyInt32;
                            hasSubmittedNewLine = false;
                            parsingState = 1;
                        }
                        break;
                    case 1:
                        // we expect time
                        if (String.IsNullOrWhiteSpace(line) || !line.Contains("-->"))
                        {
                            // super error! set start and time to 0
                            _Warnings.Add(String.Format("Error parsing time: {0}", line));
                            myLine.StartTime = 0;
                            myLine.EndTime = 0;
                            hasSubmittedNewLine = false;
                            parsingState = 2;
                            continue;
                        }
                        else
                        {
                            string[] timeElements = line.Split(new String[] { "-->" }, StringSplitOptions.None);
                            if(timeElements.Length != 2)
                            {
                                // super error! set start and time to 0
                                _Warnings.Add(String.Format("Error parsing time: {0}", line));
                                myLine.StartTime = 0;
                                myLine.EndTime = 0;
                                hasSubmittedNewLine = false;
                                parsingState = 2;
                                continue;
                            }
                            myLine.StartTime = SrtLine.GetTimeInMsFromText(timeElements[0].Trim());
                            myLine.EndTime = SrtLine.GetTimeInMsFromText(timeElements[1].Trim());
                            hasSubmittedNewLine = false;
                            parsingState = 2;
                        }
                        break;
                    case 2:
                        // we expect text
                        if (String.IsNullOrWhiteSpace(line))
                        {
                            _Warnings.Add(String.Format("Empty text for line number: {0}", myLine.Number));
                            parsingState = 0;
                            _Lines.Add(myLine);
                            hasSubmittedNewLine = true;
                            myLine = new SrtLine();
                            continue;
                        }
                        else
                        {
                            myLine.Text= line.Trim();
                            hasSubmittedNewLine = false;
                            parsingState = 3;
                        }
                        break;
                    case 3:
                        // we expect text or empty line
                        if (String.IsNullOrWhiteSpace(line))
                        {
                            parsingState = 0;
                            _Lines.Add(myLine);
                            hasSubmittedNewLine = true;
                            myLine = new SrtLine();
                            continue;
                        }
                        else
                        {
                            myLine.Text = String.Format("\r\n{0}", line.Trim());
                            hasSubmittedNewLine = false;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (!hasSubmittedNewLine)
            {
                _Lines.Add(myLine);
            }
#if DEBUG
            if (_Warnings.Count > 0)
            {
                Debug.WriteLine("Warnings:");
                foreach (String s in _Warnings)
                {
                    Debug.WriteLine(s);
                }
            }
#endif
        }

        /// <summary>
        /// Reload an already loaded srt File
        /// </summary>
        public void ReLoad()
        {
            Load(_Filename);
        }

        /// <summary>
        /// Save Srt file in a specific filename
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs(String fileName)
        {
            Save(fileName);
        }

        /// <summary>
        /// Save Srt File
        /// </summary>
        public void Save()
        {
            Save(_Filename);
        }

        /// <summary>
        /// Save Srt File with a specific filename
        /// </summary>
        /// <param name="fileName"></param>
        private void Save(String fileName)
        {
            //All files are utf-8!
            StringBuilder fileBuilder = new StringBuilder();
            foreach (SrtLine line in _Lines)
            {
                fileBuilder.AppendLine(String.Format("{0}", line.Number));
                fileBuilder.AppendLine(String.Format("{0} --> {1}", SrtLine.GetTimeInTextFromMs(line.StartTime), SrtLine.GetTimeInTextFromMs(line.EndTime)));
                fileBuilder.AppendLine(line.Text);
                fileBuilder.AppendLine();
            }
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                sw.Write(fileBuilder.ToString());
            }
        }

    }
}
