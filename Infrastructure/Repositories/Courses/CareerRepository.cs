
using Microsoft.EntityFrameworkCore;
using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class CareerRepository
    {
        private readonly SchoolApiContext _context;

        public CareerRepository(SchoolApiContext context)
        {
            _context = context;
        }

        public async Task<Career?> GetByName(string name)
        {
            return await _context.Careers.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}