using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.ElementosGenericos;

namespace LibStoreAutoparts.Entidades.ModClientes
{
    public class Cliente : PersonaFisica
    {
        //lista de pedidos
        private ObservableCollection<VehiculoCliente> vehiculoscliente;
        public ObservableCollection<VehiculoCliente> VehiculosCliente
        {
            get { return vehiculoscliente; }
            set { vehiculoscliente = value; }
        }

        public Cliente()
        {
            VehiculosCliente = new ObservableCollection<VehiculoCliente>();
        }

        public override string ToString()
        {
            return Apellido + ", " + Nombre;
        }
    }
}
