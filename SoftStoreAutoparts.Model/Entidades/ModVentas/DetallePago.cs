using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModVentas
{
    public class DetallePago
    {
        private int iddetalle;
        public int IDDetalle
        {
            get { return iddetalle; }
            set { iddetalle = value; }
        }
        private double montofinanciado;
        public double MontoFinanciado
        {
            get { return montofinanciado; }
            set { montofinanciado = value; }
        }
        private int cantidadcuotas;
        public int CantidadCuotas
        {
            get { return cantidadcuotas; }
            set { cantidadcuotas = value; }
        }
        private double montocuota;
        public double MontoCuota
        {
            get { return montocuota; }
            set { montocuota = value; }
        }
        private double recargo;
        public double Recargo
        {
            get { return recargo; }
            set { recargo = value; }
        }
        private double porcrecargo;
        public double PorcRecargo
        {
            get { return porcrecargo; }
            set { porcrecargo = value; }
        }
        //*****
        private double recargocuota;
        public double RecargoCuota
        {
            get { return recargocuota; }
            set { recargocuota = value; }
        }

        public DetallePago()
        { }

        public void CalcularValores(double montototal)
        {
            PorcRecargo = PorcRecargo / 100;
            Recargo = montototal * PorcRecargo;
            MontoFinanciado = montototal + Recargo;
            MontoCuota = MontoFinanciado / CantidadCuotas;
            RedondearValores();
        }
        public void RedondearValores()
        {
            MontoFinanciado = Math.Round(MontoFinanciado, 2);
            MontoCuota = Math.Round(MontoCuota, 2);
            Recargo = Math.Round(Recargo, 2);
            PorcRecargo = Math.Round(PorcRecargo, 2);
        }
    }
}
