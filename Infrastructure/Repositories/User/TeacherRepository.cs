

using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class TeacherRepository
    {
        private readonly SchoolApiContext _context;

        public TeacherRepository(SchoolApiContext context)
        {
            _context = context;
        }

        public async Task Add(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
        }
    }
}