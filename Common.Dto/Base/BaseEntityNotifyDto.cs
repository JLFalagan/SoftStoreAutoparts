using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public abstract class BaseEntityNotifyDto<T> : BaseNotifyDto<T>
    {
        public BaseEntityNotifyDto()
        {
            EnableNotifyAll(false);
        }

        public BaseEntityNotifyDto(bool enableNotify = false)
        {
            EnableNotifyAll(enableNotify);
        }

        public virtual void EnableNotifyAll(bool enableNotify)
        {
            EnableNotifyGuid = enableNotify;
            EnableNotifyEnabled = enableNotify;
            EnableNotifyIsNew = enableNotify;
            EnableNotifyDisplay = enableNotify;
        }

        public bool EnableNotifyGuid { private get; set; }
        public override Guid Guid 
        { 
            get => base.Guid;
            set
            {
                if (value != base.Guid && EnableNotifyGuid)
                {
                    base.Guid = value;
                    NotifyPropertyChanged();
                }
                else base.Guid = value;
            }
        }

        public bool EnableNotifyEnabled { private get; set; }
        public override bool Enabled
        {
            get => base.Enabled;
            set
            {
                if (value != base.Enabled && EnableNotifyEnabled)
                {
                    base.Enabled = value;
                    NotifyPropertyChanged();
                }
                else base.Enabled = value;
            }
        }

        public bool EnableNotifyIsNew { private get; set; }
        public override bool IsNew
        {
            get => base.IsNew;
            set
            {
                if (value != base.IsNew && EnableNotifyIsNew)
                {
                    base.IsNew = value;
                    NotifyPropertyChanged();
                }
                else base.IsNew = value;
            }
        }

        public bool EnableNotifyDisplay { private get; set; }
        public override string Display
        {
            get => base.Display;
            set
            {
                if (value != base.Display && EnableNotifyDisplay)
                {
                    base.Display = value;
                    NotifyPropertyChanged();
                }
                else base.Display = value;
            }
        }
    }
}
