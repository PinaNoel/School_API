
namespace School_API.Core.Security 
{
    public class HashResult
    {
        public required byte[] Salt { get; set; }
        public required byte[] Hash { get; set; }
    }
}