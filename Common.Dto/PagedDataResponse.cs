using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Dto
{
    public class PagedDataResponse<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public IList<T> Results { get; set; }
    }
}