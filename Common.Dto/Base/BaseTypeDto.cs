﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public abstract class BaseTypeDto<T> : BaseEntityNotifyDto<T>
    {
        public BaseTypeDto() : base()
        {
            EnableName = false;
        }

        public BaseTypeDto(bool enableNotify = false) : base(enableNotify)
        {
            EnableName = enableNotify;
        }

        public BaseTypeDto(bool enableNotify = false, bool enableBaseNotify = false) : base(enableBaseNotify)
        {
            EnableName = enableNotify;
        }

        public bool EnableName { private get; set; }
        public virtual string Name { get; set; }
    }
}