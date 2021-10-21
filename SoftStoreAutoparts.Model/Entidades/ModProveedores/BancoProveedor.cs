using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStoreAutoparts.Entidades.ModProveedores
{
    public class BancoProveedor: Banco, INotifyPropertyChanged
    {
        private int idproveedor;
        public int IDProveedor
        {
            get { return idproveedor; }
            set 
            {
                if (this.idproveedor != value)
                {
                    this.idproveedor = value;
                    this.NotifyPropertyChanged("IDProveedor");
                }
            }
        }
        private string num_cuentacorriente;
        public string Num_CuentaCorriente
        {
            get { return num_cuentacorriente; }
            set 
            {
                if (this.num_cuentacorriente != value)
                {
                    this.num_cuentacorriente = value;
                    this.NotifyPropertyChanged("Num_CuentaCorriente");
                }
            }
        }
        private string cbu;
        public string CBU
        {
            get { return cbu; }
            set 
            {
                if (this.cbu != value)
                {
                    this.cbu = value;
                    this.NotifyPropertyChanged("CBU");
                }
            }
        }

        public BancoProveedor()
        { }

        //EVENTO ENCARGADO DE LANZAR UN MENSAJE DE QUE UNA PROPIEDAD O ATRIBUTO DE ESTA CLASE HA SIDO CAMBIADO
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propiedad)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
