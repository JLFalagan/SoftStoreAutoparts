using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModUsuarios
{
    public class Comision
    {
        private int idcomision;
        public int IDComision
        {
            get { return idcomision; }
            set { idcomision = value; }
        }
        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private int horasextra;
        public int HorasExtras
        {
            get { return horasextra; }
            set { horasextra = value; }
        }
        private int numventas;
        public int NumeroVentas
        {
            get { return numventas; }
            set { numventas = value; }
        }
        private double totalventas;
        public double TotalVentas
        {
            get { return totalventas; }
            set { totalventas = value; }
        }
        private double comisiontotal;
        public double ComisionTotal
        {
            get { return comisiontotal; }
            set { comisiontotal = value; }
        }
        private int id_empleado;
        public int Id_Empleado
        {
            get { return id_empleado; }
            set { id_empleado = value; }
        }

        public Comision()
        { }
    }
}
