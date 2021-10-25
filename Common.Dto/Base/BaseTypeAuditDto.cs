using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto.Base
{
    public abstract class BaseTypeAuditDto<T> : AuditEntityDto<T>
    {
        public BaseTypeAuditDto() : base()
        {
            EnableName = false;
        }

        public BaseTypeAuditDto(bool enableNotify = false) : base(enableNotify)
        {
            EnableName = enableNotify;
        }

        public BaseTypeAuditDto(bool enableNotify = false, bool enableBaseNotify = false) : base(enableBaseNotify)
        {
            EnableName = enableNotify;
        }

        public bool EnableName { private get; set; }
        public virtual string Name { get; set; }
    }
}
