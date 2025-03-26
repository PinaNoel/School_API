using School_API.Infrastructure.Persistence;
using School_API.Core.Models;
using School_API.App.Interfaces;
using School_API.Infrastructure.Repositories;

namespace School_API.Infrastructure.UnitOfWork
{
    public class CoursesUnitOfWork : ICoursesUnitOfWork
    {
        private readonly SchoolApiContext _context;
        private CurriculumRepository _curriculumRepository { get; }
        private SemesterRepository _semesterRepository { get; }
        private CareerRepository _careerRepository { get; }
        private SubjectRepository _subjectRepository { get; }
        public CurriculumSubjectsRepository CurriculumSubjects { get; }

        public CoursesUnitOfWork(SchoolApiContext context)
        {
            _context = context;
            _curriculumRepository = new CurriculumRepository(_context);
            _semesterRepository = new SemesterRepository(_context);
            _careerRepository = new CareerRepository(_context);
            _subjectRepository = new SubjectRepository(_context);
            CurriculumSubjects = new CurriculumSubjectsRepository(_context);
        }

        public async Task<Curriculum?> AddCurriculum(string careerName, string curriculumName)
        {
            try {
                Career? career = await _careerRepository.GetByName(careerName);
                if (career == null) return null;

                Curriculum curriculum = new Curriculum{
                    Name = curriculumName,
                    CareerId = career.Id,
                };

                await _curriculumRepository.Add(curriculum);
                await Save();

                return curriculum;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task AddCurriculumSubjects(Curriculum curriculum, int semesterId, List<string> subjects)
        {
            try {
                List<Subject> subjectsList = new List<Subject>();
                foreach (string subject in subjects)
                {
                    Subject newSubject = new Subject{ Name = subject };
                    subjectsList.Add(newSubject);
                }

                await _subjectRepository.AddSubjectsList(subjectsList);
                await Save();

                List<CurriculumSubject> tableCurriculumSubject = new List<CurriculumSubject>();
                foreach (Subject subject in subjectsList)
                {
                    CurriculumSubject curriculumSubject = new CurriculumSubject{
                        CurriculumId = curriculum.Id,
                        SubjectId = subject.Id,
                        SemesterId = semesterId,
                    };

                    tableCurriculumSubject.Add(curriculumSubject);
                }

                await CurriculumSubjects.AddList(tableCurriculumSubject);
                await Save();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
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