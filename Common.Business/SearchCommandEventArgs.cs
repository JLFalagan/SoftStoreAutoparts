using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    public class SearchCommandEventArgs : EventArgs
    {
        private IDictionary<string, string> _AdvanceFilters;
        public SearchCommandEventArgs()
        {
            OnlyEnabled = true;
            AdvanceFilters = new Dictionary<string, string>();
        }

        public string FilterValue { get; set; }
        public string FilterBy { get; set; }
        public string OrderBy { get; set; }
        public bool OnlyEnabled { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IDictionary<string, string> AdvanceFilters
        {
            get
            {
                if (_AdvanceFilters == null)
                    _AdvanceFilters = new Dictionary<string, string>();
                return _AdvanceFilters;
            }
            set
            { _AdvanceFilters = value; }
        }
    }
}
