using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Segmentos
    {
        private Segmento[] listsegmentos;
        public Segmento[] ListSegmentos
        {
            get { return listsegmentos; }
            set { listsegmentos = value; }
        }

        public Segmentos()
        {
            ListSegmentos = new Segmento[7];
            CargarSegms();
        }

        private void CargarSegms()
        {
            listsegmentos[0] = (new Segmento { NombSegmento = "SIN SEGEMENTO", InformacionSeg = "S/S" });
            ListSegmentos[1] = (new Segmento { NombSegmento = "Segmento A", InformacionSeg = "4 Plazas de tamaños pequeños- entre 3300mm y 3700mm" });
            ListSegmentos[2] = (new Segmento { NombSegmento = "Segmento B", InformacionSeg = "4 Adultos y 1 Niño- Hatchback y Monovolúmenes de 3900mm- Sedanes y Familiares hasta 4200mm" });
            ListSegmentos[3] = (new Segmento { NombSegmento = "Segmento C", InformacionSeg = "5 Plazas completas- Hatchbacks en torno a 4200mm- Sedanes y Familiares hasta 4500mm" });
            ListSegmentos[4] = (new Segmento { NombSegmento = "Segmento D", InformacionSeg = "5 Plazas Motores potentes y Maletero más grande- Aproximadamente 4600mm" });
            ListSegmentos[5] = (new Segmento { NombSegmento = "Segmento E", InformacionSeg = "Los modelos más grandes de las fábricas de automóviles generalistas- Tamaño promedio de 4800mm" });
            ListSegmentos[6] = (new Segmento { NombSegmento = "Segmento F", InformacionSeg = "Modelos de alta gama- Superan los 5000mm" });
        }
    }

    public class Segmento
    {
        private string nombsegmento;
        public string NombSegmento
        {
            get { return nombsegmento; }
            set { nombsegmento = value; }
        }
        private string informacionseg;
        public string InformacionSeg
        {
            get { return informacionseg; }
            set { informacionseg = value; }
        }

        public Segmento() { }

        public override string ToString()
        {
            return NombSegmento;
        }
    }
}
