using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.API.Models
{
    public class TestClassModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int Record { get; set; }
    }
}
