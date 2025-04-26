
using School_API.Core.Exceptions;
using School_API.Core.Models;
using School_API.Infrastructure.Persistence;
using School_API.Infrastructure.Repositories;
using School_API.App.Interfaces;
using School_API.App.DTO;



namespace School_API.Infrastructure.UnitOfWork
{
    public class TeacherUnitOfWork : ITeacherUnitOfWork
    {
        private readonly SchoolApiContext _context;
        private TeacherRepository _teacherRepository;
        private UserRepository _userRepository;
        private TeacherSubjectsRepository _teacherSubjects;
        private GroupPeriodsRepository _groupPeriodsRepository;
        private SubjectRepository _subjectRepository;

        public TeacherUnitOfWork(SchoolApiContext context)
        {
            _context = context;
            _teacherRepository = new TeacherRepository(_context);
            _userRepository = new UserRepository(_context);
            _teacherSubjects = new TeacherSubjectsRepository(_context);
            _groupPeriodsRepository = new GroupPeriodsRepository(_context);
            _subjectRepository = new SubjectRepository(_context);
        }


        public async Task Register(User user, Teacher teacher)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try{
                await _userRepository.Add(user);
                await Save();

                teacher.UserId = user.Id;
                await _teacherRepository.Add(teacher);
                await Save();

                await transaction.CommitAsync();
            }
            catch(Exception error)
            {
                await transaction.RollbackAsync();
                throw new DataBaseException("An error occurred while accessing the database", error);
            }
        }

        public async Task AssignSubject(TeacherAssignSubjectDTO teacherAssign)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try{

                int teacherId = await _teacherRepository.GetTeacherId(teacherAssign.Enrollment);

                if (teacherId == 0) throw new NotFoundException("Teacher not found");

                TeacherSubject teacherSubject = new TeacherSubject { TeacherId = teacherId, SubjectId = teacherAssign.SubjectId };
                await _teacherSubjects.Add(teacherSubject);
                await Save();

                ActualPeriodSubject actualPeriod = new ActualPeriodSubject{ TeacherSubjectsId = teacherSubject.Id, GroupPeriodsId = teacherAssign.GroupPeriodId };

                await _groupPeriodsRepository.NewActualPeriod(actualPeriod);
                await Save();

                await transaction.CommitAsync();
            }
            catch(Exception error)
            {
                await transaction.RollbackAsync();
                throw new DataBaseException("An error occurred while accessing the database", error);
            }
        }




        public async Task Save() => await _context.SaveChangesAsync();


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}