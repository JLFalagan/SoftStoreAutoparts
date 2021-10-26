using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace SoftStoreAutoparts.Dto
{
    public class VehicleDto : BaseEntityNotifyDto<long>
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Doors { get; set; }
        public string Description { get; set; }

        public long BrandId { get; set; }
        public virtual VehicleBrandDto Brand { get; set; }

        public long TypeId { get; set; }
        public virtual VehicleTypeDto Type { get; set; }

        public long SegmentId { get; set; }
        public virtual SegmentDto Segment { get; set; }
    }
}
