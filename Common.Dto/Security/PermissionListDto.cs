using System;
using System.Collections.Generic;


namespace Common.Dto
{ 
    public class PermissionListDto : IEntity
    {
        public long Id { get; set; }

        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public long ItemId { get; set; }
       
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string GroupName { get; set; }

        public string GroupDescription { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsVisible { get; set; }

        public bool IsReadOnly { get; set; }
    }
}