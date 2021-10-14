using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public partial class AppUserDto : AuditEntityDto
    {
        public const int PasswordFormatClear = 1;
        public const int PasswordFormatEncrypted = 2;
        public const int PasswordFormatHashed = 3;

        public AppUserDto() : base()
        {
            UserRoles = new List<AppUserAppUserRoleDto>();
            AppRoles = new List<AppUserAppRoleDto>();
        }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public int PasswordFormat { get; set; }

        public string Password { get; set; }

        public virtual IList<AppUserAppUserRoleDto> UserRoles { get; set; }

        public virtual IList<AppUserAppRoleDto> AppRoles { get; set; }


    }


}
