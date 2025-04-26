
using Microsoft.AspNetCore.Mvc;
using School_API.App.DTO;
using School_API.App.Services;

namespace School_API.Presentation.Controllers
{
    public class TeacherController : Controller
    {

        private TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        [HttpPost]
        [Route("[Controller]/Register")]
        public async Task<ActionResult<ApiResponse<Object>>> Register([FromBody] TeacherRegisterDTO teacher)
        {
            await _teacherService.Register(teacher);

            return Ok(
                new ApiResponse<Object>
                {
                    StatusCode = 200,
                    Method = HttpContext.Request.Method,
                    Path = HttpContext.Request.Path,
                }
            );
        }


        [HttpPost]
        [Route("[Controller]/AssignSubject")]
        public async Task<ActionResult<ApiResponse<Object>>> AssignSubject([FromBody] TeacherAssignSubjectDTO teacherAssign)
        {
            await _teacherService.AssignSubject(teacherAssign);

            return Ok(
                new ApiResponse<Object>
                {
                    StatusCode = 201,
                    Method = HttpContext.Request.Method,
                    Path = HttpContext.Request.Path,
                }
            );
        }
        
    }
}