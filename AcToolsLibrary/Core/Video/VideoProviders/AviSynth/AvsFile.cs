using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth
{
    public class AvsFile :  IDisposable
    {
        // Fields
        private AviSynthClip clip;
        private AviSynthScriptEnvironment enviroment;
        private AvsVideoReader videoReader;
        private AvsAudioReader audioReader;
        private ulong videoWidth;
        private ulong videoHeight;

        // Methods
        private AvsFile(string script, bool parse)
        {
            try
            {
                this.enviroment = new AviSynthScriptEnvironment();
                this.clip = parse ? this.enviroment.ParseScript(script, AviSynthColorspace.RGB24) : this.enviroment.OpenScriptFile(script, AviSynthColorspace.RGB24);
                videoWidth = (ulong)this.clip.VideoWidth;
                videoHeight = (ulong)this.clip.VideoHeight;
            }
            catch (Exception)
            {
                this.cleanup();
                throw;
            }
        }

        private void cleanup()
        {
            if (this.clip != null)
            {
                ((IDisposable)this.clip).Dispose();
                this.clip = null;
            }
            if (this.enviroment != null)
            {
                ((IDisposable)this.enviroment).Dispose();
                this.enviroment = null;
            }
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            this.cleanup();
        }


        public AvsVideoReader GetVideoReader()
        {
            /*
            if (!this.Info.HasVideo)
            {
                throw new Exception("Can't get Video Reader, since there is no video stream!");
            }
             */
            if (this.videoReader == null)
            {
                lock (this)
                {
                    if (this.videoReader == null)
                    {
                        this.videoReader = new AvsVideoReader(this.clip, (int)this.videoWidth, (int)this.videoHeight);
                    }
                }
            }
            return this.videoReader;
        }

        public AvsAudioReader GetAudioReader(int track)
        {
            /*
            if ((track != 0) || !this.info.HasAudio)
            {
                throw new Exception(string.Format("Can't read audio track {0}, because it can't be found", track));
            }
             */
            if (this.audioReader == null)
            {
                lock (this)
                {
                    if (this.audioReader == null)
                    {
                        this.audioReader = new AvsAudioReader(this.clip);
                    }
                }
            }
            return this.audioReader;
        }

        public static AvsFile OpenScriptFile(string fileName)
        {
            return new AvsFile(fileName, false);
        }

        public static AvsFile ParseScript(string scriptBody)
        {
            return new AvsFile(scriptBody, true);
        }

        // Properties
        public bool CanReadAudio
        {
            get
            {
                return true;
            }
        }

        public bool CanReadVideo
        {
            get
            {
                return true;
            }
        }

        public AviSynthClip Clip
        {
            get
            {
                return this.clip;
            }
        }


        // Nested Types
        public sealed class AvsAudioReader
        {
            // Fields
            private AviSynthClip clip;

            // Methods
            public AvsAudioReader(AviSynthClip clip)
            {
                this.clip = clip;
            }

            public byte[] ReadAudioSamples(long nStart, int nAmount)
            {
                return null;
            }

            public long ReadAudioSamples(long nStart, int nAmount, IntPtr buf)
            {
                this.clip.ReadAudio(buf, nStart, nAmount);
                return (long)nAmount;
            }

            // Properties
            public long SampleCount
            {
                get
                {
                    return this.clip.SamplesCount;
                }
            }

            public bool SupportsFastReading
            {
                get
                {
                    return true;
                }
            }
        }

        public sealed class AvsVideoReader
        {
            // Fields
            private AviSynthClip clip;
            private int height;
            private int width;

            // Methods
            public AvsVideoReader(AviSynthClip clip, int width, int height)
            {
                this.clip = clip;
                this.width = width;
                this.height = height;
            }

            public void QuickReadBitmap(int position)
            {
                try
                {
                    this.clip.ReadFrame(IntPtr.Zero, 0, position);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public Bitmap ReadFrameBitmap(int position)
            {
                Bitmap bitmap = new Bitmap(this.width, this.height, PixelFormat.Format24bppRgb);
                try
                {
                    Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                    BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
                    try
                    {
                        IntPtr addr = bitmapdata.Scan0;
                        this.clip.ReadFrame(addr, bitmapdata.Stride, position);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapdata);
                    }
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                }
                catch (Exception)
                {
                    bitmap.Dispose();
                    throw;
                }
                return bitmap;
            }

            // Properties
            public int FrameCount
            {
                get
                {
                    return this.clip.NumberOfFrames;
                }
            }
        }
    }
}
