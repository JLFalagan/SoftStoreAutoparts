using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("Shelf")]
    public class Shelf : BaseType
    {
        public Shelf()
        {
            Products = new List<ProductSource>();
        }

        public long HallId { get; set; }
        public virtual Hall Hall { get; set; }

        public virtual IList<ProductSource> Products { get; set; }
    }
}
