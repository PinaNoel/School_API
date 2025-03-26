using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School_API.App.DTO;
using School_API.App.Services;


namespace School_API.Presentation.Controllers{

    public class CourseController : Controller{

        private CourseService _courseService;
        private readonly ILogger<CourseController> _logger;

        public CourseController(CourseService courseService, ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }
        
        [HttpPost]
        [Route("[Controller]/Curriculum/Create")]
        public async Task<IActionResult> CreateCurriculum([FromBody] CurriculumDTO curriculum)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest( new { code = 400, modelState = "Invalid" });
                }

                await _courseService.CreateCurriculum(curriculum);

                return Ok( new { code = 201, modelState = "Valid", response = "Ok" } );
            }    
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode( 500, new { code = 500, response = ex.Message } );
            }
        }


        [HttpGet]
        [Route("[Controller]/Curriculum")]
        public async Task<IActionResult> GetCurriculum([FromQuery] string name)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest( new { code = 400, modelState = "Invalid" });
                }
                var curriculum = await _courseService.GetCurriculum(name);

                if (curriculum == null) return NotFound( new { code = 404, modelState = "Valid", response = "Not Found" });

                return Ok( new { code = 200, modelState = "Valid", response = curriculum });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode( 500, new { code = 500, response = ex.Message } );
            }
        }
    }
}