using ApiClientReference.Models;

namespace ApiClientReference.Interfaces
{
    public interface IApiClient
    {
        Task<ApiResult<T>> GetAsync<T>(string url);
        Task<ApiResult<T>> PostAsync<T>(string url, object body);
        Task<ApiResult<T>> PutAsync<T>(string url, object body);
        Task<ApiResult<T>> DeleteAsync<T>(string url);
    }
}