using NeyTI.Core.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Security
{
    public partial class AppUser : AuditEntity
    {
        public AppUser() : base()
        {
            UserRoles = new List<AppUserAppUserRole>();
        }

        public const long Clear = 1;
        public const long Encrypted = 2;
        public const long Hashed = 3;

        [Column(TypeName = "VARCHAR"), StringLength(64)]
        public string UserName { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(64)]
        public string DisplayName { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(128)]
        public string Email { get; set; }

        public int PasswordFormat { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(1024)]
        public string Password { get; set; }

        public virtual IList<AppUserAppUserRole> UserRoles { get; set; }

        public virtual IList<AppUserAppRole> AppRoles { get; set; }


        public override string ToString()
        {
            return this.DisplayName;
        }

    }

   
}
