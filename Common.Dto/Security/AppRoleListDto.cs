using NeyTI.Core.Dto;
using System;
using System.Collections.Generic;

namespace Common.Dto
{
    public class AppRoleListDto : IEntity, ISelectedItemOfCollection
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
