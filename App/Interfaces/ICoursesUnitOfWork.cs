using School_API.App.DTO;
using School_API.Core.Models;
using School_API.Infrastructure.Repositories;

namespace School_API.App.Interfaces
{
    public interface ICoursesUnitOfWork : IDisposable
    {
        CurriculumSubjectsRepository CurriculumSubjects { get; }

        Task<Curriculum?> AddCurriculum(string careerName, string curriculumName);
        Task AddCurriculumSubjects(Curriculum curriculum, int semesterId, List<string> subjects);
        Task<int> Save();
    }
}