using System.Linq;
using School_API.App.DTO;
using School_API.App.Interfaces;
using School_API.Core.Models;
namespace School_API.App.Services
{
    public class CourseService
    {
        private ICoursesUnitOfWork _coursesUnitOfWork;
        private ILogger _logger;

        public CourseService(ICoursesUnitOfWork coursesUnitOfWork, ILogger<CourseService> logger)
        {
            _coursesUnitOfWork = coursesUnitOfWork;
            _logger = logger;
        }




        public async Task CreateCurriculum(CurriculumDTO curriculumDTO)
        {
            try
            {
                Curriculum? curriculum = await _coursesUnitOfWork.AddCurriculum(curriculumDTO.Career, curriculumDTO.Name);
                if (curriculum == null) return;

                foreach (var subjectsList in curriculumDTO.SubjectsList)
                {
                    await _coursesUnitOfWork.AddCurriculumSubjects(curriculum, subjectsList.SemesterId, subjectsList.Subjects);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }


        public async Task<CurriculumSubjecsDTO?> GetCurriculum(string curriculumName)
        {
            List<SubjectDTO> reply = await _coursesUnitOfWork.CurriculumSubjects.GetCurriculumSubjects(curriculumName);

            if (reply.Count == 0) return null;

            List<SemesterSubjectsDTO> subjectsGroup = reply.GroupBy(r => r.Semester)
                .Select(g => new SemesterSubjectsDTO { Semester = g.Key, Subjects = g.Select(s => s.Name).ToList() })
                .ToList();
            
            CurriculumSubjecsDTO curriculum = new CurriculumSubjecsDTO{ Curriculum = curriculumName, Subjects = subjectsGroup };

            return curriculum;
        }
    }
}