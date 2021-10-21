using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModUsuarios
{
    public class EncriptadorMD5
    {
        private MD5 MD5HashPasswords;
        private string passwordinput;
        public string PasswordInput
        {
            get { return passwordinput; }
            set { passwordinput = value; }
        }
        private string passwordhash;
        public string PasswordHash
        {
            get { return passwordhash; }
            set { passwordhash = value; }
        }

        public EncriptadorMD5()
        {
            MD5HashPasswords = MD5.Create();
        }

        //la informacion devuelta debe ser enviada a la db (que es el hash)
        public string ObtenerHashMD5()  //Al registrarse el usuario se crea un hash y se guarda en la DB
        {
            byte[] data = MD5HashPasswords.ComputeHash(Encoding.UTF8.GetBytes(passwordinput));
            StringBuilder cadenamod = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                cadenamod.Append(data[i].ToString("x2"));
            }

            return cadenamod.ToString();
        }
        //Realiza la verificacion, obtiene los datos de entrada y trae el hash de la db
        public bool VerificarHashMD5()
        {
            string hash_entrada = ObtenerHashMD5();
            StringComparer comparador = StringComparer.OrdinalIgnoreCase;
            if (0 == comparador.Compare(hash_entrada, PasswordHash))
                return true;
            else
                return false;
        }
    }
}
