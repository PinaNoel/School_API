

namespace School_API.Core.Exceptions
{
    public class DataBaseException : Exception 
    {
        public DataBaseException(string message, Exception innerException) : base(message, innerException) {}
    }
}