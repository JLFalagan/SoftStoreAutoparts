using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Common.Model.Entities
{
    /// <summary>
    /// La clase de <strong>'Campo de Datos Base'</strong> es utilizada para definir un valor genérico de dato. Puede ser de acuerdo a <strong>'PropertyTypeId'</strong> como: <em>Booleano</em>, <em>String</em>, <em>Int64</em>, <em>Int32</em>, <em>Int16</em>, <em>Decimal</em>, <em>Float</em> o <em>DateTime</em>.
    /// </summary>
    /// <seealso cref="NeyTI.Core.Model.Entities.AuditEntity" />
    public abstract class BaseFieldData : AuditEntity
    {
        /// <summary>Gets or sets the type identifier.</summary>
        /// <value>The type identifier.</value>
        public virtual PropertyTypeId TypeId { get; set; }

        /// <summary>Metodo que devuelve un <strong>'String'</strong> con la presentación del Valor definido de acuerdo al tipo de dato.</summary>
        /// <value>The value display.</value>
        public string ValueDisplay
        {
            get
            {
                string value = string.Empty;
                switch (TypeId)
                {
                    case PropertyTypeId.Boolean:
                        if (ValueBoolean.HasValue)
                            value = ValueBoolean.Value ? "Si" : "No";
                        break;
                    case PropertyTypeId.String:
                        value = ValueString;
                        break;
                    case PropertyTypeId.Int64:
                        if (ValueInt64.HasValue)
                            value = ValueInt64.Value.ToString();
                        break;
                    case PropertyTypeId.Int32:
                        if (ValueInt32.HasValue)
                            value = ValueInt32.Value.ToString();
                        break;
                    case PropertyTypeId.Int16:
                        if (ValueInt16.HasValue)
                            value = ValueInt16.Value.ToString();
                        break;
                    case PropertyTypeId.Decimal:
                        if (ValueDecimal.HasValue)
                            value = ValueDecimal.Value.ToString("N2");
                        break;
                    case PropertyTypeId.Float:
                        if (ValueFloat.HasValue)
                            value = ValueFloat.Value.ToString("N2");
                        break;
                    case PropertyTypeId.DateTime:
                        if (ValueDateTime.HasValue)
                            value = ValueDateTime.Value.ToString("dd/MM/yyyy");
                        break;
                    default:
                        break;
                }
                return value;
            }
        }
        /// <summary>Metodo que devuelve el '<strong>objeto</strong>' que representa el Campo de Dato, de acuerdo al Tipo de Dato definido.</summary>
        /// <returns>Retorna un <strong>'object'.</strong></returns>
        public object GetObjectValue()
        {
            switch (TypeId)
            {
                case PropertyTypeId.Boolean:
                    return ValueBoolean;
                case PropertyTypeId.Int64:
                    return ValueInt64;
                case PropertyTypeId.Int32:
                    return ValueInt32;
                case PropertyTypeId.Int16:
                    return ValueInt16;
                case PropertyTypeId.Decimal:
                    return ValueDecimal;
                case PropertyTypeId.Float:
                    return ValueFloat;
                case PropertyTypeId.DateTime:
                    return ValueDateTime;
                case PropertyTypeId.String:
                    return ValueString;
                default:
                    return this.ToString();
            }
        }

        /// <summary>Gets or sets the value boolean.</summary>
        /// <value>The value boolean.</value>
        public bool? ValueBoolean { get; set; }
        /// <summary>Gets or sets the value string.</summary>
        /// <value>The value string.</value>
        public string ValueString { get; set; }
        /// <summary>Gets or sets the value int64.</summary>
        /// <value>The value int64.</value>
        public long? ValueInt64 { get; set; }
        /// <summary>Gets or sets the value int32.</summary>
        /// <value>The value int32.</value>      
        public Int32? ValueInt32 { get; set; }
        /// <summary>Gets or sets the value int16.</summary>
        /// <value>The value int16.</value>
        public Int16? ValueInt16 { get; set; }
        /// <summary>Gets or sets the value decimal.</summary>
        /// <value>The value decimal.</value>
        public Decimal? ValueDecimal { get; set; }
        /// <summary>Gets or sets the value float.</summary>
        /// <value>The value float.</value>
        public float? ValueFloat { get; set; }
        /// <summary>Gets or sets the value date time.</summary>
        /// <value>The value date time.</value>
        public DateTime? ValueDateTime { get; set; }
    }
}
