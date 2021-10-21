using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class GestorMedidas
    {
        public UnidadesDimensionales Dimensiones { get; set; }
        public UnidadesElectricas Electricas { get; set; }
        public UnidadesExtensivas Extensivas { get; set; }
        public U_Longitud Longitudes { get; set; }
        public U_Peso Pesos { get; set; }
        public U_Volumen Volumenes { get; set; }
        public U_Potencia Potencias { get; set; }
        public U_Amperaje Amperajes { get; set; }
        public U_Voltaje Voltajes { get; set; }

        public Array A_Dimensiones { get { return Enum.GetValues(Dimensiones.GetType()); } }
        public Array A_Electricas { get { return Enum.GetValues(Electricas.GetType()); } }
        public Array A_Extensivas { get { return Enum.GetValues(Extensivas.GetType()); } }
        public Array A_Longitudes { get { return Enum.GetValues(Longitudes.GetType()); } }
        public Array A_Pesos { get { return Enum.GetValues(Pesos.GetType()); } }
        public Array A_Volumenes { get { return Enum.GetValues(Volumenes.GetType()); } }
        public Array A_Potencias { get { return Enum.GetValues(Potencias.GetType()); } }
        public Array A_Amperajes { get { return Enum.GetValues(Amperajes.GetType()); } }
        public Array A_Voltajes { get { return Enum.GetValues(Voltajes.GetType()); } }

        public GestorMedidas()
        {
            //Constructor
        }

        public Array SeleccionarUnidad(string TipoUnidad)
        {
            Array unidades;
            switch (TipoUnidad)
            {
                case "Longitud":
                    return unidades = Enum.GetValues(Longitudes.GetType());
                case "Espesor":
                    return unidades = Enum.GetValues(Longitudes.GetType());
                case "Altura":
                    return unidades = Enum.GetValues(Longitudes.GetType());
                case "Diametro_Exterior":
                    return unidades = Enum.GetValues(Longitudes.GetType());
                case "Diametro_Interior":
                    return unidades = Enum.GetValues(Longitudes.GetType());
                case "Peso":
                    return unidades = Enum.GetValues(Pesos.GetType());
                case "Volumen":
                    return unidades = Enum.GetValues(Volumenes.GetType());
                case "Potencia":
                    return unidades = Enum.GetValues(Potencias.GetType());
                case "Amperaje":
                    return unidades = Enum.GetValues(Amperajes.GetType());
                case "Voltaje":
                    return unidades = Enum.GetValues(Voltajes.GetType());
                default:
                    return null;
            }
        }

        public List<String> ObtenerMagnitudes()
        {
            List<string> magnitudes = new List<string>();

            foreach (var item in this.A_Dimensiones)
                magnitudes.Add(item.ToString());
            
            foreach (var item in this.A_Electricas)
                magnitudes.Add(item.ToString());      

            foreach (var item in this.A_Extensivas)
                magnitudes.Add(item.ToString());

            return magnitudes;
        }
    }
}
