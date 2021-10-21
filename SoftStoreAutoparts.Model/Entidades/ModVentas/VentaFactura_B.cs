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
    public class VentaFactura_B : Factura
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

        private int id_ventafactuab;
        public int ID_VentaFactuaB
        {
            get { return id_ventafactuab; }
            set { id_ventafactuab = value; }
        }
        private double subtotal;
        public double Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
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

        public VentaFactura_B()
        {
            this.TipoComprobante = TipoFactura.B;
            Pago = new PagoVenta();
            Comprador = new Cliente();
            Usuario = new CuentaUsuario();
        }

        public void CalcularTotales()
        {
            Subtotal = Detalles.Sum(x => x.Importe);
            Total = Subtotal;
        }
        public void AplicarDescuento()
        {
            Descuento = Subtotal * DescuentoPorc;
            Total = Subtotal - Descuento;
        }
        public void RedondearValores()
        {
            Subtotal = Math.Round(Subtotal, 2);
            Descuento = Math.Round(Descuento, 2);
            Total = Math.Round(Total, 2);
        }
    }
}
