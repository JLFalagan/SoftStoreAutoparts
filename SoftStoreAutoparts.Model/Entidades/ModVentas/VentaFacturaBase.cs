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
    public class VentaFacturaBase : Factura
    {
        private int id_ventafacturabase;
        public int Id_VentaFacturaBase
        {
            get { return id_ventafacturabase; }
            set { id_ventafacturabase = value; }
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
        public double Iva
        {
            get { return iva; }
            set { iva = value; }
        }
        private CondicionIVA condicionfrenteiva;
        public CondicionIVA CondicionFrenteIva
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
        private string vendedor;
        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        public VentaFacturaBase()
        {
            Alicuota = 0.21;
            Pago = new PagoVenta();
            Comprador = new Cliente();
            Usuario = new CuentaUsuario();
        }
    }
}
