
using School_API.Core.Models;
using School_API.Infrastructure.Repositories;


public interface IStudentUnitOfWork : IDisposable
{
    StudentRepository StudentRepository { get; }
    Task Create(User user, int careerId);

};