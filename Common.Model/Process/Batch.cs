using Common.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Process
{
    public class Batch : AuditEntity
    {
        public Batch()
        {
            Items = new List<BatchItem>();
        }

        [Column(TypeName = "VARCHAR"), StringLength(256)]
        public string Name { get; set; }

        public virtual IList<BatchItem> Items { get; set; }
    }
}
