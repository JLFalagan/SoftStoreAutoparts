using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    [Table("Hall")]
    public class Hall : BaseType
    {
        public Hall()
        {
            Shelves = new List<Shelf>();
        }

        public virtual IList<Shelf> Shelves { get; set; }
    }
}
