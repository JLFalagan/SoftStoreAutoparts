using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Colores
    {
        private int idcolores;
        public int IDColores
        {
            get { return idcolores; }
            set { idcolores = value; }
        }
        private string codcolor;
        public string CodColor
        {
            get { return codcolor; }
            set { codcolor = value; }
        }
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private byte[] archivoimagen;
        public byte[] ArchivoImagen
        {
            get { return archivoimagen; }
            set { archivoimagen = value; }
        }

        public Colores() //CONSTRUCTOR
        {
        }

        public Colores(int id, string cod, string nomb)
        {
            IDColores = id;
            CodColor = cod;
            Nombre = nomb;
        }
    }
}
