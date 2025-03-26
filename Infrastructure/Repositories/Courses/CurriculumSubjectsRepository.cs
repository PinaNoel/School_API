

using Microsoft.EntityFrameworkCore;
using School_API.App.DTO;
using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class CurriculumSubjectsRepository
    {
        protected readonly SchoolApiContext _context;

        public CurriculumSubjectsRepository(SchoolApiContext context)
        {
            _context = context;
        }

        public async Task AddList(List<CurriculumSubject> list)
        {
            await _context.CurriculumSubjects.AddRangeAsync(list);
        }

        public async Task<List<SubjectDTO>> GetCurriculumSubjects(string curriculumName)
        {
            try{
                List<SubjectDTO> reply = await _context.CurriculumSubjects
                    .Where(cs => cs.Curriculum.Name == curriculumName)
                    .Select(cs => new SubjectDTO { Semester = cs.Semester.Name, Name = cs.Subject.Name } )
                    .ToListAsync();
                
                return reply;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }
}