using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class PersonaJuridica
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string razonsocial;
        public string RazonSocial
        {
            get { return razonsocial; }
            set { razonsocial = value; }
        }
        private string domiciliocomercial;
        public string DomicilioComercial
        {
            get { return domiciliocomercial; }
            set { domiciliocomercial = value; }
        }
        private long ciut;
        public long CUIT
        {
            get { return ciut; }
            set { ciut = value; }
        }
        private CondicionIVA frenteiva;
        public CondicionIVA Frente_IVA
        {
            get { return frenteiva; }
            set { frenteiva = value; }
        }

        public PersonaJuridica()
        { }
    }
}
