using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using AcToolsLibrary.Core.Parsers;

namespace AcToolsLibrary.Core.Other
{
    public enum ChapterType
    {
        XML,
        OGM
    }

    public class ChapterEditor
    {
        List<VideoChapter> chapterList = new List<VideoChapter>();
        VideoFrameList vfl = null;

        public List<VideoChapter> ChapterList
        {
            get
            {
                return chapterList;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChapterEditor()
        {
        }

        public void AddChapter(VideoChapter chap)
        {
            chapterList.Add(chap);
        }

        public void RemoveChapter(VideoChapter chap)
        {
            chapterList.Remove(chap);
        }

        public void RemoveChapterAt(Int32 idx)
        {
            chapterList.RemoveAt(idx);
        }

        public void ClearChapters()
        {
            chapterList.Clear();
        }

        public void Save(ChapterType cType, String filename)
        {
            switch (cType)
            {
                case ChapterType.XML:
                    SaveXML(filename);
                    break;
                case ChapterType.OGM:
                    SaveOGM(filename);
                    break;
            }
        }

        private void SaveXML(String xmlFilename)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                doc.AppendChild(doc.CreateWhitespace("\r\n"));

                XmlComment cm = doc.CreateComment(" <!DOCTYPE Tags SYSTEM \"matroskatags.dtd\"> ");
                doc.AppendChild(cm);

                doc.AppendChild(doc.CreateWhitespace("\r\n"));

              //              <Chapters>
              //<EditionEntry>
              //  <EditionFlagHidden>0</EditionFlagHidden>
              //  <EditionFlagDefault>0</EditionFlagDefault>
              //  <EditionUID>2154599312</EditionUID>
                XmlNode chapNode = doc.CreateElement("Chapters");

                XmlNode editNode = doc.CreateElement("EditionEntry");
                XmlNode editValNode = doc.CreateElement("EditionFlagHidden");
                XmlNode editVal = doc.CreateTextNode("0");
                editValNode.AppendChild(editVal);
                editNode.AppendChild(editValNode);

                editValNode = doc.CreateElement("EditionFlagDefault");
                editVal = doc.CreateTextNode("0");
                editValNode.AppendChild(editVal);
                editNode.AppendChild(editValNode);

                editValNode = doc.CreateElement("EditionUID");
                Random rnd = new Random(DateTime.Now.Millisecond);
                editVal = doc.CreateTextNode(rnd.Next().ToString("0000000000"));
                editValNode.AppendChild(editVal);
                editNode.AppendChild(editValNode);

                foreach (VideoChapter chap in chapterList)
                {
                    editNode.AppendChild(chap.GetXmlDetails(doc));
                }

                chapNode.AppendChild(editNode);

                doc.AppendChild(chapNode);

                doc.Save(xmlFilename);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveOGM(String filename)
        {
            StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8);
            Int32 chapIdx = 1;
            foreach (VideoChapter chap in chapterList)
            {
                sw.WriteLine(chap.GetOgmDetails(chapIdx));
                chapIdx++;
            }
            sw.Close();
        }

        public void Load(ChapterType cType, String filename)
        {
            switch (cType)
            {
                case ChapterType.XML:
                    LoadXML(filename);
                    break;
                case ChapterType.OGM:
                    LoadOGM(filename);
                    break;
            }
        }

        private void LoadXML(String filename)
        {
            //Create the Xml Document
            XmlDocument doc = new XmlDocument();
            //Read the Xml file
            doc.Load(filename);

            //Clear the chapter list
            chapterList.Clear();

            XmlNodeList chapters = doc.GetElementsByTagName("ChapterAtom");
            foreach (XmlNode node in chapters)
            {
                //Create a new chapter object
                VideoChapter chap = new VideoChapter();
                //Get the values
                foreach (XmlNode cNode in node.ChildNodes)
                {
                    if (cNode.Name == "ChapterUID")
                    {
                        chap.UID = cNode.FirstChild.Value;
                    }
                    else if (cNode.Name == "ChapterFlagHidden")
                    {
                        chap.Hidden = cNode.FirstChild.Value == "1" ? true : false;
                    }
                    else if (cNode.Name == "ChapterFlagEnabled")
                    {
                        chap.Enabled = cNode.FirstChild.Value == "1" ? true : false;
                    }
                    else if (cNode.Name == "ChapterTimeStart")
                    {
                        chap.StartTime = cNode.FirstChild.Value;
                    }
                    else if (cNode.Name == "ChapterTimeEnd")
                    {
                        chap.EndTime = cNode.FirstChild.Value;
                    }
                    else if (cNode.Name == "ChapterDisplay")
                    {
                        VideoChapterDisplay chapDisp = new VideoChapterDisplay();
                        foreach (XmlNode dNode in cNode.ChildNodes)
                        {
                            if (dNode.Name == "ChapterString")
                            {
                                chapDisp.Name = dNode.FirstChild.Value;
                            }
                            else if (dNode.Name == "ChapterLanguage")
                            {
                                chapDisp.Language = dNode.FirstChild.Value;
                            }
                            else if (dNode.Name == "ChapterCountry")
                            {
                                chapDisp.Country = dNode.FirstChild.Value;
                            }
                        }
                        chap.DisplayList.Add(chapDisp);
                        chap.Name = chapDisp.Name;
                    }
                }
                //Add the chapter to the list
                chapterList.Add(chap);
            }
        }

        private void LoadOGM(String filename)
        {
            StreamReader sr = new StreamReader(filename);
            //Empty the chapter list
            chapterList.Clear();
            //Define a chapter object
            VideoChapter chap = null;
            while (!sr.EndOfStream)
            {
                String line = sr.ReadLine();
                if (line != String.Empty)
                {
                    if (line.Contains(":"))
                    {
                        chap = new VideoChapter();
                        String[] elements = line.Split(new String[] { "=" }, StringSplitOptions.None);
                        chap.StartTime = elements[1].Trim();
                    }
                    else
                    {
                        String[] elements = line.Split(new String[] { "=" }, StringSplitOptions.None);
                        chap.Name = elements[1].Trim();
                        chapterList.Add(chap);
                        chap = null;
                    }
                }
            }
            //Close the file
            sr.Close();
        }

        public void CreateFromSections(String sectionsFile, String chaptersFile, Decimal frameRate, Boolean useChapters, Boolean isTrimFile)
        {
            //clear chapters
            chapterList.Clear();

            //If use chapters, load chapter file
            if (useChapters)
            {
                if (AcHelper.GetFilename(chaptersFile, GetFileNameMode.ExtensionOnly, GetDirectoryNameMode.NoPath).ToLowerInvariant() == "xml")
                {
                    Load(ChapterType.XML, chaptersFile);
                }
                else if (AcHelper.GetFilename(chaptersFile, GetFileNameMode.ExtensionOnly, GetDirectoryNameMode.NoPath).ToLowerInvariant() == "txt")
                {
                    Load(ChapterType.OGM, chaptersFile);
                }
            }

            //Create a Videoframelist
            vfl = new VideoFrameList();

            //Load the sections file
            SectionParser.ParseSections(sectionsFile, vfl);

            //Sanity check
            if (useChapters &&  vfl.CountSections != chapterList.Count)
            {
                throw new AcException("Error creating chapters! Sections count is different from the chapters count!");
            }

            if (isTrimFile)
            {
                Int32 framesToDelete = 0;
                for (Int32 i = 0; i < vfl.CountSections; i++)
                {
                    //If no chapters are loaded
                    if (!useChapters)
                    {
                        //Create new empty chapter
                        VideoChapter chap = new VideoChapter();
                        chapterList.Add(chap);
                    }

                    if (i == 0)
                    {
                        Int32 start = 0;
                        Int32 end = vfl.FrameSections[i].FrameEnd;
                        framesToDelete = vfl.FrameSections[0].FrameStart;
                        end -= framesToDelete;
                        chapterList[i].StartTime = VideoFrame.FrameTimeFromFrameNumber(start, frameRate, FrameFromType.FromFrameRate);
                        chapterList[i].EndTime = VideoFrame.FrameTimeFromFrameNumber(Convert.ToDecimal(end) + 0.5m,
                            frameRate, FrameFromType.FromFrameRate);
                    }
                    else
                    {
                        Int32 start = vfl.FrameSections[i].FrameStart;
                        Int32 end = vfl.FrameSections[i].FrameEnd;
                        Int32 prevEnd = vfl.FrameSections[i - 1].FrameEnd;
                        framesToDelete += start - prevEnd - 1;
                        start -= framesToDelete;
                        end -= framesToDelete;
                        chapterList[i].StartTime = VideoFrame.FrameTimeFromFrameNumber(Convert.ToDecimal(start) + 0.5m,
                            frameRate, FrameFromType.FromFrameRate);
                        chapterList[i].EndTime = VideoFrame.FrameTimeFromFrameNumber(Convert.ToDecimal(end) + 0.5m,
                            frameRate, FrameFromType.FromFrameRate);
                    }
                }
            }
            else
            {
                for (Int32 i = 0; i < vfl.CountSections; i++)
                {
                    //If no chapters are loaded
                    if (!useChapters)
                    {
                        //Create new empty chapter
                        VideoChapter chap = new VideoChapter();
                        chapterList.Add(chap);
                    }

                    Int32 start = vfl.FrameSections[i].FrameStart;
                    Int32 end = vfl.FrameSections[i].FrameEnd;
                    chapterList[i].StartTime = VideoFrame.FrameTimeFromFrameNumber(Convert.ToDecimal(start) + 0.5m,
                        frameRate, FrameFromType.FromFrameRate);
                    chapterList[i].EndTime = VideoFrame.FrameTimeFromFrameNumber(Convert.ToDecimal(end) + 0.5m,
                        frameRate, FrameFromType.FromFrameRate);
                }
            }
        }
    }
}
