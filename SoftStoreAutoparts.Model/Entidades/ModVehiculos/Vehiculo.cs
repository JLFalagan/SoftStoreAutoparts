using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Vehiculo
    {
        private int idvehiculo;
        public int IDVehiculo
        {
            get { return idvehiculo; }
            set { idvehiculo = value; }
        }
        private string modelolinea;
        public string ModeloLinea
        {
            get { return modelolinea; }
            set { modelolinea = value; }
        }
        private int año;
        public int Año
        {
            get { return año; }
            set { año = value; }
        }
        private string puertas;
        public string Puertas
        {
            get { return puertas; }
            set { puertas = value; }
        }
        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private Segmento segmentoveh;
        public Segmento SegmentoVeh
        {
            get { return segmentoveh; }
            set { segmentoveh = value; }
        }
        private Escuderia marca;
        public Escuderia Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        private TipoVehiculo tipoveh;
        public TipoVehiculo TipoVeh
        {
            get { return tipoveh; }
            set { tipoveh = value; }
        }

        public Vehiculo()
        {
            SegmentoVeh = new Segmento();
            Marca = new Escuderia();
            TipoVeh = new TipoVehiculo();
        }

        public override string ToString()
        {
            string modelo = ModeloLinea + " " + Año.ToString();
            return modelo;
        }
    }
}
