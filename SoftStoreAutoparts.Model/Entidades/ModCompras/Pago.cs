using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.AdaptadorDB;
using LibStoreAutoparts.ElementosGenericos;
using LibStoreAutoparts.Entidades.ModProveedores;

namespace LibStoreAutoparts.Entidades.ModCompras
{
    public class Pago
    {
        private int idpago;
        public int IDPago
        {
            get { return idpago; }
            set { idpago = value; }
        }
        private DateTime fechapago;
        public DateTime FechaPago
        {
            get { return fechapago; }
            set { fechapago = value; }
        }
        private FormaPago formadepago;
        public FormaPago FormadePago
        {
            get { return formadepago; }
            set { formadepago = value; }
        }
        private double importe;
        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }
        private double saldoanterior;
        public double SaldoAnterior
        {
            get { return saldoanterior; }
            set { saldoanterior = value; }
        }
        private double totalpagar;
        public double TotalPagar
        {
            get { return totalpagar; }
            set { totalpagar = value; }
        }
        private double pagoactual;
        public double PagoActual
        {
            get { return pagoactual; }
            set { pagoactual = value; }
        }
        private double saldocontra;
        public double SaldoContra
        {
            get { return saldocontra; }
            set { saldocontra = value; }
        }
        private double saldofavor;
        public double SaldoFavor
        {
            get { return saldofavor; }
            set { saldofavor = value; }
        }
        private Proveedor proveedor;
        public Proveedor Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }
        private bool cerrado;
        public bool Cerrado
        {
            get { return cerrado; }
            set { cerrado = value; }
        }
        private int id_pagoanterior;
        public int Id_PagoAnterior
        {
            get { return id_pagoanterior; }
            set { id_pagoanterior = value; }
        }
        private ObservableCollection<Factura_A> facturascompras;
        public ObservableCollection<Factura_A> FacturasCompras
        {
            get { return facturascompras; }
            set { facturascompras = value; }
        }

        public Pago()
        {
            Proveedor = new Proveedor();
            FacturasCompras = new ObservableCollection<Factura_A>();
        }

        public double SetearSaldoAnterior() //Establece el signo del saldo que ha quedado del pago anterior (Saldo en Contra + ó Saldo a Favor -)
        {
            double saldo_base = 0; 

            if (this.SaldoContra != 0 && this.SaldoFavor == 0)
                return saldo_base = this.SaldoContra;
            else if (this.SaldoFavor != 0 && this.SaldoContra == 0)
                return saldo_base = -this.SaldoFavor;
            else
                return saldo_base;
        }
        public void CalcularTotalFinal()
        {
            TotalPagar = Importe + SaldoAnterior;
        }
        public void SetNuevoSaldo()
        {
            double nuevosaldo = this.TotalPagar - this.PagoActual;
            //PRUEBA
            //if (TotalPagar != 0)
            //{
            //    if (nuevosaldo < 0)
            //        this.SaldoFavor = nuevosaldo * (-1);
            //    else if (nuevosaldo > 0)
            //        this.SaldoContra = nuevosaldo; 
            //}
            //
            if (nuevosaldo < 0)
                this.SaldoFavor = nuevosaldo * (-1);
            else if (nuevosaldo > 0)
                this.SaldoContra = nuevosaldo;           
        }
        public void ResetearSaldos()
        {
            this.saldocontra = 0;
            this.saldofavor = 0;
        }
        public void SetearTotalFinal()
        {
            if (TotalPagar < 0)
                TotalPagar = TotalPagar * (-1);
        }       
        public void EstablecerCierre()
        {
            if (this.SaldoFavor != 0 || this.SaldoContra != 0)
                this.Cerrado = false;
            else
                this.Cerrado = true;
        }
        public void RedondearValores()
        {
            Importe = Math.Round(Importe, 2);
            SaldoAnterior = Math.Round(SaldoAnterior, 2);
            TotalPagar = Math.Round(TotalPagar, 2);
            PagoActual = Math.Round(PagoActual, 2);
            SaldoContra = Math.Round(SaldoContra, 2);
            SaldoFavor = Math.Round(SaldoFavor, 2);
        }

        public void PagoCerrado(double importeTotal, double pagado)
        {
            Importe = importeTotal;
            TotalPagar = importeTotal;
            PagoActual = pagado;
            SaldoAnterior = 0;
            SaldoFavor = 0;
            SaldoContra = 0;
            Cerrado = true;
            Id_PagoAnterior = 0;
        }        
    }
}
