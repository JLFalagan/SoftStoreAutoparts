using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModVentas
{
    public class PagoVenta
    {
        private int idpago;
        public int IDPago
        {
            get { return idpago; }
            set { idpago = value; }
        }
        private FormaPagoVenta formapago;
        public FormaPagoVenta FormaPago
        {
            get { return formapago; }
            set { formapago = value; }
        }
        private double importefinal;
        public double ImporteFinal
        {
            get { return importefinal; }
            set { importefinal = value; }
        }
        private bool sintarjeta;
        public bool SinTarjeta
        {
            get { return sintarjeta; }
            set { sintarjeta = value; }
        }
        private TipoPagoVenta tipopago;
        public TipoPagoVenta TipoPago
        {
            get { return tipopago; }
            set { tipopago = value; }
        }
        private Tarjetas tarjeta_cc_ca;
        public Tarjetas TarjetaCC_CA
        {
            get { return tarjeta_cc_ca; }
            set { tarjeta_cc_ca = value; }
        }
        private DetallePago detalle;
        public DetallePago Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        public PagoVenta()
        {
            SinTarjeta = false;
            Detalle = new DetallePago();
        }
    }
}
