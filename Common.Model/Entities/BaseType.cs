using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Entities
{
    public abstract class BaseType : AuditEntity
    {
        public BaseType()
        {
        }

        public BaseType(string name)
        {
            Name = name;
        }

        //[Index]
        [Key]
        [Column(TypeName = "VARCHAR"), StringLength(256)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
