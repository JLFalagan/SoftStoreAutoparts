using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public class AppUserRoleDto : BaseTypeDto<long>
    {
        /// <summary>The system admin
        /// user for default</summary>
        public const string SysAdmin = "sysadmin";
        public const string Procurator = "procurator";

        public AppUserRoleDto() : base()
        {
            Users = new List<AppUserAppUserRoleDto>();
            Permissions = new List<PermissionDto>();
        }

        public virtual IList<AppUserAppUserRoleDto> Users { get; set; }


        public virtual IList<PermissionDto> Permissions { get; set; }
    }
}
