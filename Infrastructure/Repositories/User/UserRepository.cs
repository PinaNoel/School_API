using School_API.Infrastructure.Persistence;
using School_API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace School_API.Infrastructure.Repositories
{
    public class UserRepository 
    {
        private readonly SchoolApiContext _context;

        public UserRepository(SchoolApiContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}