using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class ProductDto : BaseTypeDto<long>
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
        public virtual ProductBrandDto Brand { get; set; }

        public long TypeId { get; set; }
        public virtual ProductTypeDto Type { get; set; }

        public long ColorId { get; set; }
        public virtual ProductColorDto Color { get; set; }

        public virtual IList<ProductImageDto> Images { get; set; }
        public virtual IList<TechnicalDataDto> TechnicalDatas { get; set; }
        public virtual IList<ProductSourceDto> Shelves { get; set; }
        public virtual IList<ProductVehicleDto> Vehicles { get; set; }
}
}
