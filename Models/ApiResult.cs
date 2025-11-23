namespace ApiClientReference.Models
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public ApiError Error { get; set; }
    }
}