﻿using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("Segment")]
    public class Segment : BaseType
    {
        public string Information { get; set; }
    }
}
