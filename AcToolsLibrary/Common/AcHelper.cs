using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AcToolsLibrary.Common
{
    public enum GetFileNameMode
    {
        FullFilename,
        FilenameWithoutExtension,
        ExtensionOnly,
        NoFileName
    }

    public enum GetDirectoryNameMode
    {
        FullPath,
        NoPath
    }

    public class AcHelper
    {
        /// <summary>
        /// CultureInfo.InvariantCulture
        /// </summary>
        public static CultureInfo INV_CULTURE = CultureInfo.InvariantCulture;

        /// <summary>
        /// Function which converts a String to Double, 
        /// regardless of the decimal character used (',' or '.')
        /// </summary>
        /// <param name="argString">
        /// The String to be converted
        /// </param>
        /// <returns>
        /// The converted double
        /// </returns>
        public static Double DoubleParse(String argString)
        {
            if (String.IsNullOrWhiteSpace(argString))
            {
                return Double.NaN;
            }
            return Double.Parse(PrepareStringForNumericParse(argString), NumberStyles.Any, INV_CULTURE);
        }

        public static Decimal DecimalParse(String argString)
        {
            if (String.IsNullOrWhiteSpace(argString))
            {
                return Decimal.MinValue;
            }
            return Decimal.Parse(PrepareStringForNumericParse(argString), NumberStyles.Any, INV_CULTURE);
        }

        public static String PrepareStringForNumericParse(String argString)
        {
            if (argString.Contains("."))
            {
                // if it's more than one, then the '.' is definetely a thousand separator
                if (argString.Count(s => s == '.') > 1)
                {
                    // Remove the thousand separator and replace the decimal point separator
                    return argString.Replace(".", String.Empty).Replace(",", ".");
                }
                else if (argString.Contains(","))
                {
                    // if it also contains ',' check to see which is first
                    if (argString.IndexOf(",") < argString.IndexOf("."))
                    {
                        // if the ',' is before the '.', then the thousand separator is ','
                        // Remove the thousand separator and leave the decimal point separator
                        return argString.Replace(",", String.Empty);
                    }
                    else
                    {
                        // if the ',' is after the '.', then the thousand separator is '.'
                        // Remove the thousand separator and replace the decimal point separator
                        return argString.Replace(".", String.Empty).Replace(",", ".");
                    }
                }
                else
                {
                    // if we have only a '.' present, we assume it is a decimal point separator
                    // let it be
                    return argString;
                }
            }
            else if (argString.Contains(","))
            {
                // if it's more than one, then the ',' is definetely a thousand separator
                if (argString.Count(s => s == ',') > 1)
                {
                    // Remove the thousand separator and leave the decimal point separator
                    return argString.Replace(",", String.Empty);
                }
                else
                {
                    // if we have only a ',' present, we assume it is a decimal point separator
                    // Replace the decimal point separator
                    return argString.Replace(",", ".");
                }
            }
            else
            {
                // if neither '.' or ',' are found, then return the string as is
                return argString;
            }
        }

        /// <summary>
        /// Function which converts a Double to a String
        /// using a specified format
        /// </summary>
        /// <param name="argDouble">the double to convert</param>
        /// <param name="argFormat">the format for the conversion</param>
        /// <returns>The converted string</returns>
        public static String DoubleToString(Double argDouble, String argFormat = "#0.0#####")
        {
            return argDouble.ToString(argFormat, INV_CULTURE);
        }

        public static String DecimalToString(Decimal argDecimal, String argFormat = "#0.0#####")
        {
            return argDecimal.ToString(argFormat, INV_CULTURE);
        }

        /// <summary>
        /// Function to return a part of a filename String
        /// </summary>
        /// <param name="argFilename">the original filename</param>
        /// <param name="argFilenameMode">the file name part</param>
        /// <param name="argDirnameMode">the directory part</param>
        /// <returns>the desired part of the filename</returns>
        public static String GetFilename(String argFilename, GetFileNameMode argFilenameMode, GetDirectoryNameMode argDirnameMode)
        {
            if (argFilenameMode == GetFileNameMode.NoFileName)
            {
                //return argFilename.Substring(0, argFilename.LastIndexOf("\\") + 1);
                return Path.GetDirectoryName(argFilename);
            }

            if (argFilenameMode == GetFileNameMode.ExtensionOnly)
            {
                //return argFilename.Substring(argFilename.LastIndexOf(".") + 1);
                String fileExt = Path.GetExtension(argFilename);
                if (fileExt.Length > 1 && fileExt.StartsWith("."))
                {
                    return fileExt.Substring(1);
                }
                else
                {
                    return fileExt;
                }
            }

            if (argDirnameMode == GetDirectoryNameMode.FullPath)
            {
                if (argFilenameMode == GetFileNameMode.FullFilename)
                {
                    return argFilename;
                }
                else if (argFilenameMode == GetFileNameMode.FilenameWithoutExtension)
                {
                    //if (argFilename.Contains("."))
                    //{
                    //    return argFilename.Substring(0, argFilename.LastIndexOf("."));
                    //}
                    //else
                    //{
                    //    return argFilename;
                    //}
                    return Path.Combine(Path.GetDirectoryName(argFilename), Path.GetFileNameWithoutExtension(argFilename));
                }
            }
            else if (argDirnameMode == GetDirectoryNameMode.NoPath)
            {
                if (argFilenameMode == GetFileNameMode.FullFilename)
                {
                    //return argFilename.Substring(argFilename.LastIndexOf("\\") + 1);
                    return Path.GetFileName(argFilename);
                }
                else if (argFilenameMode == GetFileNameMode.FilenameWithoutExtension)
                {
                    //if (argFilename.Contains("."))
                    //{
                    //    return argFilename.Substring(argFilename.LastIndexOf("\\") + 1, argFilename.LastIndexOf("."));
                    //}
                    //else
                    //{
                    //    return argFilename.Substring(argFilename.LastIndexOf("\\") + 1);
                    //}
                    return Path.GetFileNameWithoutExtension(argFilename);
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the last filename that does not exist as a file
        /// from an original one replacing its extension
        /// e.g. file.avi -> file.001.avs
        /// </summary>
        /// <param name="argFilename">the original filename</param>
        /// <param name="argNewExtension">the extension of the replaced filename without the dot "."</param>
        /// <param name="argNumDigits">the number of digits for the counter</param>
        /// <returns>the replaced last unused filename</returns>
        public static String GetLastUnusedFilename(String argFilename, String argNewExtension, Int32 argNumDigits)
        {
            StringBuilder filenameBuilder = new StringBuilder();
            filenameBuilder.AppendFormat("{0}.{1}",
                GetFilename(argFilename, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath),
                argNewExtension);
            Int32 filenameCounter = 0;
            while (File.Exists(filenameBuilder.ToString()))
            {
                filenameBuilder.Length = 0;
                filenameBuilder.AppendFormat("{0}.{1}.{2}",
                    GetFilename(argFilename, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath),
                    filenameCounter.ToString().PadLeft(argNumDigits, '0'),
                    argNewExtension);
                filenameCounter++;
            }
            return filenameBuilder.ToString();
        }

        /// <summary>
        /// Returns an Encoding which contains a string in name
        /// </summary>
        /// <param name="argEncodingName"></param>
        /// <returns>if encoding not found, returns utf8, otherwise the first encoding it finds</returns>
        public static Encoding FindEncoding(String argEncodingName)
        {
            Int32 codePage = Encoding.GetEncodings().Where(e => e.Name.ToLower()
                .Replace("_", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty)
                .Contains(argEncodingName.ToLower()
                .Replace("_", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty)))
                .Select(x => x.CodePage).DefaultIfEmpty(Encoding.UTF8.CodePage).First();
            return Encoding.GetEncoding(codePage);
        }

        public static Encoding GetUTF8EncodingWithBom()
        {
            return new UTF8Encoding(true);
        }

        public static Encoding GetUTF8EncodingWithoutBom()
        {
            return new UTF8Encoding(false);
        }

        /// <summary>
        /// Returns a Double with a specified accuracy
        /// </summary>
        /// <param name="argNumber">the double to round</param>
        /// <param name="argDecimals">number of decimal digits</param>
        /// <returns>the rounded double</returns>
        public static Double Round(Double argNumber, Int32 argDecimals = 3)
        {
            return Math.Round(argNumber, argDecimals, MidpointRounding.AwayFromZero);
        }

        public static Decimal Round(Decimal argNumber, Int32 argDecimals = 3)
        {
            return Decimal.Round(argNumber, argDecimals, MidpointRounding.AwayFromZero);
        }
    }
}
