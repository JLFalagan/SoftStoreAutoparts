using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("Product")]
    public class Product : BaseType
    {
        public string Description { get; set; }
        public int Stock { get; set; }
        public string Code { get; set; }

        //Costs
        public double PricePurchase { get; set; }
        public double Gain { get; set; }
        public double TotalWithIVA { get; set; }
        public double TotalOutWithIVA { get; set; }

        public long BrandId { get; set; }
        public virtual ProductBrand Brand { get; set; }

        public long TypeId { get; set; }
        public virtual ProductType Type { get; set; }

        public long ColorId { get; set; }
        public virtual ProductColor Color { get; set; }

        public virtual IList<ProductImage> Images { get; set; }
        public virtual IList<TechnicalData> TechnicalDatas { get; set; }
        public virtual IList<ProductSource> Shelves { get; set; }
        public virtual IList<ProductVehicle> Vehicles { get; set; }
    }
}
