
using School_API.Core.Models;
using School_API.Infrastructure.Persistence;
using School_API.Infrastructure.Repositories;
using School_API.Core.Exceptions;



namespace School_API.Infrastructure.UnitOfWork
{
    public class StudentUnitOfWork : IStudentUnitOfWork
    {
        private readonly SchoolApiContext _context;
        public UserRepository UserRepository { get; }
        public StudentRepository StudentRepository { get; }
        private PeriodRepository _periodRepository { get; }
        private CareerRepository _careerRepository { get; }
        private TeacherRepository _teacherRepository { get; }

        public StudentUnitOfWork(SchoolApiContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            StudentRepository = new StudentRepository(_context);
            _periodRepository = new PeriodRepository(_context);
            _careerRepository = new CareerRepository(_context);
            _teacherRepository = new TeacherRepository(_context);
        }


        public async Task Create(User user, int careerId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try{

                await UserRepository.Add(user);
                await Save();

                Student student = new Student
                {
                    UserId = user.Id,
                    CareerId = careerId,
                };

                await StudentRepository.Add(student);
                await Save();
                
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw new DataBaseException("An error occurred while accessing the database", ex);
            }
        }


        public async Task<int> Save()
            => await _context.SaveChangesAsync();


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}