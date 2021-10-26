using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class HallDto : BaseTypeDto<long>
    {
        public HallDto()
        {
            Shelves = new List<ShelfDto>();
        }

        public virtual IList<ShelfDto> Shelves { get; set; }
    }
}
