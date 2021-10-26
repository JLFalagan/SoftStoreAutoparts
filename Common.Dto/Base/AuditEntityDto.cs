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
        public AuditEntityDto() : base()
        {
            EnableNotifyAuditAll(false);
        }

        public AuditEntityDto(bool enableNotify = false)
        {
            EnableNotifyAuditAll(enableNotify);
        }

        public virtual void EnableNotifyAuditAll(bool enableNotify)
        {
            EnableCreatedBy = enableNotify;
            EnableUpdatedBy = enableNotify;
            EnableDeletedBy = enableNotify;
            EnableCreated = enableNotify;
            EnableUpdated = enableNotify;
            EnableDeleted = enableNotify;
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
