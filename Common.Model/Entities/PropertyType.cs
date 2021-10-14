using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.Entities
{
    /// <summary>Define el Tipo de Propiedad, utilizado en la clase <strong><em>'BaseFieldData'</em></strong> para poder discriminar de que tipo de información tiene dicha clase.</summary>
    public enum PropertyTypeId
    {
        /// <summary>Define la propiedad del tipo <strong>Booleano</strong>.</summary>
        /// <value>Valor constante igual a <strong>1</strong>.</value>
        Boolean = 1,
        /// <summary>Define la propiedad del <strong>Entero</strong> de <strong>16 bits</strong>.</summary>
        /// <value>Valor constante igual a <strong>2</strong>.</value>
        Int16 = 2,
        /// <summary>Define la propiedad del tipo <strong>Entero</strong> de<strong> 32 bits.</strong></summary>
        /// <value>Valor constante igual a <strong>3</strong>.</value>
        Int32 = 3,
        /// <summary>Define la propiedad del tipo <strong>Entero</strong> de <strong>64 bits</strong>.</summary>
        /// <value>Valor constante igual a <strong>4</strong>.</value>
        Int64 = 4,
        /// <summary>Define la propiedad del tipo <strong>Decimal</strong>.</summary>
        /// <value>Valor constante igual a <strong>5</strong>.</value>
        Decimal = 5,
        /// <summary>Define la propiedad del tipo <strong>DateTime</strong>.</summary>
        /// <value>Valor constante igual a <strong>6</strong>.</value>
        DateTime = 6,
        /// <summary>Define la propiedad del tipo <strong>String</strong>.</summary>
        /// <value>Valor constante igual a <strong>7.</strong></value>
        String = 7,
        /// <summary>Define la propiedad del tipo <strong>Float</strong></summary>
        /// <value>Valor constante igual a <strong>8.</strong></value>
        Float = 8
    }
}
