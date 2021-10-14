using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Common.Model.Entities
{
    
    public abstract class AuditEntity : BaseEntity, INotifyPropertyChanged
    {

        public AuditEntity(bool disableDelete = false) : base(disableDelete)
        {
            Created = DateTime.Now;
        }


        //public virtual long? CreatorUserId { get; set; }
        //public virtual AppUser CreatorUser { get; set; }
        //public string CreatorUserName { get { return CreatorUser?.UserName; } }
        //public string CreatorUserName { get { return CreatedBy; } }

        [Column(TypeName = "VARCHAR"), StringLength(64)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "VARCHAR"), StringLength(64)]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "VARCHAR"), StringLength(64)]
        public string DeletedBy { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual DateTime? Updated { get; set; }

        public virtual DateTime? Deleted { get; set; }

        
    }
}
