using Common.Model.Entities;

namespace Common.Model.Process
{
    public class BatchItemState : BaseTypeAudit
    {
        public const long PendingId = 1;
        public const long ProcessedId = 2;
        public const long FailedId = 3;
    }
}
