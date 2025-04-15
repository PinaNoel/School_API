
using School_API.Infrastructure.Persistence;
using School_API.Infrastructure.Repositories;
using School_API.App.Interfaces;

namespace School_API.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private SchoolApiContext _context;

        public StudentRepository StudentRepository { get; }
        public TeacherRepository TeacherRepository { get; }
        public UserRepository UserRepository { get; }
        public CurriculumSubjectsRepository CurriculumSubjectsRepository { get; }


        public UnitOfWork(SchoolApiContext context)
        {
            _context = context;

            StudentRepository = new StudentRepository(_context);
            TeacherRepository = new TeacherRepository(_context);
            UserRepository = new UserRepository(_context);
            CurriculumSubjectsRepository = new CurriculumSubjectsRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}