using Common.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    //TODO: REVISAR COMO SE MANEJAN LAS IMAGENES EN OTROS PROYECTOS Y VER SI SE PUEDE CREAR ALGO GENERICO
    [Table("ProductColor")]
    public class ProductColor : BaseType
    {
        public string CodeColor { get; set; }
        public byte[] FileImageColor { get; set; }
    }
}
