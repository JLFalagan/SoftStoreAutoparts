using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class DatosEmisor : PersonaJuridica
    {
        /// <summary HERENCIA>
        /// ID
        /// RazonSocial
        /// DomicilioComercial
        /// CUIT
        /// CondicionIVA Frente_IVA
        /// </summary>

        private string nombrecomercial;
        public string NombreComercial
        {
            get { return nombrecomercial; }
            set { nombrecomercial = value; }
        }   //Se Refiere al nombre de Fantasia
        private string domiciliofiscal;
        public string DomicilioFiscal
        {
            get { return domiciliofiscal; }
            set { domiciliofiscal = value; }
        }   
        private string ingresosbruto;
        public string IngresosBruto
        {
            get { return ingresosbruto; }
            set { ingresosbruto = value; }
        }
        private DateTime inicioactividades;
        public DateTime InicioActividades
        {
            get { return inicioactividades; }
            set { inicioactividades = value; }
        }

        public DatosEmisor()
        { }

        public override string ToString()
        {
            return NombreComercial + " - " + this.RazonSocial + "  ( CUIT: "+this.CUIT.ToString()+ " )";
        }
    }
}
