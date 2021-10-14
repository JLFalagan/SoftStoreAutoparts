using NeyTI.Core.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Process
{
    public abstract class BatchItem : AuditEntity
    {
        public BatchItem()
        {
            StateId = BatchItemState.PendingId;
        }

        public long ParentId { get; set; }
        public virtual Batch Parent { get; set; }

        public long StateId { get; set; }
        public virtual BatchItemState State { get; set; }

        [Column(TypeName = "VARCHAR")]
        public virtual string ExceptionDetails { get; set; }

    }
}
