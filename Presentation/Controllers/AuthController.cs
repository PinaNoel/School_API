
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_API.App.DTO;
using School_API.App.Services;

namespace School_API.Presentation.Controllers
{
    public class AuthController : Controller 
    {
        private AuthService _authService;
        private readonly ILogger<AuthController> _logger;


        public AuthController(AuthService AuthService, ILogger<AuthController> logger)
        {
            _logger = logger;
            _authService = AuthService;
        }


        [HttpPost]
        [ValidateModel]
        [Route("[Controller]/login")]
        public async Task<ActionResult<ApiResponse<LoginResponseDTO>>> Login([FromBody] LoginDTO login)
        {
            LoginResponseDTO reply = await _authService.Login(login);

            return Ok( new ApiResponse<LoginResponseDTO> {
                StatusCode = 200,
                Method = HttpContext.Request.Method,
                Path = HttpContext.Request.Path,
                Data = reply
                }
            );
        }


        [HttpPost]
        [Authorize]
        [Route("[Controller]/test/jwt")]
        public IActionResult TestJwt()
        {
            return Ok(new { code = 201, modelState = "Valid", response = User.FindFirst("ID")?.Value });
        }


    }
}