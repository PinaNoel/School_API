
namespace School_API.App.DTO
{
    public class ApiResponse<T>
    {
        public required int StatusCode { get; set; }
        public required string Method { get; set; }
        public required string Path { get; set; }
        public T? Data { get; set; }
        public T? Error { get; set; }
    }
}