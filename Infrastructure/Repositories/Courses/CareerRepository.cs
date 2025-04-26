
using Microsoft.EntityFrameworkCore;
using School_API.Core.Models;
using School_API.Infrastructure.Persistence;
using School_API.App.DTO;

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


        public async Task<List<CareerResponseDTO>> GetAll()
        {
            return await _context.Careers.Select(c => new CareerResponseDTO { Id = c.Id, Career = c.Name! }).ToListAsync();
        }
    }
}