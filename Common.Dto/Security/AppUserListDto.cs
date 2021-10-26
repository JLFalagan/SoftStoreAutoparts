using System;
using System.Collections.Generic;

namespace Common.Dto
{
    public partial class AppUserListDto : IKey<long>
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }
        
        public virtual string Roles { get; set; }

    }
}
