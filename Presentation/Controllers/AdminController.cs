using Microsoft.AspNetCore.Mvc;
using School_API.App.DTO;
using School_API.App.Services;

namespace School_API.Presentation.Controllers
{
    public class AdminController : Controller
    {
        private AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [ValidateModel]
        [HttpPost]
        [Route("[Controller]/Register")]
        public async Task<ActionResult<ApiResponse<Object>>> Register([FromBody] AdminRegisterDTO user)
        {
            await _adminService.Register(user);
            return Ok(
                new ApiResponse<Object>{
                    StatusCode = 201,
                    Method = HttpContext.Request.Method,
                    Path = HttpContext.Request.Path,
                } 
            );
        }
    }
}