using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModUsuarios
{
    public class TipoPerfil
    {
        private int idperfil;
        public int IDPerfil
        {
            get { return idperfil; }
            set { idperfil = value; }
        }
        private string perfil;
        public string Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }

        public TipoPerfil()
        { }

        public override string ToString()
        {
            return Perfil;
        }
    }
}
