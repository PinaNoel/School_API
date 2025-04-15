
namespace School_API.App.DTO
{
    public class ErrorDTO
    {
        public required string Type { get; set; }
        public required string Message { get; set; }
        public string? Details { get; set; }
    }
}