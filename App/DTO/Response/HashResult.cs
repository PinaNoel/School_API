
namespace School_API.App.DTO 
{
    public class HashResult
    {
        public required byte[] Salt { get; set; }
        public required byte[] Hash { get; set; }
    }
}