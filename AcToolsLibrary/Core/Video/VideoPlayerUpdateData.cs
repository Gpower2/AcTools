using System;
using System.Collections.Generic;
using System.Text;
using AcToolsLibrary.Core.Video.VideoProviders.AviSynth;
using System.Drawing;

namespace AcToolsLibrary.Core.Video
{
    public class VideoPlayerUpdateData
    {
        private AvsFile avs;
        private Image videoFrameImage;
        private Image videoFrameImagePrevious;
        private Image videoFrameImageNext;
        private Int32 currentFrame;
        private Boolean isPreview = false;

        public AvsFile Avs
        {
            get
            {
                return avs;
            }
        }

        public Image VideoFrameImage
        {
            get
            {
                return videoFrameImage;
            }
            set
            {
                //if (videoFrameImage != null)
                //{
                //    videoFrameImage.Dispose();
                //}
                videoFrameImage = value;
            }
        }

        public Image VideoFrameImagePrevious
        {
            get
            {
                return videoFrameImagePrevious;
            }
            set
            {
                //if (videoFrameImagePrevious != null)
                //{
                //    videoFrameImagePrevious.Dispose();
                //}
                videoFrameImagePrevious = value;
            }
        }

        public Image VideoFrameImageNext
        {
            get
            {
                return videoFrameImageNext;
            }
            set
            {
                //if (videoFrameImageNext != null)
                //{
                //    videoFrameImageNext.Dispose();
                //}
                videoFrameImageNext = value;
            }
        }

        public Int32 CurrentFrame
        {
            get
            {
                return currentFrame;
            }
            set
            {
                currentFrame = value;
            }
        }

        public Boolean IsPreview
        {
            get
            {
                return isPreview;
            }
            set
            {
                isPreview = value;
            }
        }


        public VideoPlayerUpdateData(AvsFile af, Image img, Int32 cf)
        {
            avs = af;
            currentFrame = cf;
            videoFrameImage = img;
        }

        public VideoPlayerUpdateData(AvsFile af)
        {
            avs = af;
        }
    }
}
