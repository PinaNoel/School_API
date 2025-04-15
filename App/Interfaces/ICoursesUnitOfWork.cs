using School_API.App.DTO;
using School_API.Core.Models;
using School_API.Infrastructure.Repositories;

namespace School_API.App.Interfaces
{
    public interface ICoursesUnitOfWork : IDisposable
    {
        CurriculumRepository CurriculumRepository { get; }
        CurriculumSubjectsRepository CurriculumSubjects { get; }

        Task AddSubjects(Curriculum curriculum, SubjectAddDTO subjects);
        Task<int> Save();
    }
}