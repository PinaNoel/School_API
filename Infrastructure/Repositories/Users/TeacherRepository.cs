

using Microsoft.EntityFrameworkCore;
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


        public async Task AssignSubject(TeacherSubject teacherSubject)
        {
            await _context.TeacherSubjects.AddAsync(teacherSubject);
        }


        public async Task<int> GetTeacherId(string enrollment)
        {
            return await _context.Teachers.Where(t => t.User!.Enrollment == enrollment).Select(t => t.Id).FirstOrDefaultAsync();
        }
    }
}