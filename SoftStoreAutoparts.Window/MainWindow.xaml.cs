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
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test();
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
    }
}
