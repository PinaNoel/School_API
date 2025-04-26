

using Microsoft.EntityFrameworkCore;
using School_API.App.DTO;
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

        public async Task<Subject?> GetByName(string name)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.Name == name);
        }


        public async Task<List<int> > GetSubjectsByPeriod(SubjectsByPeriodDTO data)
        {
            return await _context.ActualPeriodSubjects.Where(ap => 
            ap.GroupPeriods!.Period!.Name == data.Period && ap.TeacherSubjects!.Subject!.CurriculumSubjects.Any(cs => cs.Curriculum!.Name == data.Curiculum))
            .Select(ap => ap.Id).ToListAsync();
        }

        
    }
}
