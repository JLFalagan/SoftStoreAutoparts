using NeyTI.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Security
{
    /// <summary>
    /// Rol / Funcion de la aplicacion
    /// </summary>
    public class AppRole : BaseType
    {
        public virtual IList<AppUserAppRole> Users { get; set; }
    }
}
