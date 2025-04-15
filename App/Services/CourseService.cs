
using School_API.App.DTO;
using School_API.App.Interfaces;
using School_API.Core.Exceptions;
using School_API.Core.Models;
namespace School_API.App.Services
{
    public class CourseService
    {
        private ICoursesUnitOfWork _coursesUnitOfWork;
        private IUnitOfWork _unitOfWork;
        private string _sus => "ඞ";

        public CourseService(ICoursesUnitOfWork coursesUnitOfWork, IUnitOfWork unitOfWork)
        {
            _coursesUnitOfWork = coursesUnitOfWork;
            _unitOfWork = unitOfWork;
        }


        public async Task CreateCurriculum(CurriculumCreateDTO curriculumDTO)
        {
            Curriculum curriculum = new Curriculum{ Name = curriculumDTO.Name, CareerId = curriculumDTO.CareerId };
            await _coursesUnitOfWork.CurriculumRepository.Add(curriculum);
            await _coursesUnitOfWork.Save();

            foreach (SubjectAddDTO subjectsList in curriculumDTO.SubjectsList)
            {
                await _coursesUnitOfWork.AddSubjects(curriculum, subjectsList);
            }
        }


        public async Task<CurriculumResponseDTO> GetCurriculum(string curriculumName)
        {
            List<SubjectDTO> reply = await _unitOfWork.CurriculumSubjectsRepository.GetCurriculumSubjects(curriculumName);

            if (reply.Count == 0) throw new NotFoundException("Curiculum not found");

            List<SubjectsPerSemesterDTO> subjectsGroup = reply.GroupBy(r => r.Semester)
                .Select(g => new SubjectsPerSemesterDTO { Semester = g.Key, Subjects = g.Select(s => s.Name).ToList() })
                .ToList();
            
            return new CurriculumResponseDTO{ Curriculum = curriculumName, Subjects = subjectsGroup };
        }
    }
}