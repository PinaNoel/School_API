using Microsoft.AspNetCore.Routing.Tree;
using School_API.App.DTO;
using School_API.App.Interfaces;
using School_API.Core.Models;
using School_API.Core.Security;

namespace School_API.App.Services 
{
    public class UserService
    {
        private IUserUnitOfWork _userUnitOfWork;
        private IHashProvider _hashProvider;
        private ILogger _logger;

        public UserService(IUserUnitOfWork userUnitOfWork, IHashProvider hashProvider, ILogger<UserService> logger)
        {
            _userUnitOfWork = userUnitOfWork;
            _hashProvider = hashProvider;
            _logger = logger;
        }

        private HashResult GenerateHash(string password)
        {
            byte[] salt = _hashProvider.GenerateSalt();
            return _hashProvider.Hash(salt, password);
        }

        public async Task<bool> CreateStudent(StudentDTO student)
        {
            try
            {
                HashResult hash = GenerateHash(student.Password);

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

                bool reply = await _userUnitOfWork.CreateStudent(user, student.Career);

                if (reply) return true;
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return false;
            }
        }

        public async Task<bool> CreateSuperUser(SuperUserDTO user)
        {
            try 
            {
                HashResult hash = GenerateHash(user.Password);

                User newUser = new User{
                    Name = user.Name,
                    SecondNames = user.SecondNames,
                    Email = user.Email,
                    Enrollment = user.Enrollment,
                    Salt = hash.Salt,
                    Password = hash.Hash,
                    Role = user.Role,
                    IsActive = true
                };

                Teacher newTeacher = new Teacher{
                    Title = user.Title,
                    Speciality = user.Speciality,
                };

                bool reply = await _userUnitOfWork.CreateSuperUser(newUser, newTeacher);

                if (!reply) return false;
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return false;
            }
        }
    }
}