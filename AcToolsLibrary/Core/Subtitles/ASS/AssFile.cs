using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ude;
using System.Diagnostics;

namespace AcToolsLibrary.Core.Subtitles.ASS
{
    public class AssFile
    {
        private String _Filename = String.Empty;
        private String _Charset = String.Empty;
        private float _Confidence = float.NaN;
        private List<String> _Warnings = new List<String>();
        private AssSectionScriptInfo _SectionScriptInfo = new AssSectionScriptInfo();
        private AssSectionStyles _SectionStyles = new AssSectionStyles();
        private AssSectionEvents _SectionEvents = new AssSectionEvents();
        private AssSectionFonts _SectionFonts = new AssSectionFonts();
        private AssSectionGraphics _SectionGraphics = new AssSectionGraphics();

        public AssSectionScriptInfo SectionScriptInfo
        {
            get { return _SectionScriptInfo; }
        }

        public AssSectionStyles SectionStyles
        {
            get { return _SectionStyles; }
        }

        public AssSectionEvents SectionEvents
        {
            get { return _SectionEvents; }
        }

        public AssSectionFonts SectionFonts
        {
            get { return _SectionFonts; }
        }

        public AssSectionGraphics SectionGraphics
        {
            get { return _SectionGraphics; }
        }

        public String Filename
        {
            get { return _Filename; }
        }

        public String Charset
        {
            get { return _Charset; }
        }

        public float CharsetConfidence
        {
            get { return _Confidence; }
        }

