
using School_API.App.Interfaces;
using School_API.App.DTO;
using School_API.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace School_API.App.Services
{
    public class TeacherService
    {
        
        private ITeacherUnitOfWork _teacherUnitOfWork;
        private IHashProvider _hashProvider;

        public TeacherService(ITeacherUnitOfWork teacherUnitOfWork, IHashProvider hashProvider)
        {
            _teacherUnitOfWork = teacherUnitOfWork;
            _hashProvider = hashProvider;
        }


        public async Task Register(TeacherRegisterDTO user)
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
                Role = "Teacher",
                IsActive = true
            };

            Teacher newTeacher = new Teacher{
                Title = user.Title,
                Speciality = user.Speciality,
            };

            await _teacherUnitOfWork.Register(newUser, newTeacher);
        }

        public async Task AssignSubject(TeacherAssignSubjectDTO teacherAssign)
        {
            await _teacherUnitOfWork.AssignSubject(teacherAssign);
        }
    }
}