using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class ShelfDto : BaseTypeDto<long>
    {
        public ShelfDto()
        {
            Products = new List<ProductSourceDto>();
        }

        public long HallId { get; set; }
        public virtual HallDto Hall { get; set; }

        public virtual IList<ProductSourceDto> Products { get; set; }
    }
}
