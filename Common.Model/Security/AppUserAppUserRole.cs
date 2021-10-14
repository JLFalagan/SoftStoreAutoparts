using Common.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Security
{
    /// <summary>
    /// Relacion Usuario de la aplicacion cn rol de la aplicacion
    /// </summary>
    public class AppUserAppUserRole : AuditEntity
    {
        public AppUserAppUserRole() : base()
        {
            
        }

        public long UserId { get; set; }
        public virtual AppUser User { get; set; }

        public long RoleId { get; set; }
        public virtual AppUserRole Role { get; set; }

        //public override bool IsNew
        //{
        //    get
        //    {
        //        return (UserId == 0 && RoleId == 0);
        //    }
        //}

        //[NotMapped]
        //public override long? CreatorUserId { get => base.CreatorUserId; set => base.CreatorUserId = value; }
        //[NotMapped]
        //public override AppUser CreatorUser { get => base.CreatorUser; set => base.CreatorUser = value; }

        public string UserName => User?.UserName;
        public string UserDisplayName => User?.DisplayName;
        public string RoleName => Role?.Name;

        public override string ToString()
        {
            return this.Role.Name;
        }
    }
}
