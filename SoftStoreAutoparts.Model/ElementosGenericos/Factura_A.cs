using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Factura_A : Factura
    {
        /// <summary HERENCIA>
        /// IDFactura
        /// TipoComprobante
        /// NumeroFactura
        /// Fecha_Hora
        /// Emisor
        /// Adquirente
        /// Detalles
        /// Descuento Porc
        /// Descuento
        /// Total
        /// </summary>

        private DateTime vencimiento;
        public DateTime Vencimiento
        {
            get { return vencimiento; }
            set { vencimiento = value; }
        }
        private Estado estadopago;
        public Estado EstadoPago
        {
            get { return estadopago; }
            set { estadopago = value; }
        }
        private double subtotal;
        public double Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        private double alicuota;
        public double Alicuota
        {
            get { return alicuota; }
            set { alicuota = value; }
        }
        private double iva;
        public double IVA
        {
            get { return iva; }
            set { iva = value; }
        }
        
        public Factura_A() 
        {
            this.TipoComprobante = TipoFactura.A;
            this.Emisor.Frente_IVA = CondicionIVA.RESPONSABLE_INSCRIPTO;
            this.Adquirente.Frente_IVA = CondicionIVA.RESPONSABLE_INSCRIPTO;
            Alicuota = 0.21;
        }

        public void CalcularTotales()
        {
            Subtotal = Detalles.Sum(x => x.Importe);
            IVA = Subtotal * Alicuota;
            Total = Subtotal + IVA;
        }
        public void AplicarDescuento()
        {
            //Descuento = Subtotal * DescuentoPorc;
            //Total = Subtotal - Descuento + IVA;

            //PRUEBA
            double SubtotalNeto = 0;

            Descuento = Subtotal * DescuentoPorc;
            SubtotalNeto = Subtotal - Descuento;
            IVA = SubtotalNeto * Alicuota;
            Total = SubtotalNeto + IVA;
            //

        }
        public void RedondearValores()
        {
            Subtotal = Math.Round(Subtotal, 2);
            IVA = Math.Round(IVA, 2);
            Descuento = Math.Round(Descuento, 2);
            Total = Math.Round(Total, 2);
        }
    }
}
