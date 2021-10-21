using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.Entidades.ModUsuarios;

namespace LibStoreAutoparts.Entidades.ModVentas
{
    public class Vendedor
    {
        private int id_vendedor;
        public int Id_Vendedor
        {
            get { return id_vendedor; }
            set { id_vendedor = value; }
        }
        private string nombreapellido;
        public string Nombre_Apellido
        {
            get { return nombreapellido; }
            set { nombreapellido = value; }
        }
        private CuentaUsuario usuario;
        public CuentaUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private Empleado empleado_vendedor;
        public Empleado Empleado_Vendedor
        {
            get { return empleado_vendedor; }
            set { empleado_vendedor = value; }
        }
        private Propietario admin_vendedor;
        public Propietario Admin_Vendedor
        {
            get { return admin_vendedor; }
            set { admin_vendedor = value; }
        }

        public Vendedor()
        {
            usuario = new CuentaUsuario();
            empleado_vendedor = new Empleado();
            admin_vendedor = new Propietario();
        }
    }
}
