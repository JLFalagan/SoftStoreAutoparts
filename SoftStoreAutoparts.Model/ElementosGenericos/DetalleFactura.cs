using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LibStoreAutoparts.Entidades.ModProductos;

namespace SoftStoreAutoparts.Model
{
    public class DetalleFactura : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int iddetalle;
        public int IDDetalle
        {
            get { return iddetalle; }
            set { iddetalle = value; }
        }
        private Producto producto;
        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }
        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; ActualizarValor(); }
        }
        private double preciounitario;
        public double PrecioUnitario
        {
            get { return preciounitario; }
            set { preciounitario = value; ActualizarValor(); }
        }
        private double importe;
        public double Importe
        {
            get { return importe; }
            set { importe = value; ActualizarValor(); }
        }
        private bool SetVenta;

        public DetalleFactura()
        {
            Producto = new Producto();
            SetVenta = false;
        }

        public DetalleFactura(int cant, double prec) //CONSTRUCTOR BASE para Entrada de productos al Almacen
        {
            Producto = new Producto();
            Cantidad = cant;
            PrecioUnitario = prec;
            Importe = CalcularImporte();
            SetVenta = false;
        }

        public DetalleFactura(int cant, string tipofact, Producto prod) //CONSTRUCTOR BASE para Salida (o Venta) de productos
        {
            SetVenta = true;
            Producto = new Producto();
            Producto = prod;
            Cantidad = cant;
            switch (tipofact)
            {
                case "A":
                    PrecioUnitario = Producto.Costos.TotalSIVA;
                    break;
                case "B":
                    PrecioUnitario = Producto.Costos.TotalCIVA;
                    break;
                default:
                    break;
            }
        }

        private void ActualizarValor()
        {
            importe = CalcularImporte();
            OnPropertyChanged("Cantidad");
            OnPropertyChanged("PrecioUnitario");
            OnPropertyChanged("Importe");
        }
        protected double CalcularImporte()
        {
            return Cantidad * PrecioUnitario;
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }

        //public void GuardarCostos() NO ES NECESARIO AL MENOS POR AHORA
        //{ }
    }
}
