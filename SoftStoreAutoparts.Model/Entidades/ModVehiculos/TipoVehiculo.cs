using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class TipoVehiculo
    {
        private int idtipovehiculo;
        public int IDTipoVehiculo
        {
            get { return idtipovehiculo; }
            set { idtipovehiculo = value; }
        }
        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public TipoVehiculo()
        { }

        public override string ToString()
        {
            return Tipo;
        }
    }
}
