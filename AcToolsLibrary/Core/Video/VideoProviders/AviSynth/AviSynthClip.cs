using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth
{
    public enum AudioSampleType
    {
        FLOAT = 0x10,
        INT16 = 2,
        INT24 = 4,
        INT32 = 8,
        INT8 = 1,
        Unknown = 0
    }

    public enum AviSynthColorspace
    {
        I420 = -1610612720,
        IYUV = -1610612720,
        RGB24 = 0x50000001,
        RGB32 = 0x50000002,
        Unknown = 0,
        YUY2 = -1610612740,
        YV12 = -1610612728
    }

    public class AviSynthClip : IDisposable
    {

        // Fields
        private IntPtr _avs = new IntPtr(0);
        private AviSynthColorspace _colorSpace = AviSynthColorspace.Unknown;
        private AudioSampleType _sampleType = AudioSampleType.Unknown;
        private AVSDLLVideoInfo _vi = new AVSDLLVideoInfo();

        // Methods
        public AviSynthClip(string func, string arg, AviSynthColorspace forceColorspace, AviSynthScriptEnvironment env)
        {
            if (dimzon_avs_init_2(ref this._avs, func, arg, ref this._vi, ref this._colorSpace, ref this._sampleType, forceColorspace.ToString()) != 0)
            {
                string message = this.getLastError();
                this.cleanup(false);
                throw new AviSynthException(message);
            }
        }

        private void cleanup(bool disposing)
        {
            dimzon_avs_destroy(ref this._avs);
            this._avs = new IntPtr(0);
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        [DllImport("AcAvisynthWrapper", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int dimzon_avs_destroy(ref IntPtr avs);

        [DllImport("AcAvisynthWrapper", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int dimzon_avs_getaframe(IntPtr avs, IntPtr buf, long sampleNo, long sampleCount);

        [DllImport("AcAvisynthWrapper", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int dimzon_avs_getintvariable(IntPtr avs, string name, ref int val);

        [DllImport("AcAvisynthWrapper", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int dimzon_avs_getlasterror(IntPtr avs, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sb, int len);

        [DllImport("AcAvisynthWrapper", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int dimzon_avs_getvframe(IntPtr avs, IntPtr buf, int stride, int frm);

        [DllImport("AcAvisynthWrapper", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int dimzon_avs_init(ref IntPtr avs, string func, string arg, ref AVSDLLVideoInfo vi, ref AviSynthColorspace originalColorspace, ref AudioSampleType originalSampleType, string cs);

        [DllImport("AcAvisynthWrapper", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int dimzon_avs_init_2(ref IntPtr avs, string func, string arg, ref AVSDLLVideoInfo vi, ref AviSynthColorspace originalColorspace, ref AudioSampleType originalSampleType, string cs);
 
        ~AviSynthClip()
        {
            this.cleanup(false);
        }

        public int GetIntVariable(string variableName, int defaultValue)
        {
            int val = 0;
            int num2 = 0;
            num2 = dimzon_avs_getintvariable(this._avs, variableName, ref val);
            if (num2 < 0)
            {
                throw new AviSynthException(this.getLastError());
            }
            if (num2 != 0)
            {
                return defaultValue;
            }
            return val;
        }

        private string getLastError()
        {
            StringBuilder sb = new StringBuilder(0x400);
            sb.Length = dimzon_avs_getlasterror(this._avs, sb, 0x400);
            return sb.ToString();
        }

        public void ReadAudio(byte buffer, long offset, int count)
        {
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                this.ReadAudio(handle.AddrOfPinnedObject(), offset, count);
            }
            finally
            {
                handle.Free();
            }
        }

        public void ReadAudio(IntPtr addr, long offset, int count)
        {
            if (dimzon_avs_getaframe(this._avs, addr, offset, (long)count) != 0)
            {
                throw new AviSynthException(this.getLastError());
            }
        }

        public void ReadFrame(IntPtr addr, int stride, int frame)
        {
            if (dimzon_avs_getvframe(this._avs, addr, stride, frame) != 0)
            {
                throw new AviSynthException(this.getLastError());
            }
        }

        void IDisposable.Dispose()
        {
            this.cleanup(true);
        }

        // Properties
        public int aspectd
        {
            get
            {
                return this._vi.aspectd;
            }
        }

        public int aspectn
        {
            get
            {
                return this._vi.aspectn;
            }
        }

        public int AudioSampleRate
        {
            get
            {
                return this._vi.audio_samples_per_second;
            }
        }

        public long AudioSizeInBytes
        {
            get
            {
                return ((this.SamplesCount * this.ChannelsCount) * this.BytesPerSample);
            }
        }

        public int AvgBytesPerSec
        {
            get
            {
                return ((this.AudioSampleRate * this.ChannelsCount) * this.BytesPerSample);
            }
        }

        public short BitsPerSample
        {
            get
            {
                return (short)(this.BytesPerSample * 8);
            }
        }

        public short BytesPerSample
        {
            get
            {
                switch (this.SampleType)
                {
                    case AudioSampleType.INT8:
                        return 1;

                    case AudioSampleType.INT16:
                        return 2;

                    case AudioSampleType.INT24:
                        return 3;

                    case AudioSampleType.INT32:
                        return 4;

                    case AudioSampleType.FLOAT:
                        return 4;
                }
                throw new ArgumentException(this.SampleType.ToString());
            }
        }

        public short ChannelsCount
        {
            get
            {
                return (short)this._vi.nchannels;
            }
        }

        public bool HasVideo
        {
            get
            {
                return ((this.VideoWidth > 0) && (this.VideoHeight > 0));
            }
        }

        public int InterlacedFrame
        {
            get
            {
                return this._vi.interlaced_frame;
            }
        }

        public int NumberOfFrames
        {
            get
            {
                return this._vi.num_frames;
            }
        }

        public AviSynthColorspace OriginalColorspace
        {
            get
            {
                return this._colorSpace;
            }
        }

        public AudioSampleType OriginalSampleType
        {
            get
            {
                return this._sampleType;
            }
        }

        public AviSynthColorspace PixelType
        {
            get
            {
                return this._vi.pixel_type;
            }
        }

        public int Rated
        {
            get
            {
                return this._vi.rated;
            }
        }

        public int Raten
        {
            get
            {
                return this._vi.raten;
            }
        }

        public Double Rate
        {
            get
            {
                return Convert.ToDouble(this._vi.raten) / Convert.ToDouble(this._vi.rated);
            }
        }

        public long SamplesCount
        {
            get
            {
                return this._vi.num_audio_samples;
            }
        }

        public AudioSampleType SampleType
        {
            get
            {
                return this._vi.sample_type;
            }
        }

        public int TopFieldFirst
        {
            get
            {
                return this._vi.top_field_first;
            }
        }

        public int VideoHeight
        {
            get
            {
                return this._vi.height;
            }
        }

        public int VideoWidth
        {
            get
            {
                return this._vi.width;
            }
        }

        // Nested Types
        [StructLayout(LayoutKind.Sequential)]
        private struct AVSDLLVideoInfo
        {
            public int width;
            public int height;
            public int raten;
            public int rated;
            public int aspectn;
            public int aspectd;
            public int interlaced_frame;
            public int top_field_first;
            public int num_frames;
            public AviSynthColorspace pixel_type;
            public int audio_samples_per_second;
            public AudioSampleType sample_type;
            public int nchannels;
            public int num_audio_frames;
            public long num_audio_samples;
        }

    }
}
