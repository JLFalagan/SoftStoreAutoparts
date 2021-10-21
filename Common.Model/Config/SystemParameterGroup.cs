using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Common.Model
{
    /// <summary>Agrupa una colección de <strong>'SystemParametrs'</strong>.</summary>
    /// <example>A continuación se muestra un ejemplo:
    /// <code>var Group = new SystemParameterGroup();
    /// Group.Parameters.Add(new SystemParameter());</code></example>
    /// <seealso cref="NeyTI.Core.Model.Entities.BaseType" />
    public class SystemParameterGroup : BaseTypeAudit
    {
        /// <summary>Initializes a new instance of the <see cref="SystemParameterGroup"/> class.</summary>
        public SystemParameterGroup()
        {
            Parameters = new List<SystemParameter>();
        }

        /// <summary>Gets or sets the parameters collections.</summary>
        /// <value>The parameters.</value>
        public virtual IList<SystemParameter> Parameters { get; set; }
    }
}
