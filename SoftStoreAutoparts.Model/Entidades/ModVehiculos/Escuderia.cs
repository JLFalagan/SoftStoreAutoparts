using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Escuderia
    {
        private int idescuderia;
        public int IDEscuderia
        {
            get { return idescuderia; }
            set { idescuderia = value; }
        }
        private string escuderiamarca;
        public string EscuderiaMarca
        {
            get { return escuderiamarca; }
            set { escuderiamarca = value; }
        }
        private string imagenescudo;
        public string ImagenEscudo
        {
            get { return imagenescudo; }
            set { imagenescudo = value; }
        }

        public Escuderia()
        { }

        public override string ToString()
        {
            return EscuderiaMarca;
        }
    }
}
