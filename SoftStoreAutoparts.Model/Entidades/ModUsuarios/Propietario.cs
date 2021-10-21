using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.ElementosGenericos;

namespace LibStoreAutoparts.Entidades.ModUsuarios
{
    public class Propietario : PersonaFisica
    {
        private int idpropietario;
        public int IDPropietario
        {
            get { return idpropietario; }
            set { idpropietario = value; }
        }
        private Empresa comercio;
        public Empresa Comercio
        {
            get { return comercio; }
            set { comercio = value; }
        }
        private CuentaUsuario cuenta;
        public CuentaUsuario Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }

        public Propietario()
        {
            Comercio = new Empresa();
            Cuenta = new CuentaUsuario(); 
        }
    }
}
