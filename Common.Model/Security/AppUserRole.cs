using NeyTI.Core.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Security
{
    /// <summary>
    /// Rol de usuario de la aplicacion
    /// </summary>
    public class AppUserRole : BaseType
    {
        /// <summary>The system admin
        /// user for default</summary>
        public static string SysAdmin = "sysadmin";

        public AppUserRole() : base()
        {
            Users = new List<AppUserAppUserRole>();
            Permissions = new List<Permission>();
        }

        public virtual IList<AppUserAppUserRole> Users { get; set; }

        public virtual IList<Permission> Permissions { get; set; }
    }
}
