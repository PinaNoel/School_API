using School_API.Infrastructure.Persistence;
using School_API.Core.Models;
using Microsoft.EntityFrameworkCore;
using School_API.App.DTO;
using School_API.Core.Exceptions;

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

        public async Task<User?> GetByEnrollment(string enrollment)
        {
            return await _context.Users
                .Where(u => u.Enrollment == enrollment)
                .Select(u => new User { Id = u.Id, Password = u.Password, Salt = u.Salt, Role = u.Role })
                .FirstOrDefaultAsync();
        }
    }
}