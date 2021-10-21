using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LibStoreAutoparts.Entidades.ModProveedores;

namespace SoftStoreAutoparts.Model
{
    public class Factura : INotifyPropertyChanged
    {
        private int idFactura;
        public int IDFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }
        private TipoFactura tipocomprobante;
        public TipoFactura TipoComprobante
        {
            get { return tipocomprobante; }
            set { tipocomprobante = value; }
        }
        private NumeroFactura numfactura;
        public NumeroFactura NumFactura
        {
            get { return numfactura; }
            set 
            {
                if (this.numfactura != value)
                {
                    this.numfactura = value;
                    this.NotifyPropertyChanged("NumFactura");
                }
            }
        }
        private DateTime fechahora;
        public DateTime Fecha_Hora
        {
            get { return fechahora; }
            set 
            {
                if (this.fechahora != value)
                {
                    this.fechahora = value;
                    this.NotifyPropertyChanged("Fecha_Hora");
                }
            }
        }

        private DatosEmisor emisor;
        public DatosEmisor Emisor
        {
            get { return emisor; }
            set { emisor = value; }
        }
        private DatosAdquirente adquirente;
        public DatosAdquirente Adquirente
        {
            get { return adquirente; }
            set { adquirente = value; }
        }

        private ObservableCollection<DetalleFactura> detalles;
        public ObservableCollection<DetalleFactura> Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }

        private double descuentoporc;
        public double DescuentoPorc
        {
            get { return descuentoporc; }
            set { descuentoporc = value; }
        }
        private double descuento;
        public double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        private double total;
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        
        //CONDICIONES DE VENTA
        //FALTA FORMA DE PAGO

        public Factura()
        {
            NumFactura = new NumeroFactura();
            Fecha_Hora = DateTime.Now;
            Emisor = new DatosEmisor();
            Adquirente = new DatosAdquirente();
            Detalles = new ObservableCollection<DetalleFactura>();
        }

        //Metodo que obtiene el Emisor
        //Metodo que obtiene el Adquirente
        //Metodo que adjunta el Adquirente

        //public void AdjuntarEmisor(Proveedor emisorProveedor)
        //{
        //    this.Emisor.ID = emisorProveedor.IDProveedor;
        //    this.Emisor.NombreComercial = emisorProveedor.NombComercial;
        //    this.Emisor.RazonSocial = emisorProveedor.RazonSocial;
        //    this.Emisor.CUIT = emisorProveedor.CUIT;
        //    this.Emisor.DomicilioComercial = emisorProveedor.Direccion;
        //    this.Emisor.DomicilioFiscal = emisorProveedor.Direccion;           
        //}

        //EVENTO ENCARGADO DE LANZAR UN MENSAJE DE QUE UNA PROPIEDAD O ATRIBUTO DE ESTA CLASE HA SIDO CAMBIADO
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propiedad)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
