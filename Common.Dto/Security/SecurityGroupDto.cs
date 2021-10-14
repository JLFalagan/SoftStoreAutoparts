using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public partial class SecurityGroupDto : AuditEntityDto
    {
        public SecurityGroupDto()
        {
            Items = new List<SecurityItemDto>();
        }

        public SecurityGroupDto(string name) : this()
        {
            Name = name;
        }

        public virtual IList<SecurityItemDto> Items { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
