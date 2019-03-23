using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;

using AcToolsLibrary.Common;

namespace AcToolsLibrary.Core.Other
{
    public class Patcher
    {
        private List<Patch> _PatchList = new List<Patch>();
        private Boolean _WithWindow = true;
        private Boolean _CopyXdelta = true;
        private Exception _ThreadException = null;

        public List<Patch> PatchList { get { return _PatchList; } }

        public Boolean WithWindow
        {
            get { return _WithWindow; }
            set { _WithWindow = value; }
        }

        public Boolean CopyXdelta
        {
            get { return _CopyXdelta; }
            set { _CopyXdelta = value; }
        }

        public Exception ThreadException { get { return _ThreadException; } }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Patcher() { }

        public void AddPatch(Patch p)
        {
            _PatchList.Add(p);
        }

        public void RemovePatchAt(Int32 idx)
        {
            _PatchList.RemoveAt(idx);
        }

        public void RunPatcherThreaded()
        {
            // Set exception to null
            _ThreadException = null;
            try
            {
                RunPatcher();
            }
            catch (Exception ex)
            {
                _ThreadException = ex;
            }
        }

        public void RunPatcher()
        {
            // Check patch list
            if (_PatchList == null)
            {
                throw new Exception("Error making patches! Patch list is null!");
            }
            //Check for existance of xdelta3.exe
            String xdeltaFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "xdelta3.exe");
            if (!File.Exists(xdeltaFileName))
            {
                throw new Exception("Error making patches! xdelta3.exe not found!");
            }
            foreach (Patch p in _PatchList)
            {
                Process proc = new Process();
                StringBuilder args = new StringBuilder();
                //xdelta3 -9 -s SOURCE TARGET OUT
                args.AppendFormat(" -9 -e -v -s \"{0}\" \"{1}\" \"{2}\"", p.OldFile, p.NewFile, p.DiffFile);
                ProcessStartInfo psi = new ProcessStartInfo(xdeltaFileName, args.ToString());
                psi.WindowStyle = _WithWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;
                proc.StartInfo = psi;
                proc.Start();
                proc.WaitForExit();

                // check the exit code
                if (proc.ExitCode > 0)
                {
                    throw new Exception("xdelta3 exited with errors!");
                }
                //Empty stringbuilder
                args.Length = 0;
                // xdelta3 -d -s SOURCE OUT > TARGET
                args.AppendFormat("xdelta3 -d -v -s \"{0}\" \"{1}\" \"{2}\"",
                    AcHelper.GetFilename(p.OldFile, GetFileNameMode.FullFilename, GetDirectoryNameMode.NoPath),
                    AcHelper.GetFilename(p.DiffFile, GetFileNameMode.FullFilename, GetDirectoryNameMode.NoPath),
                    AcHelper.GetFilename(p.NewFile, GetFileNameMode.FullFilename, GetDirectoryNameMode.NoPath));
                //Define the batch filename
                String batFile = String.Format("{0}.bat", AcHelper.GetFilename(p.DiffFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath));

                //Begin writing the file
                using (StreamWriter sw = new StreamWriter(batFile, false, AcHelper.GetUTF8EncodingWithoutBom()))
                {
                    sw.Write(args.ToString());
                }
                //Copy file xdelta to destination directory
                if (_CopyXdelta)
                {
                    if (!File.Exists(Path.Combine(AcHelper.GetFilename(p.NewFile, GetFileNameMode.NoFileName, GetDirectoryNameMode.FullPath), "xdelta3.exe")))
                    {
                        File.Copy(xdeltaFileName, Path.Combine(AcHelper.GetFilename(p.NewFile, GetFileNameMode.NoFileName, GetDirectoryNameMode.FullPath), "xdelta3.exe"));
                    }
                }
            }
        }

    }
}
