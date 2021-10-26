using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public class AppUserAppRoleDto : AuditEntityDto<long>
    {
        public AppUserAppRoleDto() : base()
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
