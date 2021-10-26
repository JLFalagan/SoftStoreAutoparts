using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace SoftStoreAutoparts.Dto
{
    public class TechnicalDataDto : BaseEntityNotifyDto<long>
    {
        public string Magnitude { get; set; }
        public string DataValue { get; set; }
        public string Unit { get; set; }
    }
}
