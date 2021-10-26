using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public partial class SecurityItemDto : AuditEntityDto<long>
    {
        
        public SecurityItemDto() { }

        /// <summary>Initializes a new instance of the <see cref="SecurityItem"/> class.</summary>
        /// <param name="name">The name of Security Item</param>
        public SecurityItemDto(string name)
        {
            Name = name;
        }

        public long GroupId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }

        public string GroupItemName { get; set; }

        public bool IsSelected { get; set; }
    }
}
