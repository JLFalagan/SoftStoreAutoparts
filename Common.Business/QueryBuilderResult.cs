using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    public class QueryBuilderResult<T> where T : class
    {
        /// <summary>
        /// For pagging use
        /// </summary>
        public int RowCount { get; set; }
        public IQueryable<T> Query { get; set; }
    }
}
