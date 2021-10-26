using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class ProductVehicleDto : BaseEntityDto<long>
    {
        public long ProductId { get; set; }
        public virtual ProductDto Product { get; set; }

        public long VehicleId { get; set; }
        public virtual VehicleDto Vehicle { get; set; }
    }
}
