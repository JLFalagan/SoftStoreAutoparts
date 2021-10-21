using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{ 
    public class PersonaFisica : PersonaJuridica
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private int dni;
        public int DNI
        {
            get { return dni; }
            set { dni = value; }
        }
        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private string ciudad;
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
        private string codigopostal;
        public string CodigoPostal
        {
            get { return codigopostal; }
            set { codigopostal = value; }
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
        private long movil;
        public long Movil
        {
            get { return movil; }
            set { movil = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private DateTime fecha_nac;
        public DateTime FechaNacimiento
        {
            get { return fecha_nac; }
            set { fecha_nac = value; }
        }
        private DateTime fechaalta;
        public DateTime FechaAlta
        {
            get { return fechaalta; }
            set { fechaalta = value; }
        }

        public PersonaFisica()
        { }
    }
}
