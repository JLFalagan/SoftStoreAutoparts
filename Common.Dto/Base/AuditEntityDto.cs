using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public abstract class AuditEntityDto<T> : BaseEntityNotifyDto<T>
    {
        //Constructor Default, con las notificaciones this y base deshabilitadas
        public AuditEntityDto() : base()
        {
            EnableCreatedBy = false;
            EnableUpdatedBy = false;
            EnableDeletedBy = false;
            EnableCreated = false;
            EnableUpdated = false;
            EnableDeleted = false;
        }

        //Constructor con las notificaciones this y base habilitadas
        public AuditEntityDto(bool enableNotify = false) : base(enableNotify)
        {
            EnableCreatedBy = enableNotify;
            EnableUpdatedBy = enableNotify;
            EnableDeletedBy = enableNotify;
            EnableCreated = enableNotify;
            EnableUpdated = enableNotify;
            EnableDeleted = enableNotify;
        }

        //Constructor con las notificaciones this y base habilitadas de manera independiente
        public AuditEntityDto(bool enableAuditNotify = false, bool enableBaseNotify = false) : base(enableBaseNotify)
        {
            EnableCreatedBy = enableAuditNotify;
            EnableUpdatedBy = enableAuditNotify;
            EnableDeletedBy = enableAuditNotify;
            EnableCreated = enableAuditNotify;
            EnableUpdated = enableAuditNotify;
            EnableDeleted = enableAuditNotify;
        }

        public void EnableNotify(bool enableAuditNotify = false, bool enableBaseNotify = false)
        {
            base.EnableNotifyGuid = enableBaseNotify;
            base.EnableNotifyEnabled = enableBaseNotify;
            base.EnableNotifyIsNew = enableBaseNotify;
            base.EnableNotifyDisplay = enableBaseNotify;

            EnableCreatedBy = enableAuditNotify;
            EnableUpdatedBy = enableAuditNotify;
            EnableDeletedBy = enableAuditNotify;
            EnableCreated = enableAuditNotify;
            EnableUpdated = enableAuditNotify;
            EnableDeleted = enableAuditNotify;
        }

        //[JsonIgnore]
        //public override Guid Guid { get; set; }

        private string createdBy;
        private string updatedBy;
        private string deletedBy;
        private DateTime created;
        private DateTime? updated;
        private DateTime? deleted;

        public bool EnableCreatedBy { private get; set; }
        public virtual string CreatedBy 
        {
            get => createdBy;
            set
            {
                if (value != createdBy && EnableCreatedBy)
                {
                    createdBy = value;
                    NotifyPropertyChanged();
                }
                else createdBy = value;
            }
        }

        public bool EnableUpdatedBy { private get; set; }
        public virtual string UpdatedBy
        {
            get => updatedBy;
            set
            {
                if (value != updatedBy && EnableUpdatedBy)
                {
                    updatedBy = value;
                    NotifyPropertyChanged();
                }
                else updatedBy = value;
            }
        }

        public bool EnableDeletedBy { private get; set; }
        public virtual string DeletedBy
        {
            get => deletedBy;
            set
            {
                if (value != deletedBy && EnableDeletedBy)
                {
                    deletedBy = value;
                    NotifyPropertyChanged();
                }
                else deletedBy = value;
            }
        }

        public bool EnableCreated { private get; set; }
        public virtual DateTime Created
        {
            get => created;
            set
            {
                if (value != created && EnableCreated)
                {
                    created = value;
                    NotifyPropertyChanged();
                }
                else created = value;
            }
        }

        public bool EnableUpdated { private get; set; }
        public virtual DateTime? Updated
        {
            get => updated;
            set
            {
                if (value != updated && EnableUpdated)
                {
                    updated = value;
                    NotifyPropertyChanged();
                }
                else updated = value;
            }
        }

        public bool EnableDeleted { private get; set; }
        public virtual DateTime? Deleted
        {
            get => deleted;
            set
            {
                if (value != deleted && EnableDeleted)
                {
                    deleted = value;
                    NotifyPropertyChanged();
                }
                else deleted = value;
            }
        }
    }
}
