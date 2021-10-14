using Common.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Common.Model
{
    /// <summary>
    /// Clase que representa un Parámetro de Sistema. Es utilizado para gestionar algún valor que el sistema debería tener, pero por cuestión de escala o performance, no es necesario crear una <strong>Entidad</strong> propia.
    /// </summary>
    /// <example>A continuación se muestra un ejemplo
    /// <code title="Ejemplo">var param = new SystemParameter();
    /// param.TypeId = PropertyType.Int32;
    /// param.ValueInt32 = 12;</code></example>
    /// <seealso cref="NeyTI.Core.Model.Entities.BaseFieldData"/>
    public class SystemParameter : BaseFieldData
    {
        /// <summary>Initializes a new instance of the <see cref="SystemParameter"/> class.</summary>
        /// <example>A continuación se crea un parámetro de sistema:
        /// <code title="Ejemplo">var param = new SystemParameter();
        /// param.TypeId = PropertyType.Int64;
        /// param.ValueInt64 = 1000;</code></example>
        public SystemParameter()
        { }

        /// <summary>
        /// Propiedad utilizada para identificar el <strong>nombre clave</strong> del parámetro. Dentro de la colección de Parametros debería ser único ya que es utilizado dentro de un <em>Dictionary</em>.
        /// </summary>
        /// <value>The key.</value>
        [StringLength(450)]
        //[Index(IsUnique = true)]
        [Key]
        public string Key { get; set; }
        /// <summary>Gets or sets the name property.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the group identifier of class <strong>'SystemParameterGroup'</strong>.</summary>
        /// <value>The group identifier.</value>
        public long GroupId { get; set; }
        /// <summary>Gets or sets the group <strong>'SystemParameterGroup</strong> '.</summary>
        /// <value>The group.</value>
        public virtual SystemParameterGroup Group { get; set; }

        /// <summary>Gets or sets the comment of Entity.</summary>
        /// <value>The comment.</value>
        public string Comment { get; set; }

        /// <summary>Gets the name of the group.</summary>
        /// <value>The name of the group.</value>
        public string GroupName => Group?.Name;

        public override string ToString() => Name;
    }
}
