
using School_API.App.DTO;
using School_API.Core.Models;
using School_API.App.Interfaces;
using School_API.Core.Security;
using School_API.Infrastructure.Helpers;
using School_API.Core.Exceptions;


namespace School_API.App.Services
{
    public class StudentService
    {

        private IStudentUnitOfWork _studentUnitOfWork;
        private IHashProvider _hashProvider;
        private ContextHelper _contextHelper;

        public StudentService(IStudentUnitOfWork unitOfWork, IHashProvider hashProvider, ContextHelper contextHelper)
        {
            _studentUnitOfWork = unitOfWork;
            _hashProvider = hashProvider;
            _contextHelper = contextHelper;
        }


        public async Task Register(StudentRegisterDTO student)
        {
            byte[] salt = _hashProvider.GenerateSalt();
            HashResult hash = _hashProvider.Hash(salt, student.Password);

            User user = new User{
                Name = student.Name,
                SecondNames = student.SecondNames,
                Email = student.Email,
                Enrollment = student.Enrollment,
                Salt = hash.Salt,
                Password = hash.Hash,
                Role = "Student",
                IsActive = true
            };

            await _studentUnitOfWork.Create(user, student.CareerId);
        }


        public async Task<StudentProfileDTO> GetProfile()
        {
            StudentProfileDTO? profile = await _studentUnitOfWork.StudentRepository.GetProfileById(_contextHelper.Id);

            if (profile == null) throw new NotFoundException("User not found");

            return profile;
        }
    }
}