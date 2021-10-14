using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Dto
{
    public class PagingSortFilterRequest : BaseRequest
    {
        public PagingSortFilterRequest()
        {
            OnlyEnabled = true;
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string FilterBy { get; set; }

        public string FilterValue { get; set; }

        public string OrderBy { get; set; }

        public bool OnlyEnabled { get; set; }

    }
}