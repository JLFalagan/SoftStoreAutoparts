using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.Entidades.ModProductos;

namespace LibStoreAutoparts.Entidades.ModProveedores
{
    public class Proveedor : INotifyPropertyChanged
    {
        private int idproveedor;
        public int IDProveedor
        {
            get { return idproveedor; }
            set 
            {
                if (this.idproveedor != value)
                {
                    this.idproveedor = value;
                    this.NotifyPropertyChanged("IDProveedor");
                }
            }
        }
        private string nombcomercial;
        public string NombComercial
        {
            get { return nombcomercial; }
            set 
            { 
                if (this.nombcomercial != value)
                {
                    this.nombcomercial = value;
                    this.NotifyPropertyChanged("NombComercial");
                }
            }
        }
        private string razonsocial;
        public string RazonSocial
        {
            get { return razonsocial; }
            set 
            {
                if (this.razonsocial != value)
                {
                    this.razonsocial = value;
                    this.NotifyPropertyChanged("RazonSocial");
                }
            }
        }
        private long cuit;
        public long CUIT
        {
            get { return cuit; }
            set 
            {
                if (this.cuit != value)
                {
                    this.cuit = value;
                    this.NotifyPropertyChanged("CUIT");
                }
            }
        }
        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set 
            {
                if (this.direccion != value)
                {
                    this.direccion = value;
                    this.NotifyPropertyChanged("Direccion");
                }
            }
        }
        private string ciudad;
        public string Ciudad
        {
            get { return ciudad; }
            set 
            {
                if (this.ciudad != value)
                {
                    this.ciudad = value;
                    this.NotifyPropertyChanged("Ciudad");
                }
            }
        }
        private string codpostal;
        public string CodPostal
        {
            get { return codpostal; }
            set 
            {
                if (this.codpostal != value)
                {
                    this.codpostal = value;
                    this.NotifyPropertyChanged("CodPostal");
                }
            }
        }
        private string provincia;
        public string Provincia
        {
            get { return provincia; }
            set 
            {
                if (this.provincia != value)
                {
                    this.provincia = value;
                    this.NotifyPropertyChanged("Provincia");
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
        private long fax;
        public long Fax
        {
            get { return fax; }
            set 
            {
                if (this.fax != value)
                {
                    this.fax = value;
                    this.NotifyPropertyChanged("Fax");
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
        private string sitioweb;
        public string SitioWeb
        {
            get { return sitioweb; }
            set 
            {
                if (this.sitioweb != value)
                {
                    this.sitioweb = value;
                    this.NotifyPropertyChanged("SitioWeb");
                }
            }
        }
        private string email;
        public string EMail
        {
            get { return email; }
            set 
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.NotifyPropertyChanged("EMail");
                }
            }
        }
        private string observaciones;
        public string Observaciones
        {
            get { return observaciones; }
            set 
            {
                if (this.observaciones != value)
                {
                    this.observaciones = value;
                    this.NotifyPropertyChanged("Observaciones");
                }
            }
        }
        private int numcliente;
        public int NumCliente
        {
            get { return numcliente; }
            set 
            {
                if (this.numcliente != value)
                {
                    this.numcliente = value;
                    this.NotifyPropertyChanged("NumCliente");
                }
            }
        }
        private DateTime fechaalta;
        public DateTime FechaAlta
        {
            get { return fechaalta; }
            set { fechaalta = value; }
        }
        private DateTime fechaupdate;
        public DateTime FechaUpdate
        {
            get { return fechaupdate; }
            set 
            {
                if (this.fechaupdate != value)
                {
                    this.fechaupdate = value;
                    this.NotifyPropertyChanged("FechaUpdate");
                }
            }
        }
        private bool sinrubro;
        public bool SinRubro
        {
            get { return sinrubro; }
            set 
            {
                if (this.sinrubro != value)
                {
                    this.sinrubro = value;
                    this.NotifyPropertyChanged("SinRubro");
                }
            }
        }
        private Representante represprovee;
        public Representante RepresProvee
        {
            get { return represprovee; }
            set 
            {
                if (this.represprovee != value)
                {
                    this.represprovee = value;
                    this.NotifyPropertyChanged("RepresProvee");
                }
            }
        }
        private ObservableCollection<BancoProveedor> bancos;
        public ObservableCollection<BancoProveedor> Bancos
        {
            get { return bancos; }
            set 
            {
                if (this.bancos != value)
                {
                    this.bancos = value;
                    this.NotifyPropertyChanged("Bancos");
                }
            }
        }
        private ObservableCollection<Categoria> rubros;
        public ObservableCollection<Categoria> Rubros
        {
            get { return rubros; }
            set 
            {
                if (this.rubros != value)
                {
                    this.rubros = value;
                    this.NotifyPropertyChanged("Rubros");
                }
            }
        }

        public Proveedor()
        {
            FechaAlta = DateTime.Today;
            RepresProvee = new Representante();
            Bancos = new ObservableCollection<BancoProveedor>();
            Rubros = new ObservableCollection<Categoria>();
        }

        //EVENTO ENCARGADO DE LANZAR UN MENSAJE DE QUE UNA PROPIEDAD O ATRIBUTO DE ESTA CLASE HA SIDO CAMBIADO
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propiedad)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
        }

        public override string ToString()
        {
            return this.NombComercial;
        }
    }
}
