using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Entities
{
    public abstract class BaseTypeAudit : AuditEntity
    {
        public BaseTypeAudit()
        { }

        public BaseTypeAudit(string name)
        {
            Name = name;
        }

        //[Index]
        //[Key]
        [Column(TypeName = "VARCHAR"), StringLength(512)]
        public string Name { get; set; }

        public override string ToString()
        { return Name; }
    }
}
