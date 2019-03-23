using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Web;
using System.Globalization;
using System.Linq;

using AcTools.Core;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using AcToolsLibrary.Core.Parsers;
using AcToolsLibrary.Core.Subtitles.ASS;
using AcTools.Core.Subtitles.SRT;

namespace AcTools.Forms
{
    public partial class frmAss : AcForm
    {
        public frmAss()
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon();
        }

        private void txtAssFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtAssFile_DragDrop(object sender, DragEventArgs e)
        {
            String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            txtAssFile.Text = s[0];
        }

        private void txtSectionsFile_DragDrop(object sender, DragEventArgs e)
        {
            String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            txtSectionsFile.Text = s[0];
        }

        private void txtSectionsFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            try
            {
                AssParser assP = new AssParser();
                assP.ParseASS(txtAssFile.Text);
                VideoFrameList vfl = new VideoFrameList();
                SectionParser.ParseSections(txtSectionsFile.Text, vfl);
                Decimal framerate = AcHelper.DecimalParse(txtFramerate.Text);
                foreach (AssDialogue assD in assP.AssContents)
                {
                    Decimal timeToDelete = 0;
                    for (Int32 currentSection = 0; currentSection < vfl.FrameSections.Count; currentSection++)
                    {
                        VideoFrameSection vfs = vfl.FrameSections[currentSection];
                        Decimal startSection = VideoFrame.GetStartTimeFromFrameNumber(vfs.FrameStart, framerate);
                        Decimal endSection = VideoFrame.GetStartTimeFromFrameNumber(vfs.FrameEnd, framerate);
                        //Check if the sub ends before the section
                        if (assD.time_end_double <= startSection)
                        {
                            assD.deleted = true;
                            break;
                        }
                        //Check if the sub starts after the section
                        if (assD.time_start_double >= endSection)
                        {
                            //If its the last sections, then delete the sub
                            if (currentSection == vfl.FrameSections.Count - 1)
                            {
                                assD.deleted = true;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        //Time to resync the sub
                        if (currentSection == 0)
                        {
                            TimeSpan ts;
                            timeToDelete = startSection;
                            assD.time_start_double = assD.time_start_double - timeToDelete;
                            ts = TimeSpan.FromMilliseconds(Convert.ToDouble(assD.time_start_double));
                            assD.time_start = ts.Hours.ToString("0") + ":" + ts.Minutes.ToString("00")
                                + ":" + ts.Seconds.ToString("00") + "." + ts.Milliseconds.ToString("00");

                            assD.time_end_double = assD.time_end_double - timeToDelete;
                            ts = TimeSpan.FromMilliseconds(Convert.ToDouble(assD.time_end_double));
                            assD.time_end = ts.Hours.ToString("0") + ":" + ts.Minutes.ToString("00")
                                + ":" + ts.Seconds.ToString("00") + "." + ts.Milliseconds.ToString("00");
                            break;
                        }
                        else
                        {
                            TimeSpan ts;
                            Decimal start = startSection;
                            Decimal end = endSection;
                            Decimal prevEnd = VideoFrame.GetStartTimeFromFrameNumber(vfl.FrameSections[currentSection - 1].FrameEnd, framerate);
                            timeToDelete += start - prevEnd - VideoFrame.GetDurationFromFrameRate(framerate);
                            assD.time_start_double = assD.time_start_double - timeToDelete;
                            ts = TimeSpan.FromMilliseconds(Convert.ToDouble(assD.time_start_double));
                            assD.time_start = ts.Hours.ToString("0") + ":" + ts.Minutes.ToString("00")
                                + ":" + ts.Seconds.ToString("00") + "." + ts.Milliseconds.ToString("00");

                            assD.time_end_double = assD.time_end_double - timeToDelete;
                            ts = TimeSpan.FromMilliseconds(Convert.ToDouble(assD.time_end_double));
                            assD.time_end = ts.Hours.ToString("0") + ":" + ts.Minutes.ToString("00")
                                + ":" + ts.Seconds.ToString("00") + "." + ts.Milliseconds.ToString("00");
                            break;
                        }

                    }
                }
                assP.WriteFinalAss(txtAssFile.Text.Substring(0, txtAssFile.Text.LastIndexOf(".") - 1) + ".resync.ass");
                MessageBox.Show("Resync complete!", "Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private delegate void UpdateStatusDelegate(String str);
        private void UpdateStatus(String str)
        {
            lblStatus.Text = str;
        }

        private delegate void UpdateProgressDelegate(Int32 value);
        private void UpdateProgress(Int32 value)
        {
            progressBar.ProgressBar.Value = value;
        }

        private delegate void UpdateProgressMinimumDelegate(Int32 value);
        private void UpdateProgressMinimum(Int32 value)
        {
            progressBar.ProgressBar.Minimum = value;
        }

        private delegate void UpdateProgressMaximumDelegate(Int32 value);
        private void UpdateProgressMaximum(Int32 value)
        {
            progressBar.ProgressBar.Maximum = value;
        }

        private void translateAss()
        {
            String clientSecret = "t2TgsRqHDyX9sDuUhV6j+A0cTc9cqPVQCptbELxtll0=";
            String clientId = "AcTools";

            AdmAccessToken admToken;
            string headerValue;
            //Get Client Id and Client Secret from https://datamarket.azure.com/developer/applications/
            //Refer obtaining AccessToken (http://msdn.microsoft.com/en-us/library/hh454950.aspx) 
            AdmAuthentication admAuth = new AdmAuthentication(clientId, clientSecret);

            admToken = admAuth.GetAccessToken();
            // Create a header with the access_token property of the returned token
            headerValue = "Bearer " + admToken.access_token;

            //String key = "ABQIAAAAI4Uz6--7ldB77aSAjIT7DBR_SxwQvsoWDay0I_E-DJX3B_bnPhSeckwBVQ-R5MPCAZlrImAtgeHnIA";
            //String langpair = "ja%7Cen";
            //String langpair = "zh-CN%7Cen";
            String langSource = "zh-CN";
            String langDest = "en";

            statusStrip.BeginInvoke(new UpdateStatusDelegate(UpdateStatus), "Starting parsing ass file...");
            Application.DoEvents();

            AssParser assP = new AssParser();
            assP.ParseASS(txtAssFile.Text);
            progressBar.ProgressBar.BeginInvoke(new UpdateProgressMinimumDelegate(UpdateProgressMinimum), 0);
            progressBar.ProgressBar.BeginInvoke(new UpdateProgressMinimumDelegate(UpdateProgressMaximum), assP.AssContents.Count);
            int i = 1;
            statusStrip.BeginInvoke(new UpdateStatusDelegate(UpdateStatus), "Starting translating ass file...");
            Application.DoEvents();

            foreach (AssDialogue assD in assP.AssContents)
            {
                string translation = String.Empty;
                string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text="
                    + System.Web.HttpUtility.UrlEncode(assD.subtitle)
                    + "&from=" + langSource
                    + "&to=" + langDest;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.Headers.Add("Authorization", headerValue);
                WebResponse response2 = null;
                try
                {
                    response2 = httpWebRequest.GetResponse();
                    using (Stream stream = response2.GetResponseStream())
                    {
                        System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                        translation = (string)dcs.ReadObject(stream);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (response2 != null)
                    {
                        response2.Close();
                        response2 = null;
                    }
                }

                assD.subtitle = translation;

                //// used to build entire input
                //StringBuilder sb = new StringBuilder();

                //// used on each read operation
                //byte[] buf = new byte[8192];

                //String url = String.Format("http://ajax.googleapis.com/ajax/services/language/translate?v=1.0&q={0}&langpair={1}&key={2}", assD.subtitle, langpair, key);
                ////String url = String.Format("https://www.googleapis.com/language/translate/v2?key={0}&source={1}&target={2}&q={3}",
                //  //  key, langSource, langDest, System.Web.HttpUtility.HtmlEncode(assD.subtitle));

                //// prepare the web page we will be asking for
                //HttpWebRequest request = (HttpWebRequest)
                //    WebRequest.Create(url);

                ////lblStatus.Text =String.Format( "Requesting translation for line {0}...", i);
                //statusStrip.BeginInvoke(new UpdateStatusDelegate(UpdateStatus), String.Format("Requesting translation for line {0}/{1}...",
                //    i, assP.AssContents.Count));
                //Application.DoEvents();

                //// execute the request
                //HttpWebResponse response = (HttpWebResponse)
                //    request.GetResponse();

                //// we will read data via the response stream
                //Stream resStream = response.GetResponseStream();

                //string tempString = null;
                //int count = 0;

                //do
                //{
                //    // fill the buffer with data
                //    count = resStream.Read(buf, 0, buf.Length);

                //    // make sure we read some data
                //    if (count != 0)
                //    {
                //        // translate from bytes to UTF8 text
                //        tempString = Encoding.UTF8.GetString(buf, 0, count);

                //        // continue building the string
                //        sb.Append(tempString);
                //    }
                //}
                //while (count > 0); // any more data to read?

                //JsonTextParser parser = new JsonTextParser();
                //JsonObject obj = parser.Parse(sb.ToString());

                //foreach (JsonObject field in obj as JsonObjectCollection)
                //{

                //    string name = field.Name;
                //    if (name.ToLower().Contains("responsedata"))
                //    {
                //        List<JsonObject> lst = (List<JsonObject>)field.GetValue();

                //        //String str2 = getRomanji(assD.subtitle);
                //        String str = String.Empty;
                //        if (lst != null)
                //        {
                //            str = lst[0].GetValue().ToString();
                //        }
                //        assD.subtitle = System.Web.HttpUtility.HtmlDecode(System.Web.HttpUtility.UrlDecode(str));
                //    }
                //}
                statusStrip.BeginInvoke(new UpdateStatusDelegate(UpdateStatus), String.Format("Translated line {0}/{1}!",
                    i, assP.AssContents.Count));
                progressBar.ProgressBar.BeginInvoke(new UpdateProgressDelegate(UpdateProgress), i);
                i++;
            }

            statusStrip.BeginInvoke(new UpdateStatusDelegate(UpdateStatus), "Started Writing translated ass file...");

            assP.WriteFinalAss(txtAssFile.Text.Substring(0, txtAssFile.Text.LastIndexOf(".")) + ".trans.ass");

        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            Thread t;
            t = new Thread(new ThreadStart(translateAss));
            t.Start();

            while (t.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Application.DoEvents();
            }
            MessageBox.Show("All lines translated successfully!", "Success!");
            lblStatus.Text = "Completed translation";
            progressBar.Value = 0;
        }

        private String getRomanji(String str)
        {
            String url = "http://nihongo.j-talk.com/kanji";
            String parameters = String.Format("kanji={0}", System.Web.HttpUtility.UrlEncode(str));
            parameters = String.Format("{0}&conversion={1}", parameters, System.Web.HttpUtility.UrlEncode("spaced"));
            parameters = String.Format("{0}&start_with_hiragana={1}", parameters, System.Web.HttpUtility.UrlEncode("1"));
            parameters = String.Format("{0}&ruby-top={1}", parameters, System.Web.HttpUtility.UrlEncode("1"));
            parameters = String.Format("{0}&Submit={1}", parameters, System.Web.HttpUtility.UrlEncode("Translate Now"));


            WebRequest webRequest = WebRequest.Create(url);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.UTF8.GetBytes(parameters);
            Stream os = null;
            try
            { // send the Post
                webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "HttpPost: Request error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            WebResponse webResponse = webRequest.GetResponse();
            if (webResponse == null)
            {
                return null;
            }
            StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
            return sr.ReadToEnd().Trim();
        }

        private void btnUrlDecode_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(txtAssFile.Text, Encoding.UTF8);
            StringBuilder sb = new StringBuilder();
            while (!sr.EndOfStream)
            {
                String line = sr.ReadLine();
                sb.AppendLine(System.Web.HttpUtility.HtmlDecode(System.Web.HttpUtility.UrlDecode(line)));
            }
            StreamWriter sw = new StreamWriter(txtAssFile.Text + ".decoded.html", false, Encoding.UTF8);
            sw.Write(sb.ToString());
            sr.Close();
            sw.Close();
            MessageBox.Show("Decoding is finished!", "Success!");
        }

        private void btnFixAss_Click(object sender, EventArgs e)
        {
            AssFile af = new AssFile();
            af.Load(txtAssFile.Text);
            if (af.Warnings.Count > 0)
            {
                Debug.WriteLine("Found warnings, writing down fixed file");
                af.SaveAs(txtAssFile.Text + ".FIXED.ass");
                AcControls.AcMessageBox.AcMessageBox.Show("Fixed file!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AcControls.AcMessageBox.AcMessageBox.Show("No need to fix file!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnTestCharset_Click(object sender, EventArgs e)
        {
            //Load a file
            AssFile af = new AssFile();
            af.Load(txtAssFile.Text);
            //Load b file
            AssFile bf = new AssFile();
            bf.Load(txtSectionsFile.Text);

            //sort a file by time
            //af.SectionEvents.SortEventLines(AssEventsSortType.ByStartTime, Core.ASS.SortOrder.Ascending);
            //sort b file by time
            //bf.SectionEvents.SortEventLines(AssEventsSortType.ByStartTime, Core.ASS.SortOrder.Ascending);

            List<String> diffs = new List<String>();

            //Compare event lines
            Int32 bIdx = 0;

            //second more accurate attempt
            diffs.Clear();
            //Create a working copy for the event lines
            List<AssLineEvent> bLines = new List<AssLineEvent>(bf.SectionEvents.EventLines);
            foreach (AssLineEvent aLine in af.SectionEvents.EventLines)
            {
                //begin loop for each line in b file
                Int32 minDiff = LD(aLine.Text, bLines[0].Text);
                Int64 minTimeDiff = Math.Abs(aLine.StartValue - bLines[0].StartValue);
                //lines are the same
                if (minDiff == 0)
                {
                    //remove the line from the working copy
                    bLines.RemoveAt(0);
                    continue;
                }
                else
                {
                    bIdx = 0;
                    for (Int32 i = 1; i < bLines.Count; i++)
                    {
                        Int32 cDiff = LD(aLine.Text, bLines[i].Text);
                        Int64 cTimeDiff = Math.Abs(aLine.StartValue - bLines[i].StartValue);
                        Debug.WriteLine(String.Format("a: {0} b: {1} cdiff: {2}", aLine.OriginalOrder, bLines[i].OriginalOrder, cDiff));
                        //lines are the same
                        if (cDiff == 0)
                        {
                            minDiff = 0;
                            //remove the line from the working copy
                            bLines.RemoveAt(i);
                            break;
                        }
                        else
                        {
                            //Find the minimum difference
                            if (cDiff + cTimeDiff < minDiff + minTimeDiff)
                            {
                                minDiff = cDiff;
                                minTimeDiff = cTimeDiff;
                                bIdx = i;
                            }
                        }
                    }
                    //lines are the same
                    if (minDiff == 0)
                    {
                        continue;
                    }
                    else
                    {
                        //lines are different
                        //check the line with the smallest text difference
                        //Find the differences
                        StringBuilder oldBuilder = new StringBuilder();
                        StringBuilder newBuilder = new StringBuilder();
                        AcStringTokenizer a = new AcStringTokenizer(aLine.Text);
                        AcStringTokenizer b = new AcStringTokenizer(bLines[bIdx].Text);
                        a.IgnoreWhiteSpace = false;
                        b.IgnoreWhiteSpace = false;

                        List<String> aList = a.GetAllTokenValues();
                        List<String> bList = b.GetAllTokenValues();

                        foreach (String token in aList)
                        {
                            oldBuilder.AppendLine(token);
                        }
                        if (oldBuilder.Length > 1)
                        {
                            oldBuilder.Length -= 1;
                        }
                        foreach (String token in bList)
                        {
                            newBuilder.AppendLine(token);
                        }
                        if (newBuilder.Length > 1)
                        {
                            newBuilder.Length -= 1;
                        }

                        AcDiff.AcDiffItem[] f = AcDiff.DiffText(oldBuilder.ToString(), newBuilder.ToString(), true, true, false);

                        //Change tokens
                        foreach (AcDiff.AcDiffItem it in f)
                        {
                            for (Int32 i = it.StartA; i < it.StartA + it.deletedA; i++)
                            {
                                aList[i] = "--" + aList[i] + "--";
                            }
                            for (Int32 i = it.StartB; i < it.StartB + it.insertedB; i++)
                            {
                                bList[i] = "++" + bList[i] + "++";
                            }
                        }

                        //Add the old and new string to the list
                        oldBuilder.Length = 0;
                        foreach (String token in aList)
                        {
                            oldBuilder.Append(token);
                        }
                        newBuilder.Length = 0;
                        foreach (String token in bList)
                        {
                            newBuilder.Append(token);
                        }

                        diffs.Add("-- [" + aLine.OriginalOrder + "] " + oldBuilder.ToString());
                        diffs.Add("++ [" + bLines[bIdx].OriginalOrder + "] " + newBuilder.ToString());

                    }
                }
            }
            lstAss2.SuspendLayout();
            lstAss2.Items.Clear();
            foreach (String s in diffs)
            {
                lstAss2.Items.Add(s);
            }
            lstAss2.ResumeLayout();


            String oldLine = txtAssFile.Text;
            String newLine = txtSectionsFile.Text;
            //Check if lines are the same:
            if (oldLine != newLine)
            {
                StringBuilder oldBuilder = new StringBuilder();
                StringBuilder newBuilder = new StringBuilder();
                AcStringTokenizer a = new AcStringTokenizer(oldLine);
                AcStringTokenizer b = new AcStringTokenizer(newLine);
                a.IgnoreWhiteSpace = false;
                a.SymbolChars = new List<char> { ',', ':', '\\' };
                b.IgnoreWhiteSpace = false;
                b.SymbolChars = new List<char> { ',', ':', '\\' };

                List<AcStringToken> aList = a.GetAllTokens();
                List<AcStringToken> bList = b.GetAllTokens();

                foreach (AcStringToken token in aList)
                {
                    oldBuilder.AppendLine(token.Value);
                }
                oldBuilder.Length -= 1;
                foreach (AcStringToken token in bList)
                {
                    newBuilder.AppendLine(token.Value);
                }
                newBuilder.Length -= 1;

                AcDiff.AcDiffItem[] f = AcDiff.DiffText(oldBuilder.ToString(), newBuilder.ToString(), true, true, false);
            }
        }

        /// <summary>
        /// Compute Levenshtein distance
        /// </summary>
        /// <param name="s">String 1</param>
        /// <param name="t">String 2</param>
        /// <returns>Distance between the two strings.
        /// The larger the number, the bigger the difference.
        /// </returns>
        public int LD(string s, string t)
        {
            int n = s.Length; //length of s
            int m = t.Length; //length of t
            int[,] d = new int[n + 1, m + 1]; // matrix
            int cost; // cost
            // Step 1
            if (n == 0) return m;
            if (m == 0) return n;
            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 0; j <= m; d[0, j] = j++) ;
            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    cost = (t.Substring(j - 1, 1) == s.Substring(i - 1, 1) ? 0 : 1);
                    // Step 6
                    d[i, j] = System.Math.Min(System.Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                              d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        private void btnChangeAssTiming_Click(object sender, EventArgs e)
        {
            try
            {
                String newStartStr = AcControls.AcInputBox.AcInputBox.Show("Give the new start of the first subtitle:", "New start...", "");
                String newEndStr = AcControls.AcInputBox.AcInputBox.Show("Give the new start of the last subtitle:", "New end...", "");

                AssFile assF = new AssFile(txtAssFile.Text);
                assF.SectionEvents.SortEventLines(AssEventsSortType.ByStartTime, AcToolsLibrary.Core.Subtitles.ASS.SortOrder.Ascending);
                Int64 newStart = assF.SectionEvents.EventLines[0].GetTimeInMs(newStartStr);
                Int64 newEnd = assF.SectionEvents.EventLines[0].GetTimeInMs(newEndStr) +
                    assF.SectionEvents.EventLines[assF.SectionEvents.EventLines.Count - 1].Duration;
                Double ratio = Convert.ToDouble((newEnd - newStart)) /
                     Convert.ToDouble((assF.SectionEvents.EventLines[assF.SectionEvents.EventLines.Count - 1].EndValue
                    - assF.SectionEvents.EventLines[0].StartValue));

                Int64 lastOldEnd = 0;
                for (Int32 i = 0; i < assF.SectionEvents.EventLines.Count; i++)
                {
                    AssLineEvent assL = assF.SectionEvents.EventLines[i];
                    // if its the first line
                    if (i == 0)
                    {
                        Int64 oldDuration = assL.Duration;
                        Int64 newDuration = Convert.ToInt64(oldDuration * ratio);
                        lastOldEnd = assL.EndValue;
                        assL.StartValue = newStart;
                        assL.EndValue = assL.StartValue + newDuration;
                    }
                    else
                    {
                        Int64 oldDuration = assL.Duration;
                        Int64 newDuration = Convert.ToInt64(oldDuration * ratio);
                        Int64 oldGapDuration = assL.StartValue - lastOldEnd;
                        Int64 newGapDuration = Convert.ToInt64(oldGapDuration * ratio);
                        lastOldEnd = assL.EndValue;
                        assL.StartValue = assF.SectionEvents.EventLines[i - 1].EndValue + newGapDuration;
                        assL.EndValue = assL.StartValue + newDuration;
                    }
                }
                assF.SaveAs(assF.Filename + ".new.ass");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnFixAss2_Click(object sender, EventArgs e)
        {
            try
            {
                AssFile assF = new AssFile(txtAssFile.Text);
                assF.SectionEvents.SortEventLines(AssEventsSortType.ByStartTime, AcToolsLibrary.Core.Subtitles.ASS.SortOrder.Ascending);
                List<Int32> lineIndecesToBeRemoved = new List<int>();
                for (int i = 0; i < assF.SectionEvents.EventLines.Count; i++)
                {
                    if (lineIndecesToBeRemoved.Contains(i))
                    {
                        continue;
                    }
                    AssLineEvent myLine = assF.SectionEvents.EventLines[i];
                    for (int j = i + 1; j < assF.SectionEvents.EventLines.Count; j++)
                    {
                        // check only 50 lines ahead
                        if (j - i > 50)
                        {
                            break;
                        }
                        AssLineEvent lineToTest = assF.SectionEvents.EventLines[j];
                        if (myLine.Text.Trim() == lineToTest.Text.Trim())
                        {
                            lineIndecesToBeRemoved.Add(j);
                            myLine.EndValue = lineToTest.EndValue;
                        }
                    }
                }
                // processing ended, time to remove lines
                List<Int32> sortedList = lineIndecesToBeRemoved.OrderByDescending(t => t).ToList();
                foreach (var i in sortedList)
                {
                    assF.SectionEvents.EventLines.RemoveAt(i);
                }
                assF.SectionEvents.SortEventLines(AssEventsSortType.ByStartTime, AcToolsLibrary.Core.Subtitles.ASS.SortOrder.Ascending);
                assF.SaveAs(assF.Filename + ".fixed.ass");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnParseSrt_Click(object sender, EventArgs e)
        {
            try
            {
                SrtFile srtFile = new SrtFile(txtAssFile.Text);
                srtFile.SaveAs(txtAssFile.Text + ".2.srt");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }
    }
    [DataContract]
    public class AdmAccessToken
    {
        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public string expires_in { get; set; }
        [DataMember]
        public string scope { get; set; }
    }

    public class AdmAuthentication
    {
        public static readonly string DatamarketAccessUri = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
        private string clientId;
        private string clientSecret;
        private string request;
        private AdmAccessToken token;
        private System.Threading.Timer accessTokenRenewer;

        //Access token expires every 10 minutes. Renew it every 9 minutes only.
        private const int RefreshTokenDuration = 9;

        public AdmAuthentication(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            //If clientid or client secret has special characters, encode before sending request
            this.request = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientId), HttpUtility.UrlEncode(clientSecret));
            this.token = HttpPost(DatamarketAccessUri, this.request);
            //renew the token every specfied minutes
            accessTokenRenewer = new System.Threading.Timer(new TimerCallback(OnTokenExpiredCallback), this, TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
        }

        public AdmAccessToken GetAccessToken()
        {
            return this.token;
        }


        private void RenewAccessToken()
        {
            AdmAccessToken newAccessToken = HttpPost(DatamarketAccessUri, this.request);
            //swap the new token with old one
            //Note: the swap is thread unsafe
            this.token = newAccessToken;
            Console.WriteLine(string.Format("Renewed token for user: {0} is: {1}", this.clientId, this.token.access_token));
        }

        private void OnTokenExpiredCallback(object stateInfo)
        {
            try
            {
                RenewAccessToken();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed renewing access token. Details: {0}", ex.Message));
            }
            finally
            {
                try
                {
                    accessTokenRenewer.Change(TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Failed to reschedule the timer to renew access token. Details: {0}", ex.Message));
                }
            }
        }


        private AdmAccessToken HttpPost(string DatamarketAccessUri, string requestDetails)
        {
            //Prepare OAuth request 
            WebRequest webRequest = WebRequest.Create(DatamarketAccessUri);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(requestDetails);
            webRequest.ContentLength = bytes.Length;
            using (Stream outputStream = webRequest.GetRequestStream())
            {
                outputStream.Write(bytes, 0, bytes.Length);
            }
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AdmAccessToken));
                //Get deserialized object from JSON stream
                AdmAccessToken token = (AdmAccessToken)serializer.ReadObject(webResponse.GetResponseStream());
                return token;
            }
        }
    }
}
