using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.Model
{
    public class Jerarquia
    {
        public int NumMtps { get; set; } 
        public ObservableCollection<Metatipo> Metatipos { get; set; }

        public Jerarquia()
        {
            Metatipos = new ObservableCollection<Metatipo>();
        }
    }

    public class Metatipo
    {
        public int ID { get; set; }
        public string NombreMetatipo { get; set; }
        public int NumStpsElementos { get; set; }
        public ObservableCollection<Subtipo> Subtipos { get; set; }

        public Metatipo()
        {
            Subtipos = new ObservableCollection<Subtipo>();
        }
    }
    public class Subtipo
    {
        public int ID { get; set; }
        public int IDMetatipo { get; set; }
        private string nombresubtipo;
        public string NombreSubtipo
        {
            get { return nombresubtipo; }
            set { nombresubtipo = Titular(value); }
        }
        public int NumElementos { get; set; }

        public Subtipo()
        {/*CONSTRUCTOR*/}

        private string Titular(string nombNomb)
        {
            return nombNomb.Substring(0, 1) + nombNomb.Substring(1, (nombNomb.Length - 1)).ToLower();
        }
    }
}
