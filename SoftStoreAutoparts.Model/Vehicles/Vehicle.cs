using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("Vehicle")]
    public class Vehicle : BaseEntity
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Doors { get; set; }
        public string Description { get; set; }

        public long BrandId { get; set; }
        public virtual VehicleBrand Brand { get; set; }

        public long TypeId { get; set; }
        public virtual VehicleType Type { get; set; }

        public long SegmentId { get; set; }
        public virtual Segment Segment { get; set; }
    }
}
