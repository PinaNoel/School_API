using School_API.Infrastructure.Persistence;
using School_API.Core.Models;
using School_API.App.Interfaces;
using School_API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using School_API.Core.Exceptions;
using School_API.App.DTO;

namespace School_API.Infrastructure.UnitOfWork
{
    public class CoursesUnitOfWork : ICoursesUnitOfWork
    {
        private readonly SchoolApiContext _context;
        public CurriculumRepository CurriculumRepository { get; }
        private SemesterRepository _semesterRepository { get; }
        private CareerRepository _careerRepository { get; }
        private SubjectRepository _subjectRepository { get; }
        public CurriculumSubjectsRepository CurriculumSubjects { get; }

        public CoursesUnitOfWork(SchoolApiContext context)
        {
            _context = context;
            CurriculumRepository = new CurriculumRepository(_context);
            _semesterRepository = new SemesterRepository(_context);
            _careerRepository = new CareerRepository(_context);
            _subjectRepository = new SubjectRepository(_context);
            CurriculumSubjects = new CurriculumSubjectsRepository(_context);
        }


        public async Task AddSubjects(Curriculum curriculum, SubjectAddDTO subjects)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try {

                List<Subject> subjectsList = new List<Subject>();

                foreach (string subject in subjects.Subjects)
                {
                    Subject newSubject = new Subject { Name = subject };
                    subjectsList.Add(newSubject);
                }

                await _subjectRepository.AddSubjectsList(subjectsList);
                await Save();

                List<CurriculumSubject> curriculumSubjects = new List<CurriculumSubject>();
                
                foreach (Subject subject in subjectsList)
                {
                    CurriculumSubject curriculumSubject = new CurriculumSubject{
                        CurriculumId = curriculum.Id,
                        SubjectId = subject.Id,
                        SemesterId = subjects.SemesterId,
                    };

                    curriculumSubjects.Add(curriculumSubject);
                }

                await CurriculumSubjects.AddList(curriculumSubjects);
                await Save();

                await transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new DataBaseException("An error occurred while accessing the database in Courses UnitOfWork", ex);
            }
        }


        public async Task<int> Save() => await _context.SaveChangesAsync();


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}