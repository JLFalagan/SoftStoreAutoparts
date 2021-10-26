using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public class AppUserRoleListDto : IKey<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
