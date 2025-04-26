
using School_API.Infrastructure.Repositories;

namespace School_API.App.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        StudentRepository StudentRepository { get; }
        TeacherRepository TeacherRepository { get; }
        UserRepository UserRepository { get; }
        CurriculumSubjectsRepository CurriculumSubjectsRepository { get; }
        PeriodRepository PeriodRepository { get; }
        CareerRepository CareerRepository  { get; }
        GroupPeriodsRepository GroupPeriodsRepository { get; }
        SubjectRepository SubjectRepository { get; }
        Task Save();
    }
}
