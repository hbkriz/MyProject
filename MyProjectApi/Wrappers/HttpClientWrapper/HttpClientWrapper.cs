using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace MyProjectApi.Wrappers.HttpClientWrapper
{
    public class HttpClientWrapper: IHttpClientWrapper
    {
        private const string JsonHeader = "application/json";
        private string _apiName;
        private HttpClient _httpClient;

        public void Initialize(string baseUrl, string apiName)
        {
            var httpClientHandler = new HttpClientHandler
            {
                UseDefaultCredentials = true,
                ClientCertificateOptions = ClientCertificateOption.Automatic
            };

            _httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(baseUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonHeader));
            _apiName = apiName;
        }
        
        public async Task<T> GetAsync<T>(string apiMethod)
        {
            return await ReadResponse<T>(HandleRequest(() => _httpClient.GetAsync(apiMethod)));
        }
        
        public async Task<T> DeleteAsync<T>(string apiMethod)
        {
            return await ReadResponse<T>(HandleRequest(() => _httpClient.DeleteAsync(apiMethod)));
        }

        public async Task<T> PutAsJsonAsync<T>(string apiMethod, object value)
        {
            return await ReadResponse<T>(HandleRequest(() => _httpClient.PutAsJsonAsync(apiMethod, value)));
        }


        public async Task<T> PostAsJsonAsync<T>(string apiMethod, object value)
        {
            return await ReadResponse<T>(HandleRequest(() => _httpClient.PostAsJsonAsync(apiMethod, value)));
        }

        private async Task<HttpResponseMessage> HandleRequest(Func<Task<HttpResponseMessage>> apiMethod)
        {
            return await apiMethod();
        }

        private async Task<T> ReadResponse<T>(Task<HttpResponseMessage> responseAsync)
        {
            var response = await responseAsync;

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            throw new InvalidOperationException( $"API Server ({_apiName}) returned HTTP error Uri : {response.RequestMessage.RequestUri} | {(int)response.StatusCode} : {response.ReasonPhrase}. ");
        }

        #region ODATA Specific
        
        public async Task<T> GetODataAsync<T>(string apiMethod)
        {
            return await ReadODataResponse<T>(HandleRequest(() => _httpClient.GetAsync(apiMethod)));
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string apiMethod)
        {
            return await ReadResponse<IEnumerable<T>>(HandleRequest(() => _httpClient.GetAsync(apiMethod)));
        }

        private async Task<T> ReadODataResponse<T>(Task<HttpResponseMessage> responseAsync)
        {
            var response = await responseAsync;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ODataResponse<T>>(json);
                var results = result.Value;

                return await response.Content.ReadAsAsync<T>();
            }
            throw new InvalidOperationException($"OData Server ({_apiName}) returned HTTP error Uri : {response.RequestMessage.RequestUri} | {(int)response.StatusCode} : {response.ReasonPhrase}. ");
        }

        #endregion
    }

    internal class ODataResponse<T>
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }
        [JsonProperty("value")]
        public T Value { get; set; }
    }
}