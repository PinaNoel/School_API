

namespace School_API.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) {}
    }
}