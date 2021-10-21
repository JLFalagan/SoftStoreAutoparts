using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Estante : INotifyPropertyChanged
    {
        private int idestante;
        public int IDEstante
        {
            get { return idestante; }
            set { idestante = value; }
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
        private int id_pasillo;
        public int Id_Pasillo
        {
            get { return id_pasillo; }
            set { id_pasillo = value; }
        }

        public Estante() //CONSTRUCTOR
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
