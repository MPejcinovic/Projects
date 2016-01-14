using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOMChanged
{
    public class TermInfo
    {
        private Guid _termId;
        private string _termFormat;
        private string _termHref;
        private string _termName;
        private int _termOrder;
        private string _termSetId;
        private List<TermInfo> _childTermsInfos;


        public Guid TermId
        {
            get
            {
                return _termId;
            }
            set
            {
                _termId = value;
            }
        }

        public string TermFormat
        {
            get
            {
                return _termFormat;
            }
            set
            {
                _termFormat = value;
            }
        }

        public List<TermInfo> ChildTermInfos
        {
            get
            {
                return _childTermsInfos;
            }
            set
            {
                _childTermsInfos = value;
            }
        }

        public string TermHref
        {
            get
            {
                return _termHref;
            }
            set
            {
                _termHref = value;
            }
        }

        public string TermName
        {
            get
            {
                return _termName;
            }
            set
            {
                _termName = value;
            }
        }

        public int TermOrder
        {
            get
            {
                return _termOrder;
            }
            set
            {
                _termOrder = value;
            }
        }

        public string TermSetId
        {
            get
            {
                return _termSetId;
            }
            set
            {
                _termSetId = value;
            }
        }

        public TermInfo()
        {
            ChildTermInfos = new List<TermInfo>();
        }
    }
}
