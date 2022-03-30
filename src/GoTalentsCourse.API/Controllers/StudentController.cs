using System;
using GoTalentsCourse.Services;
using GoTalentsCourse.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllStudents()
        {
            var allStudents = _service.GetAll();
            return Ok(allStudents);
        }

        [HttpGet]
        [Route("student/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _service.GetByID(id);
                return Ok(student);
            }
            catch (System.Exception error)
            {
                return NotFound(new { error.Message });
            }
        }

        [HttpPost]
        [Route("student")]
        public IActionResult CreateNewStudent([FromBody] StudentModel student)
        {
            try
            {
                var newStudentID = _service.Save(student);
                return Ok(newStudentID);
            }
            catch (System.Exception error)
            {
                return Conflict(new { error.Message });
            }
        }

        [HttpDelete]
        [Route("student/{id}")]
        public IActionResult RemoveStudentByID(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (System.Exception error)
            {
                return NotFound(new { error.Message });
            }
        }
    }
}
