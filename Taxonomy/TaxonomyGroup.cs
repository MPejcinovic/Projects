using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOMChanged
{
    public class TaxonomyGroup
    {
        private string _name;
        private Guid _id;
        private TermSetInfo _termset;

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

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public TermSetInfo TermSet
        {
            get
            {
                return _termset;
            }
            set
            {
                _termset = value;
            }
        }

        public TaxonomyGroup()
        {
            TermSet = new TermSetInfo();
        }

    }
}
