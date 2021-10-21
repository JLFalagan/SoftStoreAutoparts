using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class TipoProducto : INotifyPropertyChanged
    {
        private int idtipopropucto;
        public int IDTipoPropucto
        {
            get { return idtipopropucto; }
            set { idtipopropucto = value; }
        }
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set 
            {
                if (this.nombre != value)
                {
                    this.nombre = value;
                    this.NotifyPropertyChanged("Nombre");
                }
            }
        }
        private int id_categoria;
        public int Id_Categoria
        {
            get { return id_categoria; }
            set { id_categoria = value; }
        }

        public TipoProducto() //CONSTRUCTOR
        { }

        public override string ToString()
        {
            return Nombre;
        }

        //EVENTO ENCARGADO DE LANZAR UN MENSAJE DE QUE UNA PROPIEDAD O ATRIBUTO DE ESTA CLASE HA SIDO CAMBIADO
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propiedad)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
