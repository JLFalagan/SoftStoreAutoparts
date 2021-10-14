using Common.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Security
{
    public class AppUserAppRole : AuditEntity
    {
        public AppUserAppRole() : base()
        {
            
        }

        public long UserId { get; set; }
        public virtual AppUser User { get; set; }

        public long RoleId { get; set; }
        public virtual AppRole Role { get; set; }


        public string UserName => User?.UserName;
        public string UserDisplayName => User?.DisplayName;
        public string RoleName => Role?.Name;

        public override string ToString()
        {
            return this.Role.Name;
        }
    }
}
