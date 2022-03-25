using System;
using Course_API.Services;
using Course_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course_API.API.Controllers
{
    [ApiController]
    public class FacilitatorController : ControllerBase
    {
        private readonly IFacilitatorServices _service;

        public FacilitatorController(IFacilitatorServices service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("facilitator")]
        public IActionResult GetAllFacilitators()
        {
            var allFacilitators = _service.GetAll();
            return Ok(allFacilitators);
        }

        [HttpGet]
        [Route("facilitator/{id}")]
        public IActionResult GetFacilitatorById(Guid id)
        {
            try
            {
                var facilitator = _service.GetByID(id);
                return Ok(facilitator);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("facilitator")]
        public IActionResult CreateNewFacilitator([FromBody] FacilitatorModel facilitator)
        {
            try
            {
                var newFacilitatorID = _service.Save(facilitator);
                return Ok(newFacilitatorID);
            }
            catch (System.Exception)
            {
                return Conflict();
            }
        }

        [HttpDelete]
        [Route("facilitator/{id}")]
        public IActionResult RemoveFacilitatorByID(Guid id)
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
