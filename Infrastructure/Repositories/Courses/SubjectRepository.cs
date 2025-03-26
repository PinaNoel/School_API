

using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class SubjectRepository
    {
        private readonly SchoolApiContext _context;

        public SubjectRepository(SchoolApiContext context)
        {
            _context = context;
        }

        public async Task Add(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
        }

        public async Task AddSubjectsList(List<Subject> subjects)
        {
            await _context.Subjects.AddRangeAsync(subjects);
        }

        
    }
}
