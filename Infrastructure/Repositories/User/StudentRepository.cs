using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class StudentRepository
    {
        private readonly SchoolApiContext _context;

        public StudentRepository(SchoolApiContext context)
        {
            _context = context;
        }

        public async Task Add(Student student)
        {
            await _context.Students.AddAsync(student);
        }
    }
}