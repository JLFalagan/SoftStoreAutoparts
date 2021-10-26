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
using Common.Dto;
using Common.WebApi;
using SoftStoreAutoparts.API.Models;
//using RestSharp;
//using RestRequest = RestSharp.RestRequest;
//using DataFormat = RestSharp.DataFormat;

namespace SoftStoreAutoparts.Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //Test();
        }

        public void Test()
        {
            string url = "https://localhost:44317";
            var WebApiClient = new WebApiClient(url);
            //var token = WebApiClient.AuthenticationJWT("/api/Authentication", "joseluisfalagan4470@gmail.com", "Admin2021!");


            WebApiClient.Get("api/Account/EchoPing");

            //UserInfo userInfo = new UserInfo() { Email = "joseluisfalagan4470@gmail.com", Password = "Admin2021!" };

            //var result = WebApiClient.Post<PostResultDto>("api/Account/Loggin", userInfo);
            //WebApiClient.RefreshJwtToken(token);

            //TEST - FUNCIONANDO *****************************************************
            //RestClient restClient = new RestClient(url);
            //var request = new RestRequest("api/Account/EchoPing", Method.GET);
            //request.RequestFormat = DataFormat.Json;
            //var response = restClient.Execute(request);
            //TEST - FUNCIONANDO *****************************************************
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            ResetearContenedores();
            Product_PanelList listadoProd = AbrirListadoProductos();
            //CargarMenuProductos(listadoProd);
            //CargarBuscadorProductos(listadoProd);
        }
        public Product_PanelList AbrirListadoProductos()
        {
            Product_PanelList listproductos = new Product_PanelList();

            listproductos.Height = PanelPrincipal.Height;
            listproductos.Width = PanelPrincipal.Width;

            PanelPrincipal.Children.Clear();
            PanelPrincipal.Children.Add(listproductos);
            AjustarPanel(PanelPrincipal);
            //listproductos.opener = this;

            return listproductos;
        }

        #region Metodos AUXILIARES
        private void AjustarPanel(Grid panelcontenedor) //Ajusta el panel contenedor de forma relativa a su contenido
        {
            panelcontenedor.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            panelcontenedor.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        }
        private void ResetearPanel(Grid panelsecundario, Expander expanzor, double altura, string titulo, bool estado)
        {
            panelsecundario.Height = altura;
            expanzor.Header = titulo;
            expanzor.IsExpanded = estado;
        }
        private void ResetearContenedores()
        {
            PanelPrincipal.Children.Clear();
            PanelBusqueda.Children.Clear();
            PanelUtilidades.Children.Clear();
            ExpBusqueda.IsExpanded = false;
            ExpUtilidades.IsExpanded = false;
        }
        #endregion

        private UserControl ShowPanelChild(UserControl panelChild)
        {
            ResetearContenedores();
            panelChild.Height = PanelPrincipal.Height;
            panelChild.Width = PanelPrincipal.Width;
            PanelPrincipal.Children.Clear();
            PanelPrincipal.Children.Add(panelChild);
            AjustarPanel(PanelPrincipal);

            return panelChild;
        }
    }
}
