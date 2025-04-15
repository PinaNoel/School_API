
using School_API.App.DTO;
using School_API.App.Interfaces;
using School_API.Core.Models;
using School_API.Core.Security;

namespace School_API.App.Services
{
    public class AdminService
    {

        private IAdminUnitOfWork _adminUnitOfWork;
        private IHashProvider _hashProvider;

        public AdminService(IAdminUnitOfWork adminUnitOfWork, IHashProvider hashProvider)
        {
            _hashProvider = hashProvider;
            _adminUnitOfWork = adminUnitOfWork;
        }


        public async Task Register(AdminRegisterDTO user)
        {
            byte[] salt = _hashProvider.GenerateSalt();
            HashResult hash = _hashProvider.Hash(salt, user.Password);


            User newUser = new User{
                Name = user.Name,
                SecondNames = user.SecondNames,
                Email = user.Email,
                Enrollment = user.Enrollment,
                Salt = hash.Salt,
                Password = hash.Hash,
                Role = "Admin",
                IsActive = true
            };

            Teacher newTeacher = new Teacher{
                Title = user.Title,
                Speciality = user.Speciality,
            };

            await _adminUnitOfWork.Register(newUser, newTeacher);
        }
    }
}