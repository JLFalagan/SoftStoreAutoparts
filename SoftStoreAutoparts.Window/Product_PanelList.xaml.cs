using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoftStoreAutoparts.Window
{
    /// <summary>
    /// Lógica de interacción para Product_List.xaml
    /// </summary>
    public partial class Product_PanelList : UserControl, IWindowsList
    {
        public Product_PanelList()
        {
            InitializeComponent();
        }

        public void AddItem()
        {
            throw new NotImplementedException();
        }

        public void DeleteItem()
        {
            throw new NotImplementedException();
        }

        public void EditItem()
        {
            throw new NotImplementedException();
        }

        private void dgvLProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
