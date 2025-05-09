
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
        public PeriodRepository PeriodRepository { get; }
        public CareerRepository CareerRepository { get; }
        public GroupPeriodsRepository GroupPeriodsRepository { get; }
        public SubjectRepository SubjectRepository { get; }


        public UnitOfWork(SchoolApiContext context)
        {
            _context = context;

            StudentRepository = new StudentRepository(_context);
            TeacherRepository = new TeacherRepository(_context);
            UserRepository = new UserRepository(_context);
            CurriculumSubjectsRepository = new CurriculumSubjectsRepository(_context);
            PeriodRepository = new PeriodRepository(_context);
            CareerRepository = new CareerRepository(_context);
            GroupPeriodsRepository = new GroupPeriodsRepository(_context);
            SubjectRepository = new SubjectRepository(_context);
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}