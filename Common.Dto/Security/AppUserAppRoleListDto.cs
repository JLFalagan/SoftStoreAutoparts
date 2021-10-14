using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public class AppUserAppRoleListDto : IEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }

        public string UserDisplayName { get; set; }

        public string RoleName { get; set; }

        public long RoleId { get; set; }
    }
}
