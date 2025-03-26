

using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class CurriculumRepository
    {
        private readonly SchoolApiContext _context;

        public CurriculumRepository(SchoolApiContext context)
        {
            _context = context;
        }

        public async Task Add(Curriculum curriculum)
        {
            await _context.Curriculums.AddAsync(curriculum);
        }
    }
}