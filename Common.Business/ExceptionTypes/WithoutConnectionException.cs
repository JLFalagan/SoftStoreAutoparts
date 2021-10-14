using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Business
{
    [Serializable]
    public class WithoutConnectionException : Exception
    {
        public WithoutConnectionException(string message = "No hay conexion con el Servidor") : base(message) { }

        public WithoutConnectionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
