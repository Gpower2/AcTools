using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Video
{
    /// <summary>
    /// Class that represents a video resolution object
    /// </summary>
    public class VideoResolution
    {
        private Int32 _Width = 0;
        private Int32 _Height = 0;
        private Double _PixelAspectRatio = 1.0;

        /// <summary>
        /// The width of the video in px
        /// </summary>
        public Int32 Width
        {
            get
            {
                return _Width;
            }
            set
            {
                if (value < 0)
                {
                    throw (new Exception("Invalid Width! Only positive or zero values allowed."));
                }
                _Width = value;
            }
        }

        /// <summary>
        /// The height of the video in px
        /// </summary>
        public Int32 Height
        {
            get
            {
                return _Height;
            }
            set
            {
                if (value < 0)
                {
                    throw (new Exception("Invalid Height! Only positive or zero values allowed."));
                }
                _Height = value;
            }
        }

        /// <summary>
        /// The aspect ratio of the Video (Read-only)
        /// </summary>
        public Double AspectRatio
        {
            get
            {
                if (_Width == 0)
                {
                    return 0.0;
                }
                if (_Height == 0)
                {
                    return Double.NaN;
                }
                return Convert.ToDouble(_Width) / Convert.ToDouble(_Height);
            }
        }

        /// <summary>
        /// The pixel aspect ration of the resolution
        /// </summary>
        public Double PixelAspectRatio
        {
            get
            {
                return _PixelAspectRatio;
            }
            set
            {
                if (value <= 0.0)
                {
                    throw (new Exception("Invalide Pixel Aspect Ratio! Only positive values are allowed."));
                }
                _PixelAspectRatio = value;
            }
        }


        /// <summary>
        /// Constructor for an empty video resolution
        /// </summary>
        public VideoResolution()
        {

        }

        /// <summary>
        /// Constructor for a video resolution with pixel aspect ratio 1.0
        /// </summary>
        /// <param name="w">the width in px</param>
        /// <param name="h">the height in px</param>
        public VideoResolution(Int32 w, Int32 h)
        {
            if (w < 0)
            {
                throw (new Exception("Invalid Width! Only positive or zero values allowed."));
            }
            _Width = w;

            if (h < 0)
            {
                throw (new Exception("Invalid Height! Only positive or zero values allowed."));
            }
            _Height = h;
        }

        /// <summary>
        /// Constructor for a video resolution with custom pixel aspect ratio
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="pxa"></param>
        public VideoResolution(Int32 w, Int32 h, Double pxa)
        {
            if (w < 0)
            {
                throw (new Exception("Invalid Width! Only positive or zero values allowed."));
            }
            _Width = w;

            if (h < 0)
            {
                throw (new Exception("Invalid Height! Only positive or zero values allowed."));
            }
            _Height = h;

            if (pxa <= 0.0)
            {
                throw (new Exception("Invalide Pixel Aspect Ratio! Only positive values are allowed."));
            }
            _PixelAspectRatio = pxa;
        }

        /// <summary>
        /// Returns a new duplicate Video Resolution object
        /// </summary>
        /// <returns>the duplicate object</returns>
        public VideoResolution Clone()
        {
            return (VideoResolution)this.MemberwiseClone();
        }

    }
}
