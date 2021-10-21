using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("ProductSource")]
    public class ProductSource : BaseEntity
    {
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public long ShelfId { get; set; }
        public virtual Shelf Shelf { get; set; }
    }
}
