using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dto
{
    public class AppRoleDto : AuditEntityDto
    {
        //Implentacion solo para seleccion  
        public bool IsSelected { get; set; }

        public string Name { get; set; }
    }
}
