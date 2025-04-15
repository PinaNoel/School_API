using School_API.Core.Models;
using School_API.App.Interfaces;
using School_API.Infrastructure.Persistence;
using School_API.Infrastructure.Repositories;
using School_API.Core.Exceptions;

namespace School_API.Infrastructure.UnitOfWork
{
    public class AdminUnitOfWork : IAdminUnitOfWork
    {
        private readonly SchoolApiContext _context;
        public UserRepository UserRepository { get; }
        public TeacherRepository TeacherRepository { get; }

        public AdminUnitOfWork(SchoolApiContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            TeacherRepository = new TeacherRepository(_context);
        }


        public async Task Register(User user, Teacher teacher)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try{
                await UserRepository.Add(user);
                await Save();

                teacher.UserId = user.Id;
                await TeacherRepository.Add(teacher);
                await Save();

                await transaction.CommitAsync();
            }
            catch(Exception error)
            {
                await transaction.RollbackAsync();
                throw new DataBaseException("An error occurred while accessing the database", error);
            }
        }


        public async Task<int> Save() => await _context.SaveChangesAsync();


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}