using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModProveedores
{
    public class ProveedorKey : Proveedor
    {
        public ProveedorKey(string nombre, int clave)
        {
            this.NombComercial = nombre;
            this.IDProveedor = clave;
        }

        public override string ToString()
        {
            return NombComercial;
        }
    }
}
