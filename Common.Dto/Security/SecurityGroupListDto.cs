using System;
using System.Collections.Generic;

namespace Common.Dto
{
    public class SecurityGroupListDto : IKey<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
