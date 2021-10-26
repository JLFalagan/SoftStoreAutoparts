using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public class AppUserAppUserRoleDto : AuditEntityDto<long>
    {
        public AppUserAppUserRoleDto() : base()
        {
            
        }

        public long UserId { get; set; }

        public long RoleId { get; set; }

        //public override bool IsNew
        //{
        //    get
        //    {
        //        return (UserId == 0 && RoleId == 0);
        //    }
        //}

    }
}
