using System;
using System.Collections.Generic;

namespace Common.Dto
{
    public class AppRoleListDto : IKey<long>, ISelectedItemOfCollection
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
