using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStoreAutoparts.ElementosGenericos;

namespace LibStoreAutoparts.Entidades.ModUsuarios
{
    public class Empresa 
    {
        private int idempresa;
        public int IDEmpresa
        {
            get { return idempresa; }
            set { idempresa = value; }
        }
        private string nombcomercial;
        public string NombreComercial
        {
            get { return nombcomercial; }
            set { nombcomercial = value; }
        }
        private string razonsocial;
        public string RazonSocial
        {
            get { return razonsocial; }
            set { razonsocial = value; }
        }
        private long cuitcuil;
        public long Cuit_Cuil
        {
            get { return cuitcuil; }
            set { cuitcuil = value; }
        }
        private string domiciliocomercial;
        public string DomicilioComercial
        {
            get { return domiciliocomercial; }
            set { domiciliocomercial = value; }
        }
        private string ciudad;
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
        private string codpostal;
        public string CodigoPostal
        {
            get { return codpostal; }
            set { codpostal = value; }
        }
        private string provincia;
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
        private long telefono;
        public long Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private long fax;
        public long Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        private long movil;
        public long Movil
        {
            get { return movil; }
            set { movil = value; }
        }
        private string sitioweb;
        public string SitioWeb
        {
            get { return sitioweb; }
            set { sitioweb = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private DatosComerciales informacioncomercial;
        public DatosComerciales InformacionComercial
        {
            get { return informacioncomercial; }
            set { informacioncomercial = value; }
        }

        public Empresa()
        {
            InformacionComercial = new DatosComerciales();
        }
    }
}
