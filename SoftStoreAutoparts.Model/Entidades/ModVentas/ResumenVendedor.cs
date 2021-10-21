using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.Entidades.ModUsuarios;

namespace LibStoreAutoparts.Entidades.ModVentas
{
    public class ResumenVendedor
    {
        private string vendedor;
        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }
        private int ventas;
        public int Ventas
        {
            get { return ventas; }
            set { ventas = value; }
        }
        private double totalventas;
        public double TotalVentas
        {
            get { return totalventas; }
            set { totalventas = value; }
        }
        private CuentaUsuario usuario;
        public CuentaUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public ResumenVendedor()
        {
            Usuario = new CuentaUsuario();
        }
    }
}
