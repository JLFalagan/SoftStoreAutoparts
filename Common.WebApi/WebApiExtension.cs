using Common.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.WebApi
{
    public static class WebApiExtension
    {
        public static PagedDataResult ToPagedDataResult<T>(this PagedDataResponse<T> response) where T : class
        {
            var intance = new PagedDataResult()
            {
                PageCount = response.PageCount,
                PageIndex = response.PageIndex,
                RowCount = response.RowCount,
                Results = response.Results
            };

            return intance;
        }
    }
}
