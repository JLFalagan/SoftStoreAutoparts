using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Reflection;
using NeyTI.DynamicReports.Dto;
using System.Net;
using System.Text.Json;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Linq;

namespace Common.WebApi
{
    public class WebApiConnectionService
    {

        private readonly HttpClient _httpClient;


        private readonly IHttpContextAccessor _contextAccessor;
       

        public WebApiConnectionService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _httpClient = httpClient;
            var claimToken = contextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "authToken");
            if (claimToken != null)
            {
                var jwt = claimToken.Value;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }
   
        }


        public async Task<SigninResultDto> AuthenticationJWT(string resource, CredentialsDto credentials)
        {
            try
            {
                var loginAsJson = JsonSerializer.Serialize(credentials);
                var response = await _httpClient.PostAsync("api/Authentication", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
                var loginResult = JsonSerializer.Deserialize<SigninResultDto>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (response.IsSuccessStatusCode)
                {
                    return loginResult;
                }

                _contextAccessor.HttpContext.Session.SetString("JwtToken", loginResult.AccessToken);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.AccessToken);

                return loginResult;
            }
            catch (Exception ex)
            {
                throw new FriendlyException(ex.Message);
            }
        }

        public async Task<object> GetAsync(string resource)
        {
                       var response = await _httpClient.GetAsync(resource);

            if (response.IsSuccessStatusCode)
                return response.Content;
            else
            {
                var errorDto = await response.Content.ReadFromJsonAsync<ExceptionDto>();
                throw new FriendlyException(errorDto.Message);
            }
        }

        public T Get<T>(string resource) where T : new()
        {
            Task<HttpResponseMessage> task = Task.Run<HttpResponseMessage>(async () => await _httpClient.GetAsync(resource));
            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadFromJsonAsync<T>().Result;
                return result;
            }
            else
            {
                var errorDto = response.Content.ReadFromJsonAsync<ExceptionDto>().Result;
                throw new FriendlyException(errorDto.Message);
            }
        }

        //public async Task<T> GetAsync<T>(string resource) where T : new()
        //{

        //    var request = new RestRequest(resource, Method.GET);
        //    T result = default(T);
        //    var response = client.ExecuteAsync<T>(request, response =>
        //    {
        //        if(response.Data != null)
        //            result = response.Data;
        //        else
        //        {
        //            //var errorDto = JsonConvert.DeserializeObject<ExceptionDto>(response.Content);
        //            //throw new FriendlyException(errorDto.Message);
        //            throw new Exception();
        //        }
        //    });
        //    return result;
        //}

        public T Get<T>(string resource, PagingSortFilterRequest args) where T : new()
        {

            UriBuilder builder = new UriBuilder($"{_httpClient.BaseAddress}{resource}");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["request.PageIndex"] = args.PageIndex.ToString();
            query["request.PageSize"] = args.PageSize.ToString();
            query["request.Filterby"] = args.FilterBy;
            query["request.FilterValue"] = args.FilterValue;
            query["request.OrderBy"] = args.OrderBy;
            query["request.OnlyEnabled"] = args.OnlyEnabled.ToString();
            builder.Query = query.ToString();
         
            Task<HttpResponseMessage> task = Task.Run<HttpResponseMessage>(async ()
                => await _httpClient.GetAsync(builder.ToString()));
            var response = task.Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadFromJsonAsync<T>().Result;
                return result;
            }
            else
            {
                var errorDto = response.Content.ReadFromJsonAsync<ExceptionDto>().Result;
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
        public async Task<T> Get<T>(string resource, object args) where T : new()
        {
            UriBuilder builder = new UriBuilder($"{_httpClient.BaseAddress}/{resource}");
            var query = HttpUtility.ParseQueryString(builder.Query);

            PropertyInfo[] properties = args.GetType().GetProperties();
            foreach (var property in properties)
            {
                AddQueryParameterCustom(query, $"request.{property.Name}", property.GetValue(args));
            }

            var response = await _httpClient.GetAsync(builder.ToString());

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = await response.Content.ReadFromJsonAsync<T>();
                return data;
            }
            else
            {
                var errorDto = await response.Content.ReadFromJsonAsync<ExceptionDto>();
                throw new FriendlyException(errorDto.Message);
            }
        }

        public void AddQueryParameterCustom(NameValueCollection query, string name, object value)
        {
            string stringValue = string.Empty;
            if (value != null)
            {
                var typeName = value.GetType().Name;
                var nullType = Nullable.GetUnderlyingType(value.GetType());
                if (nullType != null)
                    typeName = nullType.Name;

                switch (typeName)
                {
                    case "DateTime":
                        var dateTime = Convert.ToDateTime(value);
                        stringValue = dateTime.ToString("yyyyMMdd");
                        break;
                    default:
                        stringValue = value?.ToString();
                        break;
                }
            }

            query[name] = stringValue;
        }

        public async Task<T> Get<T>(string resource, string orderBy, bool onlyEnabled = true) where T : new()
        {
            PagingSortFilterRequest args = new PagingSortFilterRequest { OrderBy = orderBy, OnlyEnabled = onlyEnabled };
            return Get<T>(resource, args);
        }

        public async Task<object> Post(string resource, object dto)
        {
            var dtoAsJson = JsonSerializer.Serialize(dto);
            var response = await _httpClient.PostAsync(resource, new StringContent(dtoAsJson, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return response.Content;
            else
            {
                var errorDto = await response.Content.ReadFromJsonAsync<ExceptionDto>();
                throw new FriendlyException(errorDto.Message);
            }
        }

        public async Task<T> Post<T>(string resource, object dto) where T : new()
        {
            var dtoAsJson = JsonSerializer.Serialize(dto);
            var response = await _httpClient.PostAsync(resource, new StringContent(dtoAsJson, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result;
            }
            else
            {
                var errorDto = await response.Content.ReadFromJsonAsync<ExceptionDto>();
                throw new FriendlyException(errorDto.Message);
            }
        }

        public async Task<T> Put<T>(string resource, object dto) where T : new()
        {
            var dtoAsJson = JsonSerializer.Serialize(dto);
            var response = await _httpClient.PutAsync(resource, new StringContent(dtoAsJson, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();
            else
            {
                var errorDto = await response.Content.ReadFromJsonAsync<ExceptionDto>();
                throw new FriendlyException(errorDto.Message);
            }
        }

        public async Task<T> Put<T>(string resource) where T : new()
        {
            var response = await _httpClient.PutAsync(resource, null);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();
            else
            {
                var errorDto = await response.Content.ReadFromJsonAsync<ExceptionDto>();
                throw new FriendlyException(errorDto.Message);
            }
        }

        public async Task<T> Patch<T>(string resource, object dto) where T : new()
        {
            var dtoAsJson = JsonSerializer.Serialize(dto);
            var response = await _httpClient.PatchAsync(resource, new StringContent(dtoAsJson, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();
            else
            {
                var errorDto = await response.Content.ReadFromJsonAsync<ExceptionDto>();
                throw new FriendlyException(errorDto.Message);
            }
        }

        public async Task<T> Delete<T>(string resource) where T : new()
        {
            var response = await _httpClient.DeleteAsync(resource);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();
            else
            {
                var errorDto = await response.Content.ReadFromJsonAsync<ExceptionDto>();
                throw new FriendlyException(errorDto.Message);
            }
        }
    }

}
