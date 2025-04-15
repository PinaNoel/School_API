using School_API.Core.Models;
using School_API.Infrastructure.Repositories;


namespace School_API.App.Interfaces
{
    public interface IAdminUnitOfWork : IDisposable
    {
        UserRepository UserRepository { get; }
        Task Register(User user, Teacher teacher);
        Task<int> Save();
    }
}