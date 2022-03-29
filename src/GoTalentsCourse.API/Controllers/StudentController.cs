using System;
using GoTalentsCourse.Services;
using GoTalentsCourse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult GetStudentById(Guid id)
        {
            try
            {
                var student = _service.GetByID(id);
                return Ok(student);
            }
            catch (System.Exception)
            {
                return NotFound();
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
            catch (System.Exception)
            {
                return Conflict();
            }
        }

        [HttpDelete]
        [Route("student/{id}")]
        public IActionResult RemoveStudentByID(Guid id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}
