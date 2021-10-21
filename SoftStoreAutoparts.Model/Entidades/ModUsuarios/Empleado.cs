using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.ElementosGenericos;

namespace LibStoreAutoparts.Entidades.ModUsuarios
{
    public class Empleado : PersonaFisica
    {
        private int idempleado;
        public int IDEmpleado
        {
            get { return idempleado; }
            set { idempleado = value; }
        }
        private DateTime fechaingreso;
        public DateTime FechaIngreso
        {
            get { return fechaingreso; }
            set { fechaingreso = value; }
        }
        private ObservableCollection<DetalleLaboral> detallelaboral;
        public ObservableCollection<DetalleLaboral> DetallesLaborales
        {
            get { return detallelaboral; }
            set { detallelaboral = value; }
        }
        private ObservableCollection<Comision> comisiones;
        public ObservableCollection<Comision> Comisiones
        {
            get { return comisiones; }
            set { comisiones = value; }
        }
        private CuentaUsuario cuenta;
        public CuentaUsuario Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }

        public Empleado()
        {
            DetallesLaborales = new ObservableCollection<DetalleLaboral>();
            Comisiones = new ObservableCollection<Comision>();
            Cuenta = new CuentaUsuario();
        }

        public override string ToString()
        {
            return this.Apellido + ", " + this.Nombre;
        }
    }
}
