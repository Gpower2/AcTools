using AcToolsLibrary.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Video
{
    public class Resizer
    {
        private Int64 originalWidth = 0;
        private Int64 originalHeight = 0;
        private Double originalAspectRatio = 0.0;

        private Int64 cropX1 = 0;
        private Int64 cropX2 = 0;
        private Int64 cropY1 = 0;
        private Int64 cropY2 = 0;

        private Int64 stretchAspectRatioNum = 0;
        private Int64 stretchAspectRatioDenum = 0;

        private Int64 targetMod = 0;
        
        private Int64 trueWidth = 0;
        private Int64 trueHeight = 0;
        private Double trueAspectRatio = 0.0;

        private Int64 trueStretchedWidth = 0;
        private Int64 trueStretchedHeight = 0;
        private Double trueStretchedAspectRatio = 0.0;

        private Int64 finalStretchedWidth = 0;
        private Int64 finalStretchedHeight = 0;
        private Double finalStretchedAspectRatio = 0.0;
   
        private Int64 encAnamWidth = 0;
        private Int64 encAnamHeight = 0;
        private Double encAnamAspectRatio = 0.0;

        private Int64 finalAnamWidth = 0;
        private Int64 finalAnamHeight = 0;
        private Double finalAnamAspectRatio = 0.0;

        private Double errorStretchedAspectRatio = 0.0;
        private Double errorEncAnamAspectRatio = 0.0;
        private Double errorFinalAnamAspectRatio = 0.0;

        private Int64 originalPixels = 0;
        private Int64 truePixels = 0;
        private Int64 finalStretchedPixels = 0;
        private Int64 encAnamPixels = 0;
        private Int64 anamPixels = 0;

        public Int64 FinalStretchedWidth
        {
            get
            {
                return finalStretchedWidth;
            }
        }

        public Int64 FinalStretchedHeight
        {
            get
            {
                return finalStretchedHeight;
            }
        }

        public Double AspectRatioStretchedError
        {
            get
            {
                return errorStretchedAspectRatio;
            }
        }

        public Double TrueStretchedAspectRatio
        {
            get
            {
                return trueStretchedAspectRatio;
            }
        }

        public Double FinalStretchedAspectRatio
        {
            get
            {
                return finalStretchedAspectRatio;
            }
        }

        public Int64 EncAnamorphicWidth
        {
            get
            {
                return encAnamWidth;
            }
        }

        public Int64 EncAnamorphicHeight
        {
            get
            {
                return encAnamHeight;
            }
        }

        public Double EncAnamorphicAspectRatio
        {
            get
            {
                return encAnamAspectRatio;
            }
        }

        public Double EncAnamorphicError
        {
            get
            {
                return errorEncAnamAspectRatio;
            }
        }

        public Int64 FinalAnamorphicWidth
        {
            get
            {
                return finalAnamWidth;
            }
        }

        public Int64 FinalAnamorphicHeight
        {
            get
            {
                return finalAnamHeight;
            }
        }

        public Double FinalAnamorphicAspectRatio
        {
            get
            {
                return finalAnamAspectRatio;
            }
        }

        public Double FinalAnamorphicError
        {
            get
            {
                return errorFinalAnamAspectRatio;
            }
        }

        public Double TrueAspectRatio
        {
            get
            {
                return trueAspectRatio;
            }
        }

        public Int64 OriginalWidth
        {
            get
            {
                return originalWidth;
            }
            set
            {
                originalWidth = value;
            }
        }

        public Int64 OriginalHeight
        {
            get
            {
                return originalHeight;
            }
            set
            {
                originalHeight = value;
            }
        }

        public Int64 CropX1
        {
            set
            {
                cropX1 = value;
            }
        }

        public Int64 CropX2
        {
            set
            {
                cropX2 = value;
            }
        }

        public Int64 CropY1
        {
            set
            {
                cropY1 = value;
            }
        }

        public Int64 CropY2
        {
            set
            {
                cropY2 = value;
            }
        }

        public Int64 StretchAspectRatioNum
        {
            set
            {
                stretchAspectRatioNum = value;
            }
        }

        public Int64 StretchAspectRatioDenum
        {
            set
            {
                stretchAspectRatioDenum = value;
            }
        }

        public Int64 TargetMod
        {
            set
            {
                targetMod = value;
            }
        }

        public Int64 TrueWidth
        {
            get
            {
                return trueWidth;
            }
        }

        public Int64 TrueHeight
        {
            get
            {
                return trueHeight;
            }
        }

        public Int64 TruePixels
        {
            get
            {
                return truePixels;
            }
        }

        public Int64 FinalStretchedPixels
        {
            get
            {
                return finalStretchedPixels;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Resizer()
        {

        }

        /// <summary>
        /// Constructor with initial values
        /// </summary>
        /// <param name="oW">original Width</param>
        /// <param name="oH">original Height</param>
        /// <param name="x1">crop x1 pixels</param>
        /// <param name="y1">crop y1 pixels</param>
        /// <param name="x2">crop x2 pixels</param>
        /// <param name="y2">crop y2 pixels</param>
        /// <param name="aNum">stretch aspect ratio numerator</param>
        /// <param name="aDenum">stretch aspect ratio denumerator</param>
        /// <param name="tMod">target Mod</param>
        public Resizer(Int64 oW, Int64 oH, Int64 x1, Int64 y1, Int64 x2, Int64 y2, Int64 aNum, Int64 aDenum, Int64 tMod)
        {
            originalWidth = oW;
            originalHeight = oH;
            cropX1 = x1;
            cropY1 = y1;
            cropX2 = x2;
            cropY2 = y2;
            stretchAspectRatioNum = aNum;
            stretchAspectRatioDenum = aDenum;
            targetMod = tMod;
        }

        /// <summary>
        /// Calculates the final dimensions according to the desired width
        /// </summary>
        /// <param name="desiredWidth">The desired output width</param>
        public void CalculateValuesForDesiredWidth(Int64 desiredWidth)
        {
            //Makes the original and after crop calculations
            GeneralCalculations();

            //The final stretched width
            finalStretchedWidth = ClosestMod(desiredWidth, targetMod);
            //The final stretched height
            finalStretchedHeight = ClosestMod(Convert.ToDouble(finalStretchedWidth * trueHeight * stretchAspectRatioDenum * originalWidth)
                / Convert.ToDouble(trueWidth * stretchAspectRatioNum * originalHeight), targetMod);
            finalStretchedAspectRatio = Convert.ToDouble(finalStretchedWidth) / Convert.ToDouble(finalStretchedHeight);

            finalStretchedPixels = finalStretchedWidth * finalStretchedHeight;

            //The aspect ratio error in %
            errorStretchedAspectRatio = (Math.Abs(finalStretchedAspectRatio - trueStretchedAspectRatio)
                / Convert.ToDouble(trueStretchedAspectRatio)) * 100.0;
        }

        /// <summary>
        /// Calculates the final dimensions according to the desired height
        /// </summary>
        /// <param name="desiredWidth">The desired output height</param>
        public void CalculateValuesForDesiredHeight(Int64 desiredHeight)
        {
            //Makes the original and after crop calculations
            GeneralCalculations();

            //The final stretched height
            finalStretchedHeight = ClosestMod(desiredHeight, targetMod);
            //The final stretched width
            finalStretchedWidth = ClosestMod(Convert.ToDouble(finalStretchedHeight * trueWidth * stretchAspectRatioNum * originalHeight)
                / Convert.ToDouble(trueHeight * stretchAspectRatioDenum * originalWidth), targetMod);
            //The final stretched aspect ratio
            finalStretchedAspectRatio = Convert.ToDouble(finalStretchedWidth) / Convert.ToDouble(finalStretchedHeight);

            finalStretchedPixels = finalStretchedWidth * finalStretchedHeight;

            //The aspect ratio error in %
            errorStretchedAspectRatio = (Math.Abs(finalStretchedAspectRatio - trueStretchedAspectRatio)
                / Convert.ToDouble(trueStretchedAspectRatio)) * 100.0;
        }

        /// <summary>
        /// Calculates the original and after crop dimensions
        /// regardless of the resize procedure
        /// </summary>
        private void GeneralCalculations()
        {
            //The total pixels of the original video frame
            originalPixels = originalWidth * originalHeight;
            //The dimensions of the cropped video frame
            trueWidth = originalWidth - (cropX1 + cropX2);
            trueHeight = originalHeight - (cropY1 + cropY2);

            //The total pixels of the cropped video frame
            truePixels = trueWidth * trueHeight;
            //The original aspect ratio
            originalAspectRatio = Convert.ToDouble(originalWidth) / Convert.ToDouble(originalHeight);
            //The aspect ratio of the cropped video frame
            trueAspectRatio = Convert.ToDouble(trueWidth) / Convert.ToDouble(trueHeight);

            trueStretchedWidth = trueWidth;
            //The aspect ratio of the cropped video frame after the stretch
            trueStretchedAspectRatio = Convert.ToDouble(trueWidth * originalHeight * stretchAspectRatioNum)
                / Convert.ToDouble(trueHeight * originalWidth * stretchAspectRatioDenum);
            trueStretchedHeight = Convert.ToInt64(Convert.ToDouble(trueHeight * originalWidth * stretchAspectRatioDenum)
                / Convert.ToDouble(originalHeight * stretchAspectRatioNum));
        }

        /// <summary>
        /// Calculates the dimensions for the anamorphic resize
        /// </summary>
        public void CalculateAnamorphicValues()
        {
            encAnamWidth = ClosestMod(trueWidth, targetMod);
            encAnamHeight = ClosestMod(trueHeight, targetMod);
            encAnamPixels = encAnamWidth * encAnamHeight;

            encAnamAspectRatio = Convert.ToDouble(encAnamWidth) / Convert.ToDouble(encAnamHeight);

            finalAnamHeight = encAnamHeight;

            finalAnamWidth = Convert.ToInt64(AcHelper.Round(Convert.ToDouble(trueWidth * finalAnamHeight * stretchAspectRatioNum * originalHeight)
                / Convert.ToDouble(trueHeight * stretchAspectRatioDenum * originalWidth), 0));

            finalAnamAspectRatio = Convert.ToDouble(finalAnamWidth) / Convert.ToDouble(finalAnamHeight);
            
            anamPixels = encAnamWidth * encAnamHeight;

            errorEncAnamAspectRatio = (Math.Abs(encAnamAspectRatio - trueAspectRatio)
                / Convert.ToDouble(trueAspectRatio)) * 100.0;

            errorFinalAnamAspectRatio = (Math.Abs(finalAnamAspectRatio - trueStretchedAspectRatio)
                / Convert.ToDouble(trueStretchedAspectRatio)) * 100.0;
        }

        /// <summary>
        /// Finds the number closest to one given that is mod x
        /// </summary>
        /// <param name="number">the number </param>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static Int64 ClosestMod(Double number, Int64 mod)
        {
            Int64 down = Convert.ToInt64(Math.Ceiling(number / Convert.ToDouble(mod))) * mod;
            Int64 up = Convert.ToInt64(Math.Floor(number / Convert.ToDouble(mod))) * mod;
            Double difDown = Math.Abs(Convert.ToDouble(down) - number);
            Double difUp = Math.Abs(Convert.ToDouble(up) - number);

            if (difDown > difUp)
            {
                return (up);
            }
            else
            {
                return (down);
            }
        }

    }
}

