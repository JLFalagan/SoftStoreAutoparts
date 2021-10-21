using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Costo : INotifyPropertyChanged
    {
        #region ATRIBUTOS Y PROPIEDADES

        private int idproducto;
        public int IDProducto
        {
            get { return idproducto; }
            set { idproducto = value; }
        }
        private double preciocompra;
        public double PrecioCompra
        {
            get { return preciocompra; }
            set
            {
                if (this.preciocompra != value)
                {
                    this.preciocompra = value;
                    this.NotifyPropertyChanged("PrecioCompra");
                }
            }
        }
        private double ganancia;
        public double Ganancia
        {
            get { return ganancia; }
            set
            {
                if (this.ganancia != value)
                {
                    this.ganancia = value;
                    this.NotifyPropertyChanged("Ganancia");
                }
            }
        }
        private double totalsiva;
        public double TotalSIVA
        {
            get { return totalsiva; }
            set
            {
                if (this.totalsiva != value)
                {
                    this.totalsiva = value;
                    this.NotifyPropertyChanged("TotalSIVA");
                }
            }
        }
        private double totalciva;
        public double TotalCIVA
        {
            get { return totalciva; }
            set
            {
                if (this.totalciva != value)
                {
                    this.totalciva = value;
                    this.NotifyPropertyChanged("TotalCIVA");
                }
            }
        }
        #endregion

        public Costo() //Constructor Base
        { }

        public Costo(double precio_compra) //Constructor
        {
            PrecioCompra = precio_compra;
            CalcularCostos();
        }

        public void ActualizarValores(double precio_compra)
        {
            PrecioCompra = precio_compra;
            CalcularCostos();
        }
        private void CalcularCostos()
        {
            double ganancia_out = 0.3; //SE LEE DESDE UN ARCHIVO EXTERNO
            Ganancia = PrecioCompra * ganancia_out;
            TotalSIVA = PrecioCompra + Ganancia;
            TotalCIVA = PrecioCompra + Ganancia + CalcularIVA();
        }
        public double CalcularIVA()
        {
            //double valoriva = PrecioCompra * 0.21;
            double valoriva = TotalSIVA * 0.21;
            return valoriva;
        }
        public void RedondearValores()
        {
            PrecioCompra = Math.Round(PrecioCompra, 2);
            Ganancia = Math.Round(Ganancia, 2);
            TotalSIVA = Math.Round(TotalSIVA, 2);
            TotalCIVA = Math.Round(TotalCIVA, 2);
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
