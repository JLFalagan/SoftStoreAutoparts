using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("Category")]
    public class Category : BaseType
    {
        public Category()
        {
            ProductTypes = new List<ProductType>();
        }

        public virtual IList<ProductType> ProductTypes { get; set; }
    }
}
