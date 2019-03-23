using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AcToolsLibrary.Core.Parsers
{
    public class AssDialogue
    {
        public String part0;
        public String time_start;
        public Decimal time_start_double;
        public String time_end;
        public Decimal time_end_double;
        public String style;
        public String part4;
        public String part5;
        public String part6;
        public String part7;
        public String part8;
        public String subtitle;
        public Boolean deleted = false;

        public override string ToString()
        {
            String tmp = part0 + "," + time_start + "," + time_end + "," + style + ",";
            tmp += part4 + "," + part5 + "," + part6 + "," + part7 + "," + part8 + "," + subtitle;
            return tmp;
        }
    }

    public class AssParser
    {
        public String AssHeader;
        public List<AssDialogue> AssContents = new List<AssDialogue>();

        public void ParseASS(String file_name)
        {
            StreamReader reader = new StreamReader(file_name, Encoding.UTF8);
            String cur_line = "";
            Boolean dialogue_found = false;
            while ((cur_line = reader.ReadLine()) != null)
            {
                if (cur_line.StartsWith("Dialogue:") || cur_line.StartsWith("Comment:"))
                {
                    if (!dialogue_found)
                    {
                        dialogue_found = true;
                    }
                    AssDialogue tmp_ass = new AssDialogue();
                    String[] tmp_str = cur_line.Split(new String[] { "," }, StringSplitOptions.None);
                    tmp_ass.part0 = tmp_str[0];
                    tmp_ass.time_start = tmp_str[1];
                    tmp_ass.time_start_double = getTimeFromString(tmp_str[1]);
                    tmp_ass.time_end = tmp_str[2];
                    tmp_ass.time_end_double = getTimeFromString(tmp_str[2]);
                    tmp_ass.style = tmp_str[3];
                    tmp_ass.part4 = tmp_str[4];
                    tmp_ass.part5 = tmp_str[5];
                    tmp_ass.part6 = tmp_str[6];
                    tmp_ass.part7 = tmp_str[7];
                    tmp_ass.part8 = tmp_str[8];
                    String tmp_sub = "";
                    if (tmp_str.Length > 10)
                    {
                        for (int i = 0; i < tmp_str.Length - 9; i++)
                        {
                            tmp_sub += tmp_str[9 + i] + ",";
                        }
                        tmp_sub = tmp_sub.Substring(0, tmp_sub.Length - 1);
                    }
                    else
                    {
                        tmp_sub = tmp_str[9];
                    }
                    tmp_ass.subtitle = tmp_sub;

                    AssContents.Add(tmp_ass);
                }
                else
                {
                    if (!dialogue_found) //treat this as header
                    {

                            AssHeader += cur_line + "\n";

                    }
                    else //ignore this line
                    {

                    }
                }
            }
            reader.Close();
        }

        private Int32 getTimeFromString(String str)
        {
            //0:03:16.84
            Int32 hours = 0;
            Int32 minutes = 0;
            Int32 seconds = 0;
            Int32 milliseconds = 0;
            Int32 total_milliseconds = 0;
            String[] elements = str.Split(new String[] { ":" }, StringSplitOptions.None);
            hours = Int32.Parse(elements[0]);
            minutes = Int32.Parse(elements[1]);
            String[] elements2 = elements[2].Split(new String[] { "." }, StringSplitOptions.None);
            seconds = Int32.Parse(elements2[0]);
            milliseconds = Int32.Parse(elements2[1]) * 10;
            total_milliseconds = (hours * 60 * 60 * 1000) + (minutes * 60 * 1000) + (seconds * 1000) + milliseconds;
            return total_milliseconds;
        }

        public void WriteFinalAss(String filename)
        {
            StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8);
            writer.WriteLine(AssHeader);
            for (int i = 0; i < AssContents.Count; i++)
            {
                if (!AssContents[i].deleted)
                {
                    writer.WriteLine(AssContents[i].ToString());
                }
            }
            writer.Close();
        }

    }
}