        public List<String> Warnings
        {
            get { return _Warnings; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AssFile()
        {

        }

        /// <summary>
        /// Instantiate an object and load an ass file
        /// </summary>
        /// <param name="fileName"></param>
        public AssFile(String fileName)
        {
            Load(fileName);
        }

        /// <summary>
        /// Load Ass file
        /// </summary>
        /// <param name="fileName"></param>
        public void Load(String fileName)
        {
            //set the private filename
            _Filename = fileName;

            //first clear the contents and warnings
            _SectionScriptInfo = new AssSectionScriptInfo();
            _SectionStyles = new AssSectionStyles();
            _SectionEvents = new AssSectionEvents();
            _SectionFonts = new AssSectionFonts();
            _SectionGraphics = new AssSectionGraphics();
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
            using (StreamReader assReader = new StreamReader(_Filename, fileEncoding))
            {
                //Read the file contents in a list of strings                
                while (!assReader.EndOfStream)
                {
                    fileLines.Add(assReader.ReadLine());
                }
            }                

            //Parse the data
            //Load section Script Info
            loadSectionScriptInfo(fileLines);
            //Load section Styles
            loadSectionStyles(fileLines);
            //Load section Events
            loadSectionEvents(fileLines);
            //Load section Fonts
            loadSectionFonts(fileLines);
            //Load section Graphics
            loadSectionGraphics(fileLines);

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
        /// Reload an already loaded Ass File
        /// </summary>
        public void ReLoad()
        {
            Load(_Filename);
        }

        /// <summary>
        /// Save Ass file in a specific filename
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs(String fileName)
        {
            Save(fileName);
        }

        /// <summary>
        /// Save Ass File
        /// </summary>
        public void Save()
        {
            Save(_Filename);
        }

        /// <summary>
        /// Save Ass File with a specific filename
        /// </summary>
        /// <param name="fileName"></param>
        private void Save(String fileName)
        {
            //All files are utf-8!
            using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                //First write the section info section

                //Write the header
                sw.WriteLine(AssSectionScriptInfo.SECTION_HEADER);
                //Write the comments
                foreach (String cm in _SectionScriptInfo.Comments)
                {
                    sw.WriteLine(";" + cm);
                }
                //Write the title
                sw.WriteLine("Title: " + _SectionScriptInfo.Title);
                sw.WriteLine("Original Script: " + _SectionScriptInfo.OriginalScript);
                sw.WriteLine("Original Translation: " + _SectionScriptInfo.OriginalTranslation);
                sw.WriteLine("Original Editing: " + _SectionScriptInfo.OriginalEditing);
                sw.WriteLine("Original Timing: " + _SectionScriptInfo.OriginalTiming);
                sw.WriteLine("Synch Point: " + _SectionScriptInfo.SynchPoint);
                sw.WriteLine("Script Updated By: " + _SectionScriptInfo.ScriptUpdatedBy);
                sw.WriteLine("Update Details: " + _SectionScriptInfo.UpdateDetails);
                sw.WriteLine("ScriptType: " + _SectionScriptInfo.ScriptType);
                sw.WriteLine("Collisions: " + _SectionScriptInfo.Collisions);
                sw.WriteLine("PlayResY: " + _SectionScriptInfo.PlayResY);
                sw.WriteLine("PlayResX: " + _SectionScriptInfo.PlayResX);
                sw.WriteLine("PlayDepth: " + _SectionScriptInfo.PlayDepth);
                sw.WriteLine("Timer: " + _SectionScriptInfo.Timer);
                sw.WriteLine("WrapStyle: " + _SectionScriptInfo.WrapStyle);
                //Write all the unknown fields
                foreach (String tmp in _SectionScriptInfo.UnknownFields)
                {
                    sw.WriteLine(tmp);
                }

                sw.WriteLine();
                
                //Write the Styles Section
                sw.WriteLine(AssSectionStyles.SECTION_HEADER);
                //Write the styles dictionary
                StringBuilder stylesDic = new StringBuilder();
                foreach(String tmp in _SectionStyles.FieldDictionary.Keys)
                {
                    stylesDic.Append(tmp + ",");
                }
                stylesDic.Length -= 1;
                sw.WriteLine("Format: " + stylesDic.ToString());
                //Write the comments
                foreach (String tmp in _SectionStyles.Comments)
                {
                    sw.WriteLine(";" + tmp);
                }
                //Write the Styles
                foreach (AssLineStyle tmp in _SectionStyles.StyleLines)
                {
                    sw.WriteLine(tmp.RawData);
                }

                sw.WriteLine();

                //Write the events section
                sw.WriteLine(AssSectionEvents.SECTION_HEADER);
                //Write the dictionary
                StringBuilder eventsDic = new StringBuilder();
                foreach (String tmp in _SectionEvents.FieldDictionary.Keys)
                {
                    eventsDic.Append(tmp + ",");
                }
                eventsDic.Length -= 1;
                sw.WriteLine("Format: " + eventsDic.ToString());
                //Write the comments
                foreach (String tmp in _SectionEvents.Comments)
                {
                    sw.WriteLine(";" + tmp);
                }
                //Write the events
                foreach (AssLineEvent tmp in _SectionEvents.EventLines)
                {
                    sw.WriteLine(tmp.ToString());
                }

                sw.WriteLine();

            }
        }

        private void loadSectionScriptInfo(List<String> fileContents)
        {
            //Loop throught the lines to find the Script Info Section
            Int32 currentLine = 0;
            Boolean sectionFound = false;
            foreach (String fileLine in fileContents)
            {
                //check if first line
                if (currentLine == 0)
                {
                    //if first line is empty
                    if (fileLine.Trim() == String.Empty)
                    {
                        //Warning
                        _Warnings.Add("Section Script Info: First line of the file is empty! (Should be " + AssSectionScriptInfo.SECTION_HEADER + ")");
                        currentLine++;
                        continue;
                    }
                    //If it is the header
                    else if (fileLine.Trim() == AssSectionScriptInfo.SECTION_HEADER)
                    {
                        sectionFound = true;
                        currentLine++;
                        continue;
                    }
                    else
                    {
                        //Warning
                        _Warnings.Add("Section Script Info: First section of the file is not Script Info!");
                        currentLine++;
                        continue;
                    }
                }
                //check if section is found
                if (sectionFound)
                {
                    //Try to parse the line
                    if (fileLine.Trim() == String.Empty)
                    {
                        //Ignore empty line
                        continue;
                    }
                    else if (fileLine.Trim() == AssSectionEvents.SECTION_HEADER
                        || fileLine.Trim() == AssSectionStyles.SECTION_HEADER
                        || fileLine.Trim() == AssSectionFonts.SECTION_HEADER
                        || fileLine.Trim() == AssSectionGraphics.SECTION_HEADER)
                    {
                        //We have the start of another section
                        //so this one is over
                        break;
                    }
                    else if (fileLine.Trim().StartsWith(";") || fileLine.Trim().StartsWith("!"))
                    {
                        _SectionScriptInfo.Comments.Add(fileLine.Trim().Substring(1));
                    }
                    else if (fileLine.Trim().Contains("Title:"))
                    {
                        _SectionScriptInfo.Title = fileLine.Trim().Replace("Title:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Original Script:"))
                    {
                        _SectionScriptInfo.OriginalScript = fileLine.Trim().Replace("Original Script:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Original Translation:"))
                    {
                        _SectionScriptInfo.OriginalTranslation = fileLine.Trim().Replace("Original Translation:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Original Editing:"))
                    {
                        _SectionScriptInfo.OriginalEditing = fileLine.Trim().Replace("Original Editing:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Original Timing:"))
                    {
                        _SectionScriptInfo.OriginalTiming = fileLine.Trim().Replace("Original Timing:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Synch Point:"))
                    {
                        _SectionScriptInfo.SynchPoint = fileLine.Trim().Replace("Synch Point:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Script Updated By:"))
                    {
                        _SectionScriptInfo.ScriptUpdatedBy = fileLine.Trim().Replace("Script Updated By:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Update Details:"))
                    {
                        _SectionScriptInfo.UpdateDetails = fileLine.Trim().Replace("Update Details:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("ScriptType:")) //ASS Hack
                    {
                        _SectionScriptInfo.ScriptType = fileLine.Trim().Replace("ScriptType:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Script Type:")) //For Standard SSA
                    {
                        _SectionScriptInfo.ScriptType = fileLine.Trim().Replace("Script Type:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Collisions:"))
                    {
                        _SectionScriptInfo.Collisions = fileLine.Trim().Replace("Collisions:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("PlayResY:"))
                    {
                        _SectionScriptInfo.PlayResY = fileLine.Trim().Replace("PlayResY:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("PlayResX:"))
                    {
                        _SectionScriptInfo.PlayResX = fileLine.Trim().Replace("PlayResX:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("PlayDepth:"))
                    {
                        _SectionScriptInfo.PlayDepth = fileLine.Trim().Replace("PlayDepth:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Timer:"))
                    {
                        _SectionScriptInfo.Timer = fileLine.Trim().Replace("Timer:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("WrapStyle:"))
                    {
                        _SectionScriptInfo.WrapStyle = fileLine.Trim().Replace("WrapStyle:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Audio File:"))
                    {
                        _SectionScriptInfo.AudioFile = fileLine.Trim().Replace("Audio File:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Video File:"))
                    {
                        _SectionScriptInfo.VideoFile = fileLine.Trim().Replace("Video File:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Video Aspect Ratio:"))
                    {
                        _SectionScriptInfo.VideoAspectRatio = fileLine.Trim().Replace("Video Aspect Ratio:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Video Zoom:"))
                    {
                        _SectionScriptInfo.VideoZoom = fileLine.Trim().Replace("Video Zoom:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Audio URI:"))
                    {
                        _SectionScriptInfo.AudioURI = fileLine.Trim().Replace("Audio URI:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Video Position:"))
                    {
                        _SectionScriptInfo.VideoPosition = fileLine.Trim().Replace("Video Position:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("ScaledBorderAndShadow:"))
                    {
                        _SectionScriptInfo.ScaledBorderAndShadow = fileLine.Trim().Replace("ScaledBorderAndShadow:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Last Style Storage:"))
                    {
                        _SectionScriptInfo.LastStyleStorage = fileLine.Trim().Replace("Last Style Storage:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Title:"))
                    {
                        _SectionScriptInfo.Title = fileLine.Trim().Replace("Title:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Title:"))
                    {
                        _SectionScriptInfo.Title = fileLine.Trim().Replace("Title:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Title:"))
                    {
                        _SectionScriptInfo.Title = fileLine.Trim().Replace("Title:", "").Trim();
                    }
                    else if (fileLine.Trim().Contains("Title:"))
                    {
                        _SectionScriptInfo.Title = fileLine.Trim().Replace("Title:", "").Trim();
                    }
                    else
                    {
                        _SectionScriptInfo.UnknownFields.Add(fileLine);
                    }
                    currentLine++;
                    continue;
                }
                else
                {
                    //Check for section
                    if (fileLine.Trim() == AssSectionScriptInfo.SECTION_HEADER)
                    {
                        sectionFound = true;
                    }
                    currentLine++;
                    continue;
                }
            }
            //Check if section was found
            if (!sectionFound)
            {
                _Warnings.Add("Section Script Info: Section Script Info was not found!");
            }
        }

        private void loadSectionStyles(List<String> fileContents)
        {
            //Loop throught the lines to find the Styles Section
            Boolean sectionFound = false;
            foreach (String fileLine in fileContents)
            {
                //Check if section is found
                if (sectionFound)
                {
                    //Try to parse the lines
                    if (fileLine.Trim().StartsWith("Format:"))
                    {
                        //Found format style line, so we must build the dictionary
                        parseFormatStyleLine(fileLine);
                    }
                    else if (fileLine.Trim().StartsWith("Style:"))
                    {
                        //Add the style to the section
                        _SectionStyles.StyleLines.Add(parseStyleLine(fileLine));
                    }
                    else if (fileLine.Trim().StartsWith(";") || fileLine.Trim().StartsWith("!"))
                    {
                        //Comment line
                        _SectionStyles.Comments.Add(fileLine);
                    }
                    else if (fileLine.Trim() == String.Empty)
                    {
                        //Ignore empty line
                        continue;
                    }
                    else if (fileLine.Trim() == AssSectionEvents.SECTION_HEADER
                        || fileLine.Trim() == AssSectionScriptInfo.SECTION_HEADER
                        || fileLine.Trim() == AssSectionFonts.SECTION_HEADER
                        || fileLine.Trim() == AssSectionGraphics.SECTION_HEADER)
                    {
                        //We have the start of another section
                        //so this one is over
                        break;
                    }
                    else
                    {
                        //Unknown line for styles section
                        _Warnings.Add("Section Styles: Unknown line for styles section: " + fileLine);
                    }
                }
                else
                {
                    //Check to find the header
                    if (fileLine.Trim() == AssSectionStyles.SECTION_HEADER)
                    {
                        sectionFound = true;
                    }
                    else if (fileLine.Trim().StartsWith("Style:"))
                    {
                        //Found a style line out of section
                        //Add a warning
                        _Warnings.Add("Section Styles: Found a style line out of section: " + fileLine);
                        //Add the style to the section
                        _SectionStyles.StyleLines.Add(parseStyleLine(fileLine));
                    }
                }
            }
            if (!sectionFound)
            {
                _Warnings.Add("Section Styles: Section Styles was not found!");
            }
        }

        private AssLineStyle parseStyleLine(String fileLine)
        {
            //Found style line, so parse it
            //Get the field values
            String[] fields = fileLine.Trim().Replace("Style:", "").Split(new String[] { "," }, StringSplitOptions.None);
            //Create the new style line
            AssLineStyle style = new AssLineStyle();
            //Set the raw data
            style.RawData = fileLine;
            //Check if field dictionary is created
            if (_SectionStyles.FieldDictionary.Count == 0)
            {
                //if dictionary is not created, fallback to default
                _Warnings.Add("Section Styles: Falling back to the default dictionary for the Styles section");
                _SectionStyles.FallbackToDefaultDictionary();
            }
            //Check if the number of fields agree with the number of the format fields
            if (fields.Length == _SectionStyles.FieldDictionary.Count)
            {
                if (_SectionStyles.FieldDictionary.ContainsKey("Name"))
                {
                    style.Name = fields[_SectionStyles.FieldDictionary["Name"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Fontname"))
                {
                    style.Fontname = fields[_SectionStyles.FieldDictionary["Fontname"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Fontsize"))
                {
                    style.Fontsize = fields[_SectionStyles.FieldDictionary["Fontsize"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("PrimaryColour"))
                {
                    style.PrimaryColour = fields[_SectionStyles.FieldDictionary["PrimaryColour"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("SecondaryColour"))
                {
                    style.SecondaryColour = fields[_SectionStyles.FieldDictionary["SecondaryColour"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("OutlineColour"))
                {
                    style.OutlineColour = fields[_SectionStyles.FieldDictionary["OutlineColour"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("BackColour"))
                {
                    style.BackColour = fields[_SectionStyles.FieldDictionary["BackColour"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Bold"))
                {
                    style.Bold = fields[_SectionStyles.FieldDictionary["Bold"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Italic"))
                {
                    style.Italic = fields[_SectionStyles.FieldDictionary["Italic"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Underline"))
                {
                    style.Underline = fields[_SectionStyles.FieldDictionary["Underline"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("StrikeOut"))
                {
                    style.Strikeout = fields[_SectionStyles.FieldDictionary["StrikeOut"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("ScaleX"))
                {
                    style.ScaleX = fields[_SectionStyles.FieldDictionary["ScaleX"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("ScaleY"))
                {
                    style.ScaleY = fields[_SectionStyles.FieldDictionary["ScaleY"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Spacing"))
                {
                    style.Spacing = fields[_SectionStyles.FieldDictionary["Spacing"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Angle"))
                {
                    style.Angle = fields[_SectionStyles.FieldDictionary["Angle"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("BorderStyle"))
                {
                    style.BorderStyle = fields[_SectionStyles.FieldDictionary["BorderStyle"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Outline"))
                {
                    style.Outline = fields[_SectionStyles.FieldDictionary["Outline"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Shadow"))
                {
                    style.Shadow = fields[_SectionStyles.FieldDictionary["Shadow"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Alignment"))
                {
                    style.Alignment = fields[_SectionStyles.FieldDictionary["Alignment"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("MarginL"))
                {
                    style.MarginL = fields[_SectionStyles.FieldDictionary["MarginL"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("MarginR"))
                {
                    style.MarginR = fields[_SectionStyles.FieldDictionary["MarginR"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("MarginV"))
                {
                    style.MarginV = fields[_SectionStyles.FieldDictionary["MarginV"]];
                }
                if (_SectionStyles.FieldDictionary.ContainsKey("Encoding"))
                {
                    style.Encoding = fields[_SectionStyles.FieldDictionary["Encoding"]];
                }
            }
            else
            {
                _Warnings.Add("Section Styles: Wrong definition for the style!");
            }
            return style;
        }

        private void parseFormatStyleLine(String fileLine)
        {
            //Found format line, so we must build the dictionary
            //First clear it
            _SectionStyles.FieldDictionary.Clear();
            //Get the fields from the format line
            String[] fields = fileLine.Trim().Replace("Format:", "").Split(new String[] { "," }, StringSplitOptions.None);
            //Create the dictionary
            for (Int32 idx = 0; idx < fields.Length; idx++)
            {
                if (fields[idx].Trim().Contains("Name"))
                {
                    _SectionStyles.FieldDictionary.Add("Name", idx);
                }
                else if (fields[idx].Trim().Contains("Fontname"))
                {
                    _SectionStyles.FieldDictionary.Add("Fontname", idx);
                }
                else if (fields[idx].Trim().Contains("Fontsize"))
                {
                    _SectionStyles.FieldDictionary.Add("Fontsize", idx);
                }
                else if (fields[idx].Trim().Contains("PrimaryColour"))
                {
                    _SectionStyles.FieldDictionary.Add("PrimaryColour", idx);
                }
                else if (fields[idx].Trim().Contains("SecondaryColour"))
                {
                    _SectionStyles.FieldDictionary.Add("SecondaryColour", idx);
                }
                else if (fields[idx].Trim().Contains("OutlineColour"))
                {
                    _SectionStyles.FieldDictionary.Add("OutlineColour", idx);
                }
                else if (fields[idx].Trim().Contains("BackColour"))
                {
                    _SectionStyles.FieldDictionary.Add("BackColour", idx);
                }
                else if (fields[idx].Trim().Contains("Bold"))
                {
                    _SectionStyles.FieldDictionary.Add("Bold", idx);
                }
                else if (fields[idx].Trim().Contains("Italic"))
                {
                    _SectionStyles.FieldDictionary.Add("Italic", idx);
                }
                else if (fields[idx].Trim().Contains("Underline"))
                {
                    _SectionStyles.FieldDictionary.Add("Underline", idx);
                }
                else if (fields[idx].Trim().Contains("StrikeOut"))
                {
                    _SectionStyles.FieldDictionary.Add("StrikeOut", idx);
                }
                else if (fields[idx].Trim().Contains("ScaleX"))
                {
                    _SectionStyles.FieldDictionary.Add("ScaleX", idx);
                }
                else if (fields[idx].Trim().Contains("ScaleY"))
                {
                    _SectionStyles.FieldDictionary.Add("ScaleY", idx);
                }
                else if (fields[idx].Trim().Contains("Spacing"))
                {
                    _SectionStyles.FieldDictionary.Add("Spacing", idx);
                }
                else if (fields[idx].Trim().Contains("Angle"))
                {
                    _SectionStyles.FieldDictionary.Add("Angle", idx);
                }
                else if (fields[idx].Trim().Contains("BorderStyle"))
                {
                    _SectionStyles.FieldDictionary.Add("BorderStyle", idx);
                }
                else if (fields[idx].Trim().Contains("Outline"))
                {
                    _SectionStyles.FieldDictionary.Add("Outline", idx);
                }
                else if (fields[idx].Trim().Contains("Shadow"))
                {
                    _SectionStyles.FieldDictionary.Add("Shadow", idx);
                }
                else if (fields[idx].Trim().Contains("Alignment"))
                {
                    _SectionStyles.FieldDictionary.Add("Alignment", idx);
                }
                else if (fields[idx].Trim().Contains("MarginL"))
                {
                    _SectionStyles.FieldDictionary.Add("MarginL", idx);
                }
                else if (fields[idx].Trim().Contains("MarginR"))
                {
                    _SectionStyles.FieldDictionary.Add("MarginR", idx);
                }
                else if (fields[idx].Trim().Contains("MarginV"))
                {
                    _SectionStyles.FieldDictionary.Add("MarginV", idx);
                }
                else if (fields[idx].Trim().Contains("Encoding"))
                {
                    _SectionStyles.FieldDictionary.Add("Encoding", idx);
                }
                else
                {
                    _Warnings.Add("Section Styles: Found an unknown field in styles format: " + fields[idx].Trim());
                }
            }
            //Check if dictionary was filled
            if (_SectionStyles.FieldDictionary.Count == 0)
            {
                _Warnings.Add("Section Styles: Falling back to the default dictionary for the Styles section");
                //Fallback to default dictionary
                _SectionStyles.FallbackToDefaultDictionary();
            }
        }

        private void loadSectionEvents(List<String> fileContents)
        {
            //Loop throught the lines to find the Events Section
            Boolean sectionFound = false;
            Int32 lineOrder = 1;
            foreach (String fileLine in fileContents)
            {
                //Check if section is found
                if (sectionFound)
                {
                    if (fileLine.Trim().StartsWith("Format:"))
                    {
                        //Found format line, so we must build the dictionary
                        parseFormatEventLine(fileLine);
                    }
                    else if (fileLine.Trim().StartsWith("Dialogue:")
                                || fileLine.Trim().StartsWith("Comment:")
                                || fileLine.Trim().StartsWith("Picture:")
                                || fileLine.Trim().StartsWith("Sound:")
                                || fileLine.Trim().StartsWith("Movie:")
                                || fileLine.Trim().StartsWith("Command:"))
                    {
                        //Add the event to the section
                        _SectionEvents.EventLines.Add(parseEventLine(fileLine, lineOrder));
                        //Increase the line order
                        lineOrder++;
                    }
                    else if (fileLine.Trim().StartsWith(";") || fileLine.Trim().StartsWith("!"))
                    {
                        //Comment
                        _SectionEvents.Comments.Add(fileLine);
                    }
                    else if (fileLine.Trim() == String.Empty)
                    {
                        //Ignore empty line
                        continue;
                    }
                    else if (fileLine.Trim() == AssSectionScriptInfo.SECTION_HEADER
                          || fileLine.Trim() == AssSectionStyles.SECTION_HEADER
                          || fileLine.Trim() == AssSectionFonts.SECTION_HEADER
                          || fileLine.Trim() == AssSectionGraphics.SECTION_HEADER)
                    {
                        //We have the start of another section
                        //so this one is over
                        break;
                    }
                    else
                    {
                        _Warnings.Add("Section Events: Found unknown event line: " + fileLine);
                    }
                }
                else
                {
                    //Check to find the header
                    if (fileLine.Trim() == AssSectionEvents.SECTION_HEADER)
                    {
                        sectionFound = true;
                    }
                    else if (fileLine.Trim().StartsWith("Dialogue:")
                        || fileLine.Trim().StartsWith("Comment:")
                        || fileLine.Trim().StartsWith("Picture:")
                        || fileLine.Trim().StartsWith("Sound:")
                        || fileLine.Trim().StartsWith("Movie:")
                        || fileLine.Trim().StartsWith("Command:"))
                    {
                        //Found a main event line out of section
                        //Parse the line and Add the event to the section
                        _SectionEvents.EventLines.Add(parseEventLine(fileLine, lineOrder));
                        //Add a warning
                        _Warnings.Add("Section Events: Found a main event line (#" + lineOrder + ") out of the section!");
                        //Increase the line order
                        lineOrder++;
                    }
                }
            }
            if (!sectionFound)
            {
                _Warnings.Add("Section Events: Section Events was not found!");
            }
        }

        private AssLineEvent parseEventLine(String fileLine, Int32 lineOrder)
        {
            //Found event line, so parse it
            //Get the event type
            String eventType = fileLine.Trim().Substring(0, fileLine.Trim().IndexOf(":"));
            //Get the field values
            String[] fields = fileLine.Trim().Replace(eventType + ":", "").Split(new String[] { "," }, StringSplitOptions.None);
            //Create the new style line
            AssLineEvent eventLine = new AssLineEvent();
            //Set the type of the event
            switch (eventType)
            {
                case "Dialogue":
                    eventLine.EventType = AssEventTypes.Dialogue;
                    break;
                case "Comment":
                    eventLine.EventType = AssEventTypes.Comment;
                    break;
                case "Picture":
                    eventLine.EventType = AssEventTypes.Picture;
                    break;
                case "Sound":
                    eventLine.EventType = AssEventTypes.Sound;
                    break;
                case "Movie":
                    eventLine.EventType = AssEventTypes.Movie;
                    break;
                case "Command":
                    eventLine.EventType = AssEventTypes.Command;
                    break;
            }
            //Set the raw data
            eventLine.RawData = fileLine;
            //Set the original order
            eventLine.OriginalOrder = lineOrder;
            //Check if format dictionary is created
            if (_SectionEvents.FieldDictionary.Count == 0)
            {
                //If format dictionary is empty, fallback to default
                _Warnings.Add("Section Events: Falling back to the default dictionary for the Events section");
                _SectionEvents.FallbackToDefaultDictionary();
            }
            //Check if the number of fields agree with the number of the format fields
            if (fields.Length >= _SectionEvents.FieldDictionary.Count)
            {
                if (_SectionEvents.FieldDictionary.ContainsKey("Marked"))
                {
                    eventLine.Marked = fields[_SectionEvents.FieldDictionary["Marked"]];
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("Layer"))
                {
                    eventLine.Layer = fields[_SectionEvents.FieldDictionary["Layer"]].Trim();
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("Start"))
                {
                    eventLine.Start = fields[_SectionEvents.FieldDictionary["Start"]];
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("End"))
                {
                    eventLine.End = fields[_SectionEvents.FieldDictionary["End"]];
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("Style"))
                {
                    eventLine.Style = fields[_SectionEvents.FieldDictionary["Style"]];
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("Name"))
                {
                    eventLine.Name = fields[_SectionEvents.FieldDictionary["Name"]];
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("MarginL"))
                {
                    eventLine.MarginL = fields[_SectionEvents.FieldDictionary["MarginL"]];
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("MarginR"))
                {
                    eventLine.MarginR = fields[_SectionEvents.FieldDictionary["MarginR"]];
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("MarginV"))
                {
                    eventLine.MarginV = fields[_SectionEvents.FieldDictionary["MarginV"]];
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("Effect"))
                {
                    eventLine.Effect = fields[_SectionEvents.FieldDictionary["Effect"]];
                }
                if (_SectionEvents.FieldDictionary.ContainsKey("Text"))
                {
                    //The text can contain a comma, so we must merge the last fields
                    StringBuilder textBuilder = new StringBuilder();
                    for (Int32 j = _SectionEvents.FieldDictionary["Text"]; j < fields.Length; j++)
                    {
                        textBuilder.Append(fields[j]);
                        textBuilder.Append(",");
                    }
                    textBuilder.Length -= 1;
                    eventLine.Text = textBuilder.ToString();
                }
            }
            else
            {
                _Warnings.Add("Section Events: Wrong definition for the event!");
            }
            return eventLine;
        }

        private void parseFormatEventLine(String fileLine)
        {
            //First clear it
            _SectionEvents.FieldDictionary.Clear();
            //Get the fields from the format line
            String[] fields = fileLine.Trim().Replace("Format:", "").Split(new String[] { "," }, StringSplitOptions.None);
            //Create the dictionary
            for (Int32 idx = 0; idx < fields.Length; idx++)
            {
                if (fields[idx].Trim().Contains("Marked"))
                {
                    _SectionEvents.FieldDictionary.Add("Marked", idx);
                }
                else if (fields[idx].Trim().Contains("Layer"))
                {
                    _SectionEvents.FieldDictionary.Add("Layer", idx);
                }
                else if (fields[idx].Trim().Contains("Start"))
                {
                    _SectionEvents.FieldDictionary.Add("Start", idx);
                }
                else if (fields[idx].Trim().Contains("End"))
                {
                    _SectionEvents.FieldDictionary.Add("End", idx);
                }
                else if (fields[idx].Trim().Contains("Style"))
                {
                    _SectionEvents.FieldDictionary.Add("Style", idx);
                }
                else if (fields[idx].Trim().Contains("Name"))
                {
                    _SectionEvents.FieldDictionary.Add("Name", idx);
                }
                else if (fields[idx].Trim().Contains("MarginL"))
                {
                    _SectionEvents.FieldDictionary.Add("MarginL", idx);
                }
                else if (fields[idx].Trim().Contains("MarginR"))
                {
                    _SectionEvents.FieldDictionary.Add("MarginR", idx);
                }
                else if (fields[idx].Trim().Contains("MarginV"))
                {
                    _SectionEvents.FieldDictionary.Add("MarginV", idx);
                }
                else if (fields[idx].Trim().Contains("Effect"))
                {
                    _SectionEvents.FieldDictionary.Add("Effect", idx);
                }
                else if (fields[idx].Trim().Contains("Text"))
                {
                    _SectionEvents.FieldDictionary.Add("Text", idx);
                }
                else
                {
                    _Warnings.Add("Section Events: Found an unknown field in events format: " + fields[idx].Trim());
                }
            }
            //Check if dictionary was filled
            if (_SectionEvents.FieldDictionary.Count == 0)
            {
                _Warnings.Add("Section Events: Falling back to the default dictionary for the Events section");
                //Fallback to default dictionary
                _SectionEvents.FallbackToDefaultDictionary();
            }
        }

        private void loadSectionFonts(List<String> fileContents)
        {
            //Loop throught the lines to find the Fonts Section
            Boolean sectionFound = false;
            Boolean fontFound = false;
            AssLineFont fontLine = null;
            foreach (String fileLine in fileContents)
            {
                //Check if section is found
                if (sectionFound)
                {
                    //Check if we found font
                    if (fontFound)
                    {
                        //check for font file name line
                        if (fileLine.Trim().StartsWith("fontname:"))
                        {
                            //That means that we have another font
                            //so add the previous font to the section
                            _SectionFonts.FontLines.Add(fontLine);
                            //Create a new font line
                            fontLine = new AssLineFont();
                            fontLine.FontFileName = fileLine.Trim().Replace("fontname:", "").Trim();
                            continue;
                        }
                        else if (fileLine.Trim() == String.Empty)
                        {
                            //Ignore empty line
                            continue;
                        }
                        else if (fileLine.Trim() == AssSectionEvents.SECTION_HEADER
                                || fileLine.Trim() == AssSectionStyles.SECTION_HEADER
                                || fileLine.Trim() == AssSectionScriptInfo.SECTION_HEADER
                                || fileLine.Trim() == AssSectionGraphics.SECTION_HEADER)
                        {
                            //We have the start of another section
                            //so this one is over
                            break;
                        }
                        else
                        {
                            //Add the data to the font line
                            fontLine.EncodedData += fileLine;
                            continue;
                        }
                    }
                    else
                    {
                        //check for font file name line
                        if (fileLine.Trim().StartsWith("fontname:"))
                        {
                            //Found a font filename line
                            fontFound = true;
                            fontLine = new AssLineFont();
                            fontLine.FontFileName = fileLine.Trim().Replace("fontname:", "").Trim();
                            continue;
                        }
                        else if (fileLine.Trim() == String.Empty)
                        {
                            //Ignore empty line
                            continue;
                        }
                        else if (fileLine.Trim() == AssSectionEvents.SECTION_HEADER
                                || fileLine.Trim() == AssSectionStyles.SECTION_HEADER
                                || fileLine.Trim() == AssSectionScriptInfo.SECTION_HEADER
                                || fileLine.Trim() == AssSectionGraphics.SECTION_HEADER)
                        {
                            //We have the start of another section
                            //so this one is over
                            break;
                        }
                        else
                        {
                            _Warnings.Add("Section Fonts: Found line with unknown data for fonts section: " + fileLine);
                        }
                    }
                }
                else
                {
                    //Check for section
                    if (fileLine.Trim() == AssSectionFonts.SECTION_HEADER)
                    {
                        sectionFound = true;
                    }
                    continue;
                }
            }
        }

        private void loadSectionGraphics(List<String> fileContents)
        {
            //Loop throught the lines to find the Graphics Section
            Boolean sectionFound = false;
            Boolean graphicFound = false;
            AssLineGraphic graphicLine = null;
            foreach (String fileLine in fileContents)
            {
                //Check if section is found
                if (sectionFound)
                {
                    //Check if graphic was found
                    if (graphicFound)
                    {
                        //check for graphic file name line
                        if (fileLine.Trim().StartsWith("filename:"))
                        {
                            //That means that we have another graphic
                            //so add the previous graphic to the section
                            _SectionGraphics.GraphicLines.Add(graphicLine);
                            //Create a new graphic line
                            graphicLine = new AssLineGraphic();
                            graphicLine.GraphicFileName = fileLine.Trim().Replace("filename:", "").Trim();
                            continue;
                        }
                        else if (fileLine.Trim() == String.Empty)
                        {
                            //Ignore empty line
                            continue;
                        }
                        else if (fileLine.Trim() == AssSectionEvents.SECTION_HEADER
                            || fileLine.Trim() == AssSectionStyles.SECTION_HEADER
                            || fileLine.Trim() == AssSectionFonts.SECTION_HEADER
                            || fileLine.Trim() == AssSectionScriptInfo.SECTION_HEADER)
                        {
                            //We have the start of another section
                            //so this one is over
                            break;
                        }                        
                        else
                        {
                            //Add the data to the graphic line
                            graphicLine.EncodedData += fileLine;
                            continue;
                        }
                    }
                    else
                    {
                        //check for graphic file name line
                        if (fileLine.Trim().StartsWith("filename:"))
                        {
                            //Found a graphic filename line
                            graphicFound = true;
                            graphicLine = new AssLineGraphic();
                            graphicLine.GraphicFileName = fileLine.Trim().Replace("filename:", "").Trim();
                            continue;
                        }
                        else if (fileLine.Trim() == String.Empty)
                        {
                            //Ignore empty line
                            continue;
                        }
                        else if (fileLine.Trim() == AssSectionEvents.SECTION_HEADER
                            || fileLine.Trim() == AssSectionStyles.SECTION_HEADER
                            || fileLine.Trim() == AssSectionFonts.SECTION_HEADER
                            || fileLine.Trim() == AssSectionScriptInfo.SECTION_HEADER)
                        {
                            //We have the start of another section
                            //so this one is over
                            break;
                        }
                        else
                        {
                            _Warnings.Add("Section Graphics: Found line with unknown data for graphics section: " + fileLine);
                        }
                    }
                }
                else
                {
                    //Check for section
                    if (fileLine.Trim() == AssSectionGraphics.SECTION_HEADER)
                    {
                        sectionFound = true;
                    }
                    continue;
                }
            }
        }
    }
}
