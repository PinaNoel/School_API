using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
    }
}