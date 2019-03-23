using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace AcTools.Core
{
    public sealed class AcSettings
    {
        #region "Singleton pattern"
        private static AcSettings instance = null;

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static AcSettings() { }
        AcSettings() { }

        [XmlIgnore]
        public static AcSettings Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region "Properties"

        private Int32 _FormBackColor = Color.LightSteelBlue.ToArgb();
        private Int32 _EnabledControlBackColor = Color.AliceBlue.ToArgb();
        private Int32 _DisabledControlBackColor = Color.LightSteelBlue.ToArgb();
        private Int32 _ReadOnlyControlBackColor = Color.LightSteelBlue.ToArgb();
        private FlatStyle _ControlFlatStyle = FlatStyle.System;
        private String _FontName = "Segoe UI";
        private float _FontSize = 9F;
        private Boolean _FontBold = false;
        private Boolean _FontItalic = false;
        private Boolean _FontUnderline = false;
        private Boolean _FontStrikeout = false;
        private Font _Font = null;

        public String FontName { get { return _FontName; } set { _FontName = value; } }
        public float FontSize { get { return _FontSize; } set { _FontSize = value; } }
        public Boolean FontBold { get { return _FontBold; } set { _FontBold = value; } }
        public Boolean FontItalic { get { return _FontItalic; } set { _FontItalic = value; } }
        public Boolean FontUnderline { get { return _FontUnderline; } set { _FontUnderline = value; } }
        public Boolean FontStrikeout { get { return _FontStrikeout; } set { _FontStrikeout = value; } }

        [XmlIgnore]
        public Font MyFont
        {
            get
            {
                FontStyle test = FontStyle.Regular;
                if (_FontBold)
                {
                    test = FontStyle.Bold;
                }
                if (_FontItalic)
                {
                    test |= FontStyle.Italic;
                }
                if (_FontUnderline)
                {
                    test |= FontStyle.Underline;
                }
                if (_FontStrikeout)
                {
                    test |= FontStyle.Strikeout;
                }
                _Font = new Font(_FontName, _FontSize, test);
                return _Font;
            }
        }
        public Int32 FormBackColor
        {
            get { return _FormBackColor; }
            set { _FormBackColor = value; }
        }
        public Int32 EnabledControlBackColor
        {
            get { return _EnabledControlBackColor; }
            set { _EnabledControlBackColor = value; }
        }
        public Int32 DisabledControlBackColor
        {
            get { return _DisabledControlBackColor; }
            set { _DisabledControlBackColor = value; }
        }
        public Int32 ReadOnlyControlBackColor
        {
            get { return _ReadOnlyControlBackColor; }
            set { _ReadOnlyControlBackColor = value; }
        }
        public FlatStyle ControlFlatStyle {
            get { return _ControlFlatStyle; }
            set { _ControlFlatStyle = value; }
        }
        #endregion

        private static String _SettingsFileName = "setings.xml";
        private static String getFilename()
        {
            return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), _SettingsFileName);
        }

        public static void Reset()
        {
            instance = new AcSettings();
        }

        public static void Load()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(AcSettings));
            if (File.Exists(getFilename()))
            {
                try
                {
                    using (TextReader textReader = new StreamReader(getFilename(), Encoding.UTF8))
                    {
                        instance = (AcSettings)deserializer.Deserialize(textReader);
                    }
                }
                catch (Exception ex)
                {
                    //Debug write the message
                    Debug.WriteLine(ex);
                    //Overwrite the corrupted settings
                    instance = new AcSettings();
                    Save();
                }
            }
            else
            {
                instance = new AcSettings();
                Save();
            }
        }

        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AcSettings));
            using (TextWriter textWriter = new StreamWriter(getFilename(), false, Encoding.UTF8))
            {
                serializer.Serialize(textWriter, instance);
            }
        }
    }
}
