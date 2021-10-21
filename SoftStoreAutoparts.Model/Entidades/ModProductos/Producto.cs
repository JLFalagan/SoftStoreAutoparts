using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LibStoreAutoparts.Entidades.ModVehiculos;
//using LibStoreAutoparts.Entidades.ModProveedores;

namespace SoftStoreAutoparts.Model
{
    public class Producto : INotifyPropertyChanged
    {
        #region ATRIBUTOS Y PROPIEDADES

        private int idproducto;
        public int IDProducto
        {
            get { return idproducto; }
            set { idproducto = value; }
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
        private string marca;
        public string Marca
        {
            get { return marca; }
            set
            {
                if (this.marca != value)
                {
                    this.marca = value;
                    this.NotifyPropertyChanged("Marca");
                }
            }
        }
        private string descripccion;
        public string Descripccion
        {
            get { return descripccion; }
            set
            {
                if (this.descripccion != value)
                {
                    this.descripccion = value;
                    this.NotifyPropertyChanged("Descripccion");
                }
            }
        }
        private int stock;
        public int Stock
        {
            get { return stock; }
            set
            {
                if (this.stock != value)
                {
                    this.stock = value;
                    this.NotifyPropertyChanged("Stock");
                }
            }
        }
        private string codarticulo;
        public string CodArticulo
        {
            get { return codarticulo; }
            set
            {
                if (this.codarticulo != value)
                {
                    this.codarticulo = value;
                    this.NotifyPropertyChanged("CodArticulo");
                }
            }
        }
        private DateTime fechaupdate;
        public DateTime FechaUpdate
        {
            get { return fechaupdate; }
            set
            {
                if (fechaupdate != value)
                {
                    this.fechaupdate = value;
                    this.NotifyPropertyChanged("FechaUpdate");
                }
            }
        }
        private bool eliminado;
        public bool Eliminado
        {
            get { return eliminado; }
            set { eliminado = value; }
        }
        private Costo costos;
        public Costo Costos
        {
            get { return costos; }
            set
            {
                if (this.costos != value)
                {
                    this.costos = value;
                    this.NotifyPropertyChanged("Costos");
                }
            }
        }
        private TipoProducto tipoprod;
        public TipoProducto TipoProducto
        {
            get { return tipoprod; }
            set 
            {
                if (this.tipoprod != value)
                {
                    this.tipoprod = value;
                    this.NotifyPropertyChanged("TipoProducto");
                }
            }
        }
        private Categoria categoriaprod;
        public Categoria CategoriaProducto
        {
            get { return categoriaprod; }
            set 
            {
                if (this.categoriaprod != value)
                {
                    this.categoriaprod = value;
                    this.NotifyPropertyChanged("CategoriaProducto");
                }
            }
        }
        private Colores color;
        public Colores Color
        {
            get { return color; }
            set 
            {
                if (this.color != value)
                {
                    this.color = value;
                    this.NotifyPropertyChanged("Color");
                }
            }
        }
        private ObservableCollection<Imagen> imagenes;
        public ObservableCollection<Imagen> Imagenes
        {
            get { return imagenes; }
            set 
            {
                if (this.imagenes != value)
                {
                    this.imagenes = value;
                    this.NotifyPropertyChanged("Imagenes");
                }
            }
        }
        private Estante prodestante;
        public Estante ProdEstante
        {
            get { return prodestante; }
            set 
            {
                if (this.prodestante != value)
                {
                    this.prodestante = value;
                    this.NotifyPropertyChanged("ProdEstante");
                }
            }
        }
        private ObservableCollection<Vehiculo> vehiculos;
        public ObservableCollection<Vehiculo> Vehiculos
        {
            get { return vehiculos; }
            set 
            {
                if (this.vehiculos != value)
                {
                    this.vehiculos = value;
                    this.NotifyPropertyChanged("Vehiculos");
                }
            }
        }
        //private Proveedor proveedor;
        //public Proveedor Proveedor
        //{
        //    get { return proveedor; }
        //    set 
        //    {
        //        if (this.proveedor != value)
        //        {
        //            this.proveedor = value;
        //            this.NotifyPropertyChanged("Proveedor");
        //        }
        //    }
        //}
        private ObservableCollection<DatoTecnico> informaciontecnica;
        public ObservableCollection<DatoTecnico> InformacionTecnica
        {
            get { return informaciontecnica; }
            set 
            {
                if (this.informaciontecnica != value)
                {
                    this.informaciontecnica = value;
                    this.NotifyPropertyChanged("InformacionTecnica");
                }
            }
        }

        #endregion

        public Producto() //CONSTRUCTOR
        {
            Costos = new Costo();
            TipoProducto = new TipoProducto();
            CategoriaProducto = new Categoria();
            Color = new Colores();
            Imagenes = new ObservableCollection<Imagen>();
            ProdEstante = new Estante();
            Vehiculos = new ObservableCollection<Vehiculo>();
            //Proveedor = new Proveedor();
            InformacionTecnica = new ObservableCollection<DatoTecnico>();
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
