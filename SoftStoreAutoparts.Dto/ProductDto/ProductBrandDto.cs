using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class ProductBrandDto : BaseTypeDto<long>
    {
        public ProductBrandDto()
        {
            Products = new List<ProductDto>();
        }

        public virtual IList<ProductDto> Products { get; set; }
    }
}
