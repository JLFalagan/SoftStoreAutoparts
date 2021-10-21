using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("ProductBrand")]
    public class ProductBrand : BaseType
    {
        public ProductBrand()
        {
            Products = new List<Product>();
        }

        public virtual IList<Product> Products { get; set; }
    }
}
