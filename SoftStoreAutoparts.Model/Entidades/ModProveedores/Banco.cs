using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModProveedores
{
    public class Banco : INotifyPropertyChanged
    {
        private int idbanco;
        public int IDBanco
        {
            get { return idbanco; }
            set 
            {
                if (this.idbanco != value)
                {
                    this.idbanco = value;
                    this.NotifyPropertyChanged("IDBanco");
                }
            }
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
        private string dieccion;
        public string Direccion
        {
            get { return dieccion; }
            set 
            {
                if (this.dieccion != value)
                {
                    this.dieccion = value;
                    this.NotifyPropertyChanged("Direccion");
                }
            }
        }
        private long telefono;
        public long Telefono
        {
            get { return telefono; }
            set 
            {
                if (this.telefono != value)
                {
                    this.telefono = value;
                    this.NotifyPropertyChanged("Telefono");
                }
            }
        }

        public Banco()
        { }

        //EVENTO ENCARGADO DE LANZAR UN MENSAJE DE QUE UNA PROPIEDAD O ATRIBUTO DE ESTA CLASE HA SIDO CAMBIADO
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propiedad)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
