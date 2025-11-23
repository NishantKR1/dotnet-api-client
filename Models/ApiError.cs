namespace ApiClientReference.Models
{
    public class ApiError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string RawResponse { get; set; }
    }
}