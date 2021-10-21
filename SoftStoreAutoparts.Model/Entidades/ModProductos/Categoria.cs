using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Categoria : INotifyPropertyChanged
    {
        private int idcategoria;
        public int IDCategoria
        {
            get { return idcategoria; }
            set { idcategoria = value; }
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

        public Categoria() //CONSTRUCTOR
        {}

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
