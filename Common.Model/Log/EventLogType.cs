using Common.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Log
{
    public class EventLogType : BaseTypeAudit
    {
        public const long UnknownId = 1;
        public const long AddedId = 4;
        public const long DeletedId = 8;
        public const long ModifiedId = 16;
        public const long ErrorId = 26;
        public const long InformationId = 64;
        public const long WarningId = 48;

        public EventLogType()
        {
        }

        public EventLogType(string name) : base(name)
        {
            
        }

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

        public override string ToString()
        {
            return Name;
        }
    }
}
