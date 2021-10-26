using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class ProductColorDto : BaseTypeDto<long>
    {
        public string CodeColor { get; set; }
        public byte[] FileImageColor { get; set; }
    }
}
