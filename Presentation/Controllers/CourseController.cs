using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_API.App.DTO;
using School_API.App.Services;


namespace School_API.Presentation.Controllers{

    public class CourseController : Controller{

        private CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Admin")]
        [Route("[Controller]/Curriculum/Create")]
        public async Task<ActionResult<ApiResponse<Object>>> CreateCurriculum([FromBody] CurriculumCreateDTO curriculum)
        {
            await _courseService.CreateCurriculum(curriculum);

            return Ok( new ApiResponse<Object> {
                StatusCode = 201,
                Method = HttpContext.Request.Method,
                Path = HttpContext.Request.Path,
                } 
            );
        }


        [HttpGet]
        [ValidateModel]
        [Route("[Controller]/Curriculum")]
        public async Task<ActionResult<ApiResponse<CurriculumResponseDTO>>> GetCurriculum([FromQuery] string name)
        {
            CurriculumResponseDTO curriculum = await _courseService.GetCurriculum(name);


            return Ok( new ApiResponse<CurriculumResponseDTO> {
                StatusCode = 201,
                Method = HttpContext.Request.Method,
                Path = HttpContext.Request.Path,
                Data = curriculum
                } 
            );
        }

        [HttpPost]
        [ValidateModel]
        [Route("[Controller]/Period")]
        public async Task<ActionResult<ApiResponse<Object>>> AddPeriod([FromBody] string period)
        {
            await _courseService.AddPeriod(period);
            
            return Ok( new ApiResponse<Object> {
                StatusCode = 201,
                Method = HttpContext.Request.Method,
                Path = HttpContext.Request.Path,
                } 
            );
        }


        [HttpGet]
        [Route("Careers")]
        public async Task<ActionResult<ApiResponse<List<CareerResponseDTO>>>> GetCareers()
        {
            List<CareerResponseDTO> careers = await _courseService.GetCareers();

            return Ok( new ApiResponse<List<CareerResponseDTO>> {
                StatusCode = 201,
                Method = HttpContext.Request.Method,
                Path = HttpContext.Request.Path,
                Data = careers
                } 
            );
        }

        [HttpGet]
        [Route("Groups")]
        public async Task<ActionResult<ApiResponse<List<CareerResponseDTO>>>> GetGroups()
        {
            List<GroupResponseDTO> groups = await _courseService.GetGroups();

            return Ok( new ApiResponse<List<GroupResponseDTO>> {
                StatusCode = 201,
                Method = HttpContext.Request.Method,
                Path = HttpContext.Request.Path,
                Data = groups
                } 
            );
        }

        [HttpGet]
        [Route("Periods")]
        public async Task<ActionResult<ApiResponse<List<PeriodResponseDTO>>>> GetPeriods()
        {
            List<PeriodResponseDTO> periods = await _courseService.GetPeriods();

            return Ok( new ApiResponse<List<PeriodResponseDTO>> {
                StatusCode = 201,
                Method = HttpContext.Request.Method,
                Path = HttpContext.Request.Path,
                Data = periods
                }
            );
        }

        [HttpPost]
        [Route("RegisterGroupPeriods")]
        public async Task<ActionResult<ApiResponse<int>>> RegisterGroupPeriods([FromBody] RegisterGroupPeriodsDTO register)
        {
            int groupPeriodId = await _courseService.RegisterNewGroupPeriod(register);

            return Ok( new ApiResponse<int> {
                StatusCode = 201,
                Method = HttpContext.Request.Method,
                Path = HttpContext.Request.Path,
                Data = groupPeriodId
                }
            );
        }

        [HttpGet]
        [Route("SubjectsByPeriod")]
        public async Task<ActionResult<ApiResponse<List<int>>>> GetSubjectsByPeriod(SubjectsByPeriodDTO data)
        {
            List<int> idList = await _courseService.GetSubjectsByPeriod(data);

            return Ok( new ApiResponse<List<int>> {
                StatusCode = 201,
                Method = HttpContext.Request.Method,
                Path = HttpContext.Request.Path,
                Data = idList
                }
            );
        }
    }
}