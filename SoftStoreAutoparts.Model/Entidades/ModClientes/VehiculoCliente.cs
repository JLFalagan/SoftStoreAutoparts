using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.Entidades.ModVehiculos;

namespace LibStoreAutoparts.Entidades.ModClientes
{
    public class VehiculoCliente : Vehiculo
    {
        private int año_compra;
        private string color;
        private string matricula;
        private int kilometraje;
        private string motor;
        private string combustible;
        private int caja;
    }
}
