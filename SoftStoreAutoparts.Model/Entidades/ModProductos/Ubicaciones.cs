using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Ubicaciones
    {
        private Pasillo pasilloprod;
        public Pasillo PasilloProd
        {
            get { return pasilloprod; }
            set { pasilloprod = value; }
        }
        private List<Estante> estantes;
        public List<Estante> Estantes
        {
            get { return estantes; }
            set { estantes = value; }
        }

        public Ubicaciones()
        {
            Estantes = new List<Estante>();
        }
    }
}
