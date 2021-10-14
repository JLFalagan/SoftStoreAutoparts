using NeyTI.Core.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Security
{
    public class Permission : AuditEntity
    {
        public long RoleId { get; set; }

        public virtual AppUserRole Role { get; set; }

        public long ItemId { get; set; }
        public virtual SecurityItem Item { get; set; }

        public string ItemName { get { return Item?.Name; } }

        public string GroupName { get { return Item?.Group?.Name; } } 

        public string GroupDescription { get { return Item?.Group?.Description; } }

        public string GroupItemName { get { return $"{Item?.GroupItemName}"; } }

        public string ItemDescription { get { return Item?.Description; } }

        public bool IsEnabled { get; set; }

        //public bool DefaultEnabled { get; set; }

        public bool IsVisible { get; set; }

        //public bool DefaultVisible { get; set; }

        public bool IsReadOnly { get; set; }

        //public bool DefaultReadOnly { get; set; }
    }
}