using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class ProductTypeDto : BaseTypeDto<long>
    {
        public ProductTypeDto()
        {
            Products = new List<ProductDto>();
        }

        public long CategoryId { get; set; }
        public virtual CategoryDto Category { get; set; }

        public virtual IList<ProductDto> Products { get; set; }
    }
}
