using NeyTI.Core.Dto;
using System;
using System.Collections.Generic;


namespace Common.Dto
{
    public class SecurityItemListDto : IEntity
    {
        public long Id { get; set; }

        public SecurityItemListDto() { }

        public long GroupId { get; set; }

        public string GroupName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public bool IsSelected { get; set; }
    }
}
