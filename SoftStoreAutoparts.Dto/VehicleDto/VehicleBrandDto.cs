using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class VehicleBrandDto : BaseTypeDto<long>
    {
        public VehicleBrandDto()
        {
            Vehicles = new List<VehicleDto>();
        }

        public byte[] FileImageBrand { get; set; }

        public virtual IList<VehicleDto> Vehicles { get; set; }
    }
}
