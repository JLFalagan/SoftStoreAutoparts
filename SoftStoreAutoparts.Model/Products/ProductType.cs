using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("ProductType")]
    public class ProductType : BaseType
    {
        public ProductType()
        {
            Products = new List<Product>();
        }

        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
