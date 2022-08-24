using Microsoft.AspNetCore.Mvc;
using Demo3.Services;
using Demo3.Dto;
namespace Demo3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("get-all")]
        //public IActionResult GetAll(int pageSize, int pageindex, string keyword);
        public IActionResult GetAll([FromQuery] StudentFilterDto input)
        {
            return Ok(_studentService.GetAll());
        }


        [HttpPost]
        //public IActionResult PostStudent(CreateStudentDto input)
        //public IActionResult CreateStudent([FromBody] CreateStudentDto input) //giống nhau
        public IActionResult CreateStudent([FromForm] CreateStudentDto input) //dùng trong trường hợp lấy file.
        {
            try
            {
                _studentService.CreateStudent(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new 
                {
                    message = ex.Message 
                });
            }
            
        }
        [HttpGet]
        /*public IActionResult GetAll()
        {
            try
            {
                return Ok(_studentService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
            return Ok();
        }*/

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_studentService.GetById(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult PutById(UpdateStudentDto input)
        {
            try
            {
                return Ok(_studentService.UpdateStudent(input));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
            return Ok();

        }

        [HttpDelete]
        public IActionResult DeleteById(int Id)
        {
            try
            {
                _studentService.DeleteById(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
            return Ok();
        }



    }
}
