
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
                .Select(g => new SubjectsPerSemesterDTO { Semester = g.Key, Subjects = g.Select(s => new SubjectsWithId {Id = s.Id, Name = s.Name}).ToList() })
                .ToList();
            
            return new CurriculumResponseDTO{ Curriculum = curriculumName, Subjects = subjectsGroup };
        }

        
        public async Task AddPeriod(string periodName)
        {
            Period period = new Period{ Name = periodName };
            await _unitOfWork.PeriodRepository.Add(period);
            await _unitOfWork.Save();
        }


        public async Task<List<CareerResponseDTO>> GetCareers()
        {
            List<CareerResponseDTO> careers = await _unitOfWork.CareerRepository.GetAll();

            if (careers.Count == 0) throw new NotFoundException("An error ocurred while searching");  

            return careers;  
        }


        public async Task<List<GroupResponseDTO>> GetGroups()
        {
            List<GroupResponseDTO> groups =await _unitOfWork.GroupPeriodsRepository.GetGroups();

            if (groups.Count == 0) throw new NotFoundException("An error ocurred while searching");

            return groups;
        }

        public async Task<List<PeriodResponseDTO>> GetPeriods()
        {
            List<PeriodResponseDTO> periods =await _unitOfWork.GroupPeriodsRepository.GetPeriods();

            if (periods.Count == 0) throw new NotFoundException("An error ocurred while searching");

            return periods;
        }

        public async Task<int> RegisterNewGroupPeriod(RegisterGroupPeriodsDTO register)
        {
            GroupPeriod groupPeriod = new GroupPeriod { GroupId = register.GroupId, PeriodId = register.PeriodId };

            await _unitOfWork.GroupPeriodsRepository.RegisterNewGroupPeriod(groupPeriod);
            await _unitOfWork.Save();

            return groupPeriod.Id;
        }

        public async Task<List<int>> GetSubjectsByPeriod(SubjectsByPeriodDTO data)
        {
            List<int> idList = await _unitOfWork.SubjectRepository.GetSubjectsByPeriod(data);

            if (idList.Count == 0) throw new NotFoundException("Subjects not found");

            return idList; 
        }

    }
}