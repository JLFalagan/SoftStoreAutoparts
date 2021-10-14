using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Process
{
    public class TaskEventArgs : EventArgs
    {
        public long TaskId { get; set; }
        public string EventName { get; set; } /* Completed, Canceled, ProgressChanged, Faulted */
    }
}
