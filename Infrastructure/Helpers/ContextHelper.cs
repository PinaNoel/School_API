


namespace School_API.Infrastructure.Helpers
{
    public class ContextHelper 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int Id => Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirst("Id")?.Value);
    }
}