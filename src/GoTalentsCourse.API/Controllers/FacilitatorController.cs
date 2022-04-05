using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoTalentsCourse.Services.Interfaces;
using GoTalentsCourse.Models.ViewModels;
using GoTalentsCourse.Models;

namespace GoTalentsCourse.API.Controllers
{
    [ApiController]
    public class FacilitatorController : ControllerBase
    {
        private readonly IStandartServicesOperations<FacilitatorViewModel ,FacilitatorModel> _service;

        public FacilitatorController(IStandartServicesOperations<FacilitatorViewModel, FacilitatorModel> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("facilitator")]
        public async Task<IActionResult> GetAllFacilitatorsAsync()
        {
            var allFacilitators = await _service.GetAllAsync();
            return Ok(allFacilitators);
        }

        [HttpGet]
        [Route("facilitator/{id}")]
        public async Task<IActionResult> GetFacilitatorByIdAsync(int id)
        {
            try
            {
                var facilitator = await _service.GetByIdAsync(id);
                return Ok(facilitator);
            }
            catch (System.Exception error)
            {
                return NotFound(new { error.Message });
            }
        }

        [HttpPost]
        [Route("facilitator")]
        public async Task<IActionResult> CreateNewFacilitatorAsync([FromBody] FacilitatorModel facilitator)
        {
            try
            {
                var newFacilitatorID = await _service.SaveAsync(facilitator);
                return Ok(newFacilitatorID);
            }
            catch (System.Exception error)
            {
                return Conflict(new { error.Message });
            }
        }

        [HttpDelete]
        [Route("facilitator/{id}")]
        public async Task<IActionResult> RemoveFacilitatorByIdAsync(int id)
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
