using Common.Business;
using Common.Dto;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.WebApi
{
    public class WebApiClient
    {
        private readonly RestClient client;

        //public static string JWTtoken { get; set; }
        public static string JWTtoken { get; private set; }

        private RestClient CreateClient(string baseUrl)
        {
            var client = new RestClient(baseUrl);

            // Override with Newtonsoft JSON Handler
            client.AddHandler("application/json", () => NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/json", () => NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/x-json", () => NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/javascript", () => NewtonsoftJsonSerializer.Default);
            client.AddHandler("*+json", () => NewtonsoftJsonSerializer.Default);
            client.Timeout = (1000 * 180);
            return client;
        }

        public WebApiClient(string baseUrl)
        {
            client = CreateClient(baseUrl);
            if (!string.IsNullOrEmpty(JWTtoken))
            {
                client.Authenticator = new JwtAuthenticator(JWTtoken);
            }
        }

        public void RefreshJwtToken(string jwtToken)
        {
            JWTtoken = jwtToken;

            if (!string.IsNullOrEmpty(JWTtoken))
            {
                client.Authenticator = new JwtAuthenticator(jwtToken);
            }
        }

        //public WebApiClientHelper()
        //{
        //    var baseUrl = AppCtx
        //    client = CreateClient(baseUrl);
        //    if (!string.IsNullOrEmpty(JWTtoken))
        //    {
        //        client.Authenticator = new JwtAuthenticator(JWTtoken);
        //    }
        //}

        public string AuthenticationJWT(string resource, string username, string password)
        {
            var request = new RestRequest(resource, Method.POST);
            // all parameters need to go in body as string
            var encodedBody = string.Format("username={0}&password={1}&grant_type=password", username, password);
            request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
            var response = client.Execute(request);
            if (response.IsSuccessful)
                return response.Content;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public object Get(string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            var response = client.Execute(request);
            if (response.IsSuccessful)
                return response.Content;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public T Get<T>(string resource) where T : new()
        {
            var request = new RestRequest(resource, Method.GET);
            var response = client.Execute<T>(request);
            if (response.IsSuccessful)
                return response.Data;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public async Task<T> GetAsync<T>(string resource) where T : new()
        {
            var request = new RestRequest(resource, Method.GET);
            var response = await client.ExecuteAsync<T>(request);
            if (response.IsSuccessful)
                return response.Data;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public T Get<T>(string resource, string orderBy, bool onlyEnabled = true) where T : new()
        {
            SearchCommandEventArgs args = new SearchCommandEventArgs { OrderBy = orderBy, OnlyEnabled = onlyEnabled };
            return Get<T>(resource, args);
        }

        public T Get<T>(string resource, SearchCommandEventArgs args) where T : new()
        {
            var request = new RestRequest(resource, Method.GET);
            request.AddQueryParameter("request.PageIndex", args.PageIndex.ToString());
            request.AddQueryParameter("request.PageSize", args.PageSize.ToString());
            request.AddQueryParameter("request.Filterby", args.FilterBy);
            request.AddQueryParameter("request.FilterValue", args.FilterValue);
            request.AddQueryParameter("request.OrderBy", args.OrderBy);
            request.AddQueryParameter("request.OnlyEnabled", args.OnlyEnabled.ToString());
            if (args.AdvanceFilters?.Count > 0)
            {
                foreach (var advFilter in args.AdvanceFilters)
                {
                    request.AddQueryParameter($"request.{advFilter.Key}", advFilter.Value);
                }
            }
            var response = client.Execute<T>(request);
            if (response.IsSuccessful)
                return response.Data;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        /// <summary>
        /// Metodo Get generico
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Get<T>(string resource, object args) where T : new()
        {
            var request = new RestRequest(resource, Method.GET);

            PropertyInfo[] properties = args.GetType().GetProperties();
            foreach (var property in properties)
            {
                //request.AddQueryParameter($"request.{property.Name}", property.GetValue(args)?.ToString());
                request.AddQueryParameterCustom($"request.{property.Name}", property.GetValue(args));
            }
            var response = client.Execute(request);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<T>(response.Content);
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public object Post(string resource, object dto)
        {
            var request = new RestRequest(resource, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(dto);
            var response = client.Execute(request);
            if (response.IsSuccessful)
                return response;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public T Post<T>(string resource, object dto) where T : new()
        {
            var request = new RestRequest(resource, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(dto);
            var response = client.Execute<T>(request);
            if (response.IsSuccessful)
                return response.Data;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public T Put<T>(string resource, object dto) where T : new()
        {
            var request = new RestRequest(resource, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(dto);
            var response = client.Execute<T>(request);
            if (response.IsSuccessful)
                return response.Data;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public T Put<T>(string resource) where T : new()
        {
            var request = new RestRequest(resource, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<T>(request);
            if (response.IsSuccessful)
                return response.Data;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public T Patch<T>(string resource, object dto) where T : new()
        {
            var request = new RestRequest(resource, Method.PATCH);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(dto);
            var response = client.Execute<T>(request);
            if (response.IsSuccessful)
                return response.Data;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public T Delete<T>(string resource) where T : new()
        {
            var request = new RestRequest(resource, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<T>(request);
            if (response.IsSuccessful)
                return response.Data;
            else
            {
                var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
                throw new FriendlyException(errorDto.Message);
            }
        }

        public IRestResponse Execute(IRestRequest request)
        {
            var response = client.Execute(request);
            return response;
        }

        //#region SET TOKEN
        //public WebApiClientHelper(string tokenstring) : this()
        //{
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenstring);
        //}

        //public void SetToken(string tokenstring)
        //{
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenstring);
        //}
    }
}
