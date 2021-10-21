using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModProveedores
{
    public class Representante : INotifyPropertyChanged
    {
        private int idrepresentante;
        public int IDRepresentante
        {
            get { return idrepresentante; }
            set 
            {
                if (this.idrepresentante != value)
                {
                    this.idrepresentante = value;
                    this.NotifyPropertyChanged("IDRepresentante");
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
        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set 
            {
                if (this.apellido != value)
                {
                    this.apellido = value;
                    this.NotifyPropertyChanged("Apellido");
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
        private long movil;
        public long Movil
        {
            get { return movil; }
            set 
            {
                if (this.movil != value)
                {
                    this.movil = value;
                    this.NotifyPropertyChanged("Movil");
                }
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set 
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.NotifyPropertyChanged("Email");
                }
            }
        }
        private DateTime fechavisita;
        public DateTime FechaVisita
        {
            get { return fechavisita; }
            set 
            {
                if (this.fechavisita != value)
                {
                    this.fechavisita = value;
                    this.NotifyPropertyChanged("FechaVisita");
                }
            }
        }

        public Representante()
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
