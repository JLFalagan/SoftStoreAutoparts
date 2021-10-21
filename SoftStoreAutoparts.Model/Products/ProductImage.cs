using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("ProductImage")]
    public class ProductImage : BaseType
    {
        public byte[] FileImage { get; set; }
    }
}
