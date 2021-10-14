using NeyTI.Core.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Common.Model.Security
{
    public class SecurityGroup : AuditEntity
    {
        public SecurityGroup()
        {
            Items = new List<SecurityItem>();
        }

        public SecurityGroup(string name) : this()
        {
            Name = name;
        }

        public virtual IList<SecurityItem> Items { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(512)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(1024)]
        public string Description { get; set; }

        public override string ToString() => Description;   //revisar
    }
}
