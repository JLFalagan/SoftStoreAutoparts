using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("VehicleBrand")]
    public class VehicleBrand : BaseType
    {
        public VehicleBrand()
        {
            Vehicles = new List<Vehicle>();
        }

        public byte[] FileImageBrand { get; set; }

        public virtual IList<Vehicle> Vehicles { get; set; }
    }
}
