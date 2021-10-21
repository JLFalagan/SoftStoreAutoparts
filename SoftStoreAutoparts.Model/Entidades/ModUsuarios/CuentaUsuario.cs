using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModUsuarios
{
    public class CuentaUsuario
    {
        private int idcuentausuario;
        public int IDCuentaUsuario
        {
            get { return idcuentausuario; }
            set { idcuentausuario = value; }
        }
        private string nombreusuario;
        public string NombreUsuario
        {
            get { return nombreusuario; }
            set { nombreusuario = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                encriptadorMD5.PasswordInput = value;
                password = encriptadorMD5.ObtenerHashMD5();
            }
        }
        private DateTime fecharegistro;
        public DateTime FechaRegistro
        {
            get { return fecharegistro; }
            set { fecharegistro = value; }
        }
        private TipoPerfil perfilaccesso;
        public TipoPerfil PerfilAccesso
        {
            get { return perfilaccesso; }
            set { perfilaccesso = value; }
        }

        EncriptadorMD5 encriptadorMD5;

        public CuentaUsuario()
        {
            PerfilAccesso = new TipoPerfil();
            encriptadorMD5 = new EncriptadorMD5();
        }

        public CuentaUsuario(string nombU, string passU)
        {
            PerfilAccesso = new TipoPerfil();
            encriptadorMD5 = new EncriptadorMD5();
            this.nombreusuario = nombU;
            this.password = passU;
        }
        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
