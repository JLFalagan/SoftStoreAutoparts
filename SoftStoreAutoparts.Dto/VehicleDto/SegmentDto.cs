﻿using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Dto
{
    public class SegmentDto : BaseTypeDto<long>
    {
        public string Information { get; set; }
    }
}
