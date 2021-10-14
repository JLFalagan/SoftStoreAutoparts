using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public abstract class BaseTypeDto : AuditEntityDto
    {
        public string Name { get; set; }
    }
}