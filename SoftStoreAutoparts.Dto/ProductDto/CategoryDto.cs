using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class CategoryDto : BaseTypeDto<long>
    {
        public CategoryDto()
        {
            ProductTypes = new List<ProductTypeDto>();
        }

        public virtual IList<ProductTypeDto> ProductTypes { get; set; }
    }
}
