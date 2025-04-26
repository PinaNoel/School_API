
using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class TeacherSubjectsRepository
    {
        private readonly SchoolApiContext _context;

        public TeacherSubjectsRepository(SchoolApiContext context)
        {
            _context = context;
        }

        public async Task Add(TeacherSubject teacherSubjects)
        {
            await _context.TeacherSubjects.AddAsync(teacherSubjects);
        }    


    }
}