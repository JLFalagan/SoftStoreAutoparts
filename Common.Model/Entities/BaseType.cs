using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Entities
{
    public class BaseType : BaseEntity
    {
        public BaseType()
        { }

        public BaseType(string name)
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
