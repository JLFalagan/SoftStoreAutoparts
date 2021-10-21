using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModUsuarios
{
    public class DetalleLaboral
    {
        private int iddetallelaboral;
        public int IDDetalleLaboral
        {
            get { return iddetallelaboral; }
            set { iddetallelaboral = value; }
        }
        private DateTime fechaactual;
        public DateTime FechaActual
        {
            get { return fechaactual; }
            set { fechaactual = value; }
        }
        private TimeSpan horaentrada;
        public TimeSpan Hora_Entrada
        {
            get { return horaentrada; }
            set { horaentrada = value; }
        }
        private TimeSpan horasalida;
        public TimeSpan Hora_Salida
        {
            get { return horasalida; }
            set { horasalida = value; }
        }
        private int horasdia;
        public int Horas_TotalesDia
        {
            get { return horasdia; }
            set { horasdia = value; }
        }
        private int horasextra;
        public int Horas_Extra
        {
            get { return horasextra; }
            set { horasextra = value; }
        }
        private bool presentismo;
        public bool Presentismo
        {
            get { return presentismo; }
            set { presentismo = value; }
        }
        private int id_empleado;
        public int Id_Empleado
        {
            get { return id_empleado; }
            set { id_empleado = value; }
        }

        private string asistencia;
        public string Asistencia
        {
            get 
            {
                if (Presentismo == true)
                    return "Presente";
                else
                    return "Ausente";
            }
        }

        public DetalleLaboral()
        {
        }
    }
}
