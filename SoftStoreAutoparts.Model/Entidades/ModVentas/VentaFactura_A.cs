using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.ElementosGenericos;
using LibStoreAutoparts.Entidades.ModClientes;
using LibStoreAutoparts.Entidades.ModUsuarios;

namespace LibStoreAutoparts.Entidades.ModVentas
{
    public class VentaFactura_A : Factura
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

        private int id_ventafactuaa;
        public int ID_VentaFactuaA
        {
            get { return id_ventafactuaa; }
            set { id_ventafactuaa = value; }
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
        private CondicionIVA condicionfrenteiva;
        public CondicionIVA CondicionFrenteIVA
        {
            get { return condicionfrenteiva; }
            set { condicionfrenteiva = value; }
        }
        private PagoVenta pago;
        public PagoVenta Pago
        {
            get { return pago; }
            set { pago = value; }
        }
        private Cliente comprador;
        public Cliente Comprador
        {
            get { return comprador; }
            set { comprador = value; }
        }
        private CuentaUsuario usuario;
        public CuentaUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        
        public VentaFactura_A()
        {
            this.TipoComprobante = TipoFactura.A;
            Pago = new PagoVenta();
            Comprador = new Cliente();
            Usuario = new CuentaUsuario();
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
