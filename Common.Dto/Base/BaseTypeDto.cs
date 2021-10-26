using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public abstract class BaseTypeDto<T> : BaseEntityNotifyDto<T>, INamedEntity
    {
        public BaseTypeDto() : base()
        {
            EnableName = false;
        }

        public BaseTypeDto(bool enableNotify = false)
        {
            EnableName = enableNotify;
        }

        public bool EnableName { private get; set; }
        public virtual string Name { get; set; }
    }
}