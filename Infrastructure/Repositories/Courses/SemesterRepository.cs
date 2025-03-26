
using Microsoft.EntityFrameworkCore;
using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class SemesterRepository
    {
        public SchoolApiContext _context;

        public SemesterRepository(SchoolApiContext context)
        {
            _context = context;
        }


        public async Task<Semester?> GetByName(string name)
        {
            return await _context.Semesters.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}