using Microsoft.EntityFrameworkCore;
using School_API.App.DTO;
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


        public async Task<StudentProfileDTO?> GetProfileById(int id)
        {
            return await _context.Students
                .Where(s => s.User!.Id == id)
                .Select(s => new StudentProfileDTO { Name = s.User!.Name!, Surname = s.User.SecondNames!, Email = s.User.Email!, Career = s.Career!.Name! })
                .FirstOrDefaultAsync();
        }
    }
}