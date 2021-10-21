using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LibStoreAutoparts.AdaptadorDB;

namespace SoftStoreAutoparts.Model
{
    public class GeneradorCodigo
    {
        private string CodigoProducto;

        public GeneradorCodigo()
        {}

        public string Generar_CodProd(string tipoProducto, int idTipoProd) //Genera un Codigo para un producto
        {
            string tipo = tipoProducto.Substring(0, 2);         
            string idtipo = idTipoProd.ToString();
            string cabecera = tipo + idtipo;
            string subcod = RecuperarCodigoProd(cabecera).ToString().PadLeft(5, '0');
            CodigoProducto = cabecera + subcod;

            return CodigoProducto;
            
        }
        public int RecuperarCodigoProd(string argEntrada) //Busca en la DB la cantidad de productos de un Tipo determinado
        {
            //GBD_Productos gestorProductos = new GBD_Productos();
            //int cant = gestorProductos.EvaluarUltCodigoProd(argEntrada);
            int cant = 201;
            return cant;
        }
    }
}
