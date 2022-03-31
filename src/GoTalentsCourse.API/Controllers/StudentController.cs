using System;
using GoTalentsCourse.Services;
using GoTalentsCourse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoTalentsCourse.API.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _service;

        public StudentController(IStudentServices service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("student")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var allStudents = await _service.GetAllAsync();
            return Ok(allStudents);
        }

        [HttpGet]
        [Route("student/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            try
            {
                var student = await _service.GetByIdAsync(id);
                return Ok(student);
            }
            catch (System.Exception error)
            {
                return NotFound(new { error.Message });
            }
        }

        [HttpPost]
        [Route("student")]
        public async Task<IActionResult> CreateNewStudentAsync([FromBody] StudentModel student)
        {
            try
            {
                var newStudentID = await _service.SaveAsync(student);
                return Ok(newStudentID);
            }
            catch (System.Exception error)
            {
                return Conflict(new { error.Message });
            }
        }

        [HttpDelete]
        [Route("student/{id}")]
        public async Task<IActionResult> RemoveStudentByIdAsync(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (System.Exception error)
            {
                return NotFound(new { error.Message });
            }
        }
    }
}
