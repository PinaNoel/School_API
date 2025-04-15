
using School_API.Infrastructure.Repositories;

namespace School_API.App.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        StudentRepository StudentRepository { get; }
        TeacherRepository TeacherRepository { get; }
        UserRepository UserRepository { get; }
        CurriculumSubjectsRepository CurriculumSubjectsRepository { get; }
    }
}
