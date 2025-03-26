using School_API.Core.Models;
using School_API.App.Interfaces;
using School_API.Infrastructure.Persistence;
using School_API.Infrastructure.Repositories;

namespace School_API.Infrastructure.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly SchoolApiContext _context;
        private UserRepository _userRepository { get; }
        private StudentRepository _studentRepository { get; }
        private CareerRepository _careerRepository { get; }
        private TeacherRepository _teacherRepository { get; }

        public UserUnitOfWork(SchoolApiContext context)
        {
            _context = context;
            _userRepository = new UserRepository(_context);
            _studentRepository = new StudentRepository(_context);
            _careerRepository = new CareerRepository(_context);
            _teacherRepository = new TeacherRepository(_context);
        }

        public async Task<bool> CreateStudent(User user, string careerName)
        {
            try{
                Career? career = await _careerRepository.GetByName(careerName);
                if (career == null) return false;

                await _userRepository.Add(user);
                await Save();

                Student student = new Student
                {
                    UserId = user.Id,
                    CareerId = career.Id,
                };

                await _studentRepository.Add(student);
                await Save();

                if (career.Id == 0) return false;

                return true;
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool> CreateSuperUser(User user, Teacher teacher)
        // no se si debo crear una transaccion para profesor y admin, mejor los dos en uno :)
        {
            try{
                await _userRepository.Add(user);
                await Save();
                
                if (user.Id == 0) return false;

                teacher.UserId = user.Id;
                await _teacherRepository.Add(teacher);
                await Save();

                if (teacher.Id == 0) return false;

                return true;
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
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