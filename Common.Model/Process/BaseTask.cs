using NeyTI.Core.Model.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Process
{
    public abstract class BaseTask : AuditEntity
    {

        public BaseTask()
        {
            StateId = TaskState.CreatedId;
        }

        public long? ArgumentsId { get; set; }
        public virtual BaseTaskArgs Arguments { get; set; }

        /// <summary>
        /// Nombre de la instancia del proceso
        /// </summary>
        [Column(TypeName = "VARCHAR")]
        public virtual string Name { get; set; }
        /// <summary>
        /// Porcentaje de completado
        /// </summary>
        public virtual decimal Progress { get; set; }
        /// <summary>
        /// Iniciar
        /// </summary>
        public virtual DateTime? ScheduleStart { get; set; }
        public virtual DateTime? FirstExecutionTime { get; set; }
        /// <summary>
        /// Inicio (real)
        /// </summary>
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// Finalizo
        /// </summary>
        public virtual DateTime? EndTime { get; set; }
        public virtual TimeSpan Duration
        {
            get
            {
                if (!StartTime.HasValue)
                    return default(TimeSpan);

                return EndTime.HasValue ? EndTime.Value - StartTime.Value : Updated.Value - StartTime.Value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "VARCHAR")]
        public virtual string Comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual long StateId { get; set; }
        public virtual TaskState State { get; set; }

        public string StateName
        {
            get { return State.Name; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "VARCHAR(MAX)")]
        public virtual string ExceptionDetails { get; set; }

        
    }
}
