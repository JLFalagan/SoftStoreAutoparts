using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public class PermissionDto : AuditEntityDto
    {
        public long RoleId { get; set; }

        public long ItemId { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsVisible { get; set; }

        public bool IsReadOnly { get; set; }

    }
}