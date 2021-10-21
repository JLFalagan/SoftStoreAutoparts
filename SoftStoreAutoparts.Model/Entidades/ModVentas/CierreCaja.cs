using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.Entidades.ModUsuarios;

namespace LibStoreAutoparts.Entidades.ModVentas
{
    public class CierreCaja
    {
        private int idcierrecaja;
        public int IDCierreCaja
        {
            get { return idcierrecaja; }
            set { idcierrecaja = value; }
        }
        private DateTime fechacierre;
        public DateTime FechaCierre
        {
            get { return fechacierre; }
            set { fechacierre = value; }
        }
        private double imppreviodia;
        public double ImpPrevioDia
        {
            get { return imppreviodia; }
            set { imppreviodia = value; }
        }
        private double imptotaldia;
        public double ImpTotalDia
        {
            get { return imptotaldia; }
            set { imptotaldia = value; }
        }
        private double impmovdia;
        public double ImpMovDia
        {
            get { return impmovdia; }
            set { impmovdia = value; }
        }
        private int numfacturas;
        public int NumFacturas
        {
            get { return numfacturas; }
            set { numfacturas = value; }
        }
        private double totalesfacturas;
        public double TotalesFacturas
        {
            get { return totalesfacturas; }
            set { totalesfacturas = value; }
        }
        private double totalescontado;
        public double TotalesContado
        {
            get { return totalescontado; }
            set { totalescontado = value; }
        }
        private double totalescontadotarjeta;
        public double TotalesContadoTarjeta
        {
            get { return totalescontadotarjeta; }
            set { totalescontadotarjeta = value; }
        }
        private double totalesefectivo;
        public double TotalesEfectivo
        {
            get { return totalesefectivo; }
            set { totalesefectivo = value; }
        }
        private double totalesfinanciado;
        public double TotalesFinanciado
        {
            get { return totalesfinanciado; }
            set { totalesfinanciado = value; }
        }
        private double totalestarjeta;
        public double TotalesTarjeta
        {
            get { return totalestarjeta; }
            set { totalestarjeta = value; }
        } 
        private double totaliva;
        public double TotalIVA
        {
            get { return totaliva; }
            set { totaliva = value; }
        }
        private double cierrerecuento;
        public double CierreRecuento
        {
            get { return cierrerecuento; }
            set { cierrerecuento = value; }
        }
        private double cierretotalcaja;
        public double CierreTotalCaja
        {
            get { return cierretotalcaja; }
            set { cierretotalcaja = value; }
        }
        private double cierredescuadre;
        public double CierreDescuadre
        {
            get { return cierredescuadre; }
            set { cierredescuadre = value; }
        }
        private bool cierregeneral;
        public bool CierreGeneral
        {
            get { return cierregeneral; }
            set { cierregeneral = value; }
        }

        private CuentaUsuario usuario;
        public CuentaUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private List<String> listadonumeracionventas;
        public List<String> ListadoNumeracionVentas
        {
            get { return listadonumeracionventas; }
            set { listadonumeracionventas = value; }
        }
        private ObservableCollection<VentaFacturaBase> facturas;
        public ObservableCollection<VentaFacturaBase> Facturas
        {
            get { return facturas; }
            set { facturas = value; }
        }

        public CierreCaja()
        {
            Usuario = new CuentaUsuario();
            ListadoNumeracionVentas = new List<string>();
            Facturas = new ObservableCollection<VentaFacturaBase>();
        }

        public void CerrarCaja()
        {
            double totalbasecaja = ImpPrevioDia + ImpMovDia;
            CierreRecuento = TotalesEfectivo;
            CierreDescuadre = totalbasecaja;
            CierreTotalCaja = CierreRecuento + totalbasecaja;
        }
        public void RedondearValores()
        {
            TotalesFacturas = Math.Round(TotalesFacturas, 2);
            TotalesContado = Math.Round(TotalesContado, 2);
            TotalesContadoTarjeta = Math.Round(TotalesContadoTarjeta, 2);
            TotalesEfectivo = Math.Round(TotalesEfectivo, 2);
            TotalesFinanciado = Math.Round(TotalesFinanciado, 2);
            TotalesTarjeta = Math.Round(TotalesTarjeta, 2);
            TotalIVA = Math.Round(TotalIVA, 2);
            CierreRecuento = Math.Round(CierreRecuento, 2);
            CierreDescuadre = Math.Round(CierreDescuadre, 2);
        }
        public void CargarListadoNumeracion()
        {
            foreach (VentaFacturaBase ventaBase in this.Facturas)
            {
                ListadoNumeracionVentas.Add(ventaBase.NumFactura.ToString());
            }
        }
    }
}
