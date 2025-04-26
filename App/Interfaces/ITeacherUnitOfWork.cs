
using School_API.App.DTO;
using School_API.Core.Models;
using School_API.Infrastructure.Repositories;


namespace School_API.App.Interfaces
{
    public interface ITeacherUnitOfWork : IDisposable
    {
        Task Register(User user, Teacher teacher);
        Task AssignSubject(TeacherAssignSubjectDTO teacherAssign);
        Task Save();
    }
}