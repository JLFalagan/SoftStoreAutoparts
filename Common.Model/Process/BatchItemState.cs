using NeyTI.Core.Model.Entities;

namespace Common.Model.Process
{
    public class BatchItemState : BaseType
    {
        public const long PendingId = 1;
        public const long ProcessedId = 2;
        public const long FailedId = 3;
    }
}
