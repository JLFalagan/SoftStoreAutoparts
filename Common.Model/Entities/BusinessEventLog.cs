using Common.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Entities
{
    public class BusinessEventLog : AuditEntity
    {
        public BusinessEventLog()
        {
        }

        public BusinessEventLog(long typeId, AuditEntity entity, string subject, string description, string machineName)
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

        /// <summary>
        /// Metodo o Proceso que genera el evento
        /// </summary>
        [Column(TypeName = "VARCHAR"), StringLength(256)]
        public string Subject { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(1024)]
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
