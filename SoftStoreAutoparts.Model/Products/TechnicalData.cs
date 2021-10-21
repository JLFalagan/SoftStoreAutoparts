using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("TechnicalData")]
    public class TechnicalData : BaseEntity
    {
        public string Magnitude { get; set; }
        public string DataValue { get; set; }
        public string Unit { get; set; }
    }
}
