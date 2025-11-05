using Microsoft.AspNetCore.Mvc;
using backEnd_EM.Interfaces;
using backEnd_EM.Properties.Models;
using backEnd_EM.Models;
using backEnd_EM.Mapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using backEnd_EM.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace backEnd_EM.Controllers
{
    [Route("api/subprogramcontroller")]
    [ApiController]
    public class SubProgramController : ControllerBase
    {
        private readonly ISubProgramRepo _subprogramReop;

        public SubProgramController(ISubProgramRepo subprogramRepo)
        {
            _subprogramReop = subprogramRepo;
        }

        [HttpGet("getAllPrograms")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllSubprograms()
        {
            var subprogram = await _subprogramReop.GetAllSubPrograms();
            if (subprogram == null)
            {
                return NotFound();
            }
            return Ok(subprogram);
        }

        [HttpGet("getSubProgramById/{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetProgramById([FromRoute] int id)
        {
            var program = await _subprogramReop.GetSubProgramById(id);
            if (program == null)
            {
                return NotFound();
            }
            return Ok(program);
        }

        [HttpGet("getSubProgramByMonth/{month}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetSubProgramByMonth([FromRoute] int month)
        {
            var program = await _subprogramReop.GetSubProgramByMonth(month);
            if (program == null)
            {
                return NotFound();
            }
            return Ok(program);
        }

        [HttpPost("updateSubprogram/{month}/{level}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateSubprogram([FromRoute] int month, [FromRoute] string level, [FromBody] string subprogramJSON)
        {
            var subprogram = await _subprogramReop.UpdateSubprogram(month, level, subprogramJSON);
            if (subprogram == null)
            {
                return NotFound();
            }
            return Ok(subprogram);
        }

        [HttpPost("deleteSubprogram/{month}/{level}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteSubprogram([FromRoute] int month, [FromRoute] string level)
        {
            var subprogram = await _subprogramReop.DeleteSubprogram(month, level);
            if (subprogram == null)
            {
                return NotFound();
            }
            return Ok(subprogram);
        }

        [HttpPost("createSubprogram")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateSubProgram([FromBody] CreateSubprogramDto subprogramModel)
        {
            var program = subprogramModel.CreateSubprogramFromDto();
            var response = await _subprogramReop.CreateSubProgram(program);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(response);
        }
    }
}