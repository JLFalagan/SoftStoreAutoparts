using Common.Extension;
using Common.Model.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Log
{
    public class EntityEventLog : AuditEntity
    {
        public EntityEventLog()
        {
        
        }

        public EntityEventLog(long typeId, string entityType, long entityId, string machineName, string description = null)
        {
            this.TypeId = typeId;
            this.EntityType = entityType;
            this.EntityId = entityId;
            this.Description = description;
            this.MachineName = machineName;
        }

        public EntityEventLog(long typeId, AuditEntity entity, string machineName, string description = null)
        {
            this.TypeId = typeId;
            this.EntityType = entity.GetDiscriminatorFromType();
            this.EntityId = entity.Id;
            this.Description = description;
            this.MachineName = machineName;
        }

        //public virtual long UserId { get; set; }
        //public virtual UserApp User { get; set; }

        public string MachineName { get; set; }

        public long TypeId { get; set; }
        public virtual EventLogType Type { get; set; }
        public string TypeName { get { return Type.Name; } }

        public string EntityType { get; set; }
        public long EntityId { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(1024)]
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }

        public string OldValues { get; set; }

        public string NewValues { get; set; }

    }
}

    
