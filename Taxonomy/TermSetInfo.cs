using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOMChanged
{
    public class TermSetInfo
    {
        private string _name;
        private Guid _termSetId;
        private List<TermInfo> _termInfos;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public List<TermInfo> TermInfos
        {
            get
            {
                return _termInfos;
            }
            set
            {
                _termInfos = value;
            }
        }

        public Guid TermSetId
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

        public TermSetInfo()
        {
            TermInfos = new List<TermInfo>();
        }
    }
}
