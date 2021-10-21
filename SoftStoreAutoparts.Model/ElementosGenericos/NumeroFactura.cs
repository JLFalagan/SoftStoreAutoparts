using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LibStoreAutoparts.AdaptadorDB;

namespace SoftStoreAutoparts.Model
{
    public class NumeroFactura : INotifyPropertyChanged
    {
        private int puntoventa;
        public int PuntoVenta
        {
            get { return puntoventa; }
            set 
            {
                if (this.puntoventa != value)
                {
                    this.puntoventa = value;
                    this.NotifyPropertyChanged("PuntoVenta");
                }
            }
        }
        private int codfactura;
        public int CodFactura
        {
            get { return codfactura; }
            set 
            {
                if (this.codfactura != value)
                {
                    this.codfactura = value;
                    this.NotifyPropertyChanged("CodFactura");
                }
            }
        }
        //GBD_Ventas gestorVentas;

        //public NumeroFactura()
        //{
        //    gestorVentas = new GBD_Ventas();
        //}

        public void Autoincrementar()
        {
            NumeroFactura ultimoCodigo = new NumeroFactura(); //gestorVentas.UltimaVenta();
            if (ultimoCodigo == null)
            {
                this.puntoventa = 1;
                this.codfactura = 0;
            }
            else
            {
                this.puntoventa = ultimoCodigo.PuntoVenta;
                this.codfactura = ultimoCodigo.CodFactura;
                codfactura++;
            }    
        }
        public override string ToString() //Retorna el numero de factura en un formato normalizado tipo string
        {
            string punto_venta = PuntoVenta.ToString();
            string cod_factura = CodFactura.ToString();
            punto_venta = punto_venta.PadLeft(4, '0');
            cod_factura = cod_factura.PadLeft(8, '0');

            return punto_venta + "-" + cod_factura;
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
