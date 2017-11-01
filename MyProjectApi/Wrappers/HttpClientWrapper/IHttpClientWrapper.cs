using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProjectApi.Wrappers.HttpClientWrapper
{
    public interface IHttpClientWrapper
    {
        void Initialize(string baseUrl, string apiName);

        Task<IEnumerable<T>> GetAllAsync<T>(string apiMethod);
        Task<T> GetAsync<T>(string apiMethod);
        Task<T> DeleteAsync<T>(string apiMethod);

        Task<T> PostAsJsonAsync<T>(string apiMethod, object value);
        Task<T> PutAsJsonAsync<T>(string apiMethod, object value);

    }
}