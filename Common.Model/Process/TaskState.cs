using Common.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Process
{
    public class TaskState : BaseType
    {
        /// <summary>
        /// The task has been initialized but has not yet been scheduled.
        /// </summary>
        public const long CreatedId = 1;
        /// <summary>
        /// The task start is pending AKA WaitingForActivation or WaitingToRun
        /// Se cargo la tarea
        /// </summary>
        public const long PendingId = 2;
        /// <summary>
        /// The task is running but has not yet completed.
        /// </summary>
        public const long RunningId = 3;
        /// <summary>
        /// The task completed execution successfully. AKA RanToCompletion
        /// </summary>
        public const long CompletedId = 4;
        /// <summary>
        /// Task cancel request is pending
        /// </summary>
        public const long CancelPendingId = 5;
        /// <summary>
        /// The task acknowledged cancellation by throwing an OperationCanceledException 
        /// </summary>
        public const long CanceledId = 6;
        /// <summary>
        /// The task completed due to an unhandled exception.
        /// </summary>
        public const long FaultedId = 7;

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public override long Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }   
    }
}
