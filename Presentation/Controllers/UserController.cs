using Microsoft.AspNetCore.Mvc;
using School_API.App.DTO;
using School_API.App.Services;

namespace School_API.Presentation.Controllers
{
    public class SchoolController : Controller 
    {
        private UserService _userService;
        private readonly ILogger<SchoolController> _logger;

        public SchoolController(UserService userService, ILogger<SchoolController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("[Controller]/Create/Student")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDTO student )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool reply = await _userService.CreateStudent(student);

            if (reply) return Ok();
            
            return BadRequest();

        }

        [HttpPost]
        [Route("[Controller]/Create/SuperUser")]
        public async Task<IActionResult> Create([FromBody] SuperUserDTO user )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool reply = await _userService.CreateSuperUser(user);

            if (reply) return Ok();
            
            return BadRequest();
        }

    }
}