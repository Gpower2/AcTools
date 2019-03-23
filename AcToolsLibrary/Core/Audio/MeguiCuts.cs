using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using AcToolsLibrary.Common;

namespace AcToolsLibrary.Core.Audio
{
    public class CutSection : IComparable<CutSection>
    {
        public int startFrame = -1;
        public int endFrame = -1;

        #region IComparable<CutSection> Members

        public int CompareTo(CutSection other)
        {
            if (other == this)
            {
                return 0;
            }
            if (other.startFrame == this.startFrame)
            {
                throw new AcException("Sections overlap!");
            }
            if (other.startFrame < this.startFrame)
            {
                if (other.endFrame < this.startFrame)
                {
                    return 1;
                }
                else
                {
                    throw new AcException("Sections overlap!");
                }
            }
            return 0 - other.CompareTo(this);
        }

        #endregion 
    }

    public enum TransitionStyle
    {
        NO_TRANSITION,
        FADE,
        DISSOLVE
    }

    [XmlRoot(ElementName = "Cuts")] 
    public class MeguiCuts
    {
        private List<CutSection> _cuts = new List<CutSection>();
        private TransitionStyle _style = TransitionStyle.NO_TRANSITION;
        
        public Decimal Framerate = -1;

        public TransitionStyle Style {
            get { return _style; }
            set { _style = value; }
        }

        public List<CutSection> AllCuts
        {
            get { return _cuts; }
            set { _cuts = value; }
        }

        public ulong TotalFrames
        {
            get
            {
                ulong ans = 0;
                foreach (CutSection c in AllCuts)
                {
                    ans += (ulong)(c.endFrame - c.startFrame);
                }
                return ans;
            }
        }

        public int MinimumLength
        {
            get
            {
                if (_cuts.Count == 0) throw new Exception("Must have at least one cut!");
                return _cuts[_cuts.Count - 1].endFrame;
            }
        }

        public MeguiCuts() { }

        public MeguiCuts(TransitionStyle style)
        {
            this.Style = style;
        }

        public MeguiCuts Clone()
        {
            MeguiCuts copy = new MeguiCuts(Style);
            copy._cuts = new List<CutSection>(_cuts);
            copy.Framerate = this.Framerate;
            return copy;
        }

        public bool AddSection(CutSection cut)
        {
            List<CutSection> old = new List<CutSection>(_cuts);
            _cuts.Add(cut);
            try
            {
                try
                {
                    _cuts.Sort();
                }
                catch (InvalidOperationException e)
                { 
                    throw e.InnerException; 
                }
            }
            catch (Exception) 
            { 
                _cuts = old; 
                return false; 
            }

            return true;
        }

        public void RemoveSection(CutSection cutSection)
        {
            _cuts.Remove(cutSection);
        }

        public void ClearSections()
        {
            _cuts.Clear();
        }

        public void AdaptToFramerate(Decimal newFramerate)
        {
            Decimal ratio = newFramerate / Framerate;
            foreach (CutSection c in _cuts)
            {
                c.startFrame = (int)((Decimal)c.startFrame * ratio);
                c.endFrame = (int)((Decimal)c.endFrame * ratio);
            }
            Framerate = newFramerate;
        }
    }
}
