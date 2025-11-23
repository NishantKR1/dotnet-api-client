using ApiClientReference.Interfaces;
using ApiClientReference.Models;
using System.Text;
using System.Text.Json;

namespace ApiClientReference.Service
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(HttpClient http)
        {
            _http = http;
        }

        private async Task<ApiResult<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            var raw = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var data = JsonSerializer.Deserialize<T>(raw, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });


                return new ApiResult<T>
                {
                    IsSuccess = true,
                    Data = data
                };
            }

            return new ApiResult<T>
            {
                IsSuccess = false,
                Error = new ApiError
                {
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase,
                    RawResponse = raw
                }
            };
        }

        public async Task<ApiResult<T>> GetAsync<T>(string url)
        {
            var response = await _http.GetAsync(url);
            return await HandleResponse<T>(response);
        }

        public async Task<ApiResult<T>> PostAsync<T>(string url, object body)
        {
            var json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(url, content);
            return await HandleResponse<T>(response);
        }

        public async Task<ApiResult<T>> PutAsync<T>(string url, object body)
        {
            var json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PutAsync(url, content);
            return await HandleResponse<T>(response);
        }

        public async Task<ApiResult<T>> DeleteAsync<T>(string url)
        {
            var response = await _http.DeleteAsync(url);
            return await HandleResponse<T>(response);
        }
    }
}
