using School_API.Core.Models;


namespace School_API.App.Interfaces
{
    public interface IUserUnitOfWork : IDisposable
    {
        Task<bool> CreateStudent(User user, string careerName);
        Task<bool> CreateSuperUser(User user, Teacher teacher);
        Task<int> Save();
    }
}