using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("ProductVehicle")]
    public class ProductVehicle : BaseEntity
    {
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
