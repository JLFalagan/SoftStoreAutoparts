using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Imagen
    {
        private int idimagen;
        public int IDImagen
        {
            get { return idimagen; }
            set { idimagen = value; }
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

        public Imagen(long longitud)
        {
            ArchivoImagen = new byte[longitud];
        }

        public Imagen()
        {
            //CONSTRUCTOR
        }
    }
}
