using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class DatosAdquirente : PersonaJuridica
    {
        /// <summary HERENCIA>
        /// ID
        /// RazonSocial
        /// DomicilioComercial
        /// CUIT
        /// CondicionIVA Frente_IVA
        /// </summary>

        private List<Int32> remitos;
        public List<Int32> Remitos
        {
            get { return remitos; }
            set { remitos = value; }
        }

        public DatosAdquirente()
        {
            Remitos = new List<int>();
        }

        public void AdjuntarRemitos(string numerosRemitos)
        {
            if (numerosRemitos.Contains(" ") == true)
                numerosRemitos = numerosRemitos.Replace(' ', '/');

            string[] ArregloRemitos = numerosRemitos.Split('/');
            foreach (string numero in ArregloRemitos)
            {
                int num_remito = Int32.Parse(numero);
                Remitos.Add(num_remito);
            }
        }
    }
}
