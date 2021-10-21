using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class DatoTecnico
    {
        private int id_datotecnico;
        public int IDDatoTecnico
        {
            get { return id_datotecnico; }
            set { id_datotecnico = value; }
        }
        private string magnitud;
        public string Magnitud
        {
            get { return magnitud; }
            set { magnitud = value; }
        }
        private double valor;
        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private string unidad;
        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }

        public DatoTecnico()
        { }
    }
}
