using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.ElementosGenericos;

namespace LibStoreAutoparts.Entidades.ModUsuarios
{
    public class DatosComerciales
    {
        private int iddatoscomerciales;
        public int IDDatosComerciales
        {
            get { return iddatoscomerciales; }
            set { iddatoscomerciales = value; }
        }
        private DateTime inicioactividades;
        public DateTime InicioActividades
        {
            get { return inicioactividades; }
            set { inicioactividades = value; }
        }
        private string ingersobruto;
        public string IngersoBruto
        {
            get { return ingersobruto; }
            set { ingersobruto = value; }
        }
        private CondicionIVA condicionfrenteiva;
        public CondicionIVA CondicionFrenteIVA
        {
            get { return condicionfrenteiva; }
            set { condicionfrenteiva = value; }
        }

        public DatosComerciales()
        { }
    }
}
