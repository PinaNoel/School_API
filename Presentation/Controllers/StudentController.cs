
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_API.App.DTO;
using School_API.App.Services;


namespace School_API.Presentation.Controllers
{
    public class StudentController : Controller
    {

        private StudentService _studentService { get; set; }

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        

        [ValidateModel]
        [HttpPost]
        [Route("[Controller]/Register")]
        public async Task<ActionResult<ApiResponse<Object>>> Register([FromBody] StudentRegisterDTO student)
        {
            await _studentService.Register(student);

            return Ok(
                new ApiResponse<Object>
                {
                    StatusCode = 200,
                    Method = HttpContext.Request.Method,
                    Path = HttpContext.Request.Path,
                }
            );
        }


        [HttpGet]
        [Authorize]
        [Route("[Controller]/Profile")]
        public async Task<ActionResult> Profile()
        {
            StudentProfileDTO reply = await _studentService.GetProfile();

            return Ok(new ApiResponse<StudentProfileDTO>
                {
                    StatusCode = 200,
                    Method = HttpContext.Request.Method,
                    Path = HttpContext.Request.Path,
                    Data = reply
                }
            );
        }


        [HttpPost]
        [Route("[Controller]/Enrroll")]
        public async Task<IActionResult> Enrroll(string enrroll, string curriculum)
        {
            return Ok();
        }
    }
}