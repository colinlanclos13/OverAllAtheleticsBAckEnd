using Microsoft.AspNetCore.Mvc;
using backEnd_EM.Interfaces;
using backEnd_EM.Properties.Models;
using backEnd_EM.Models;
using backEnd_EM.Mapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using backEnd_EM.Dtos.Athletes;
using backEnd_EM.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace backEnd_EM.Controllers
{
    [Route("api/program")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository _programRepo;
        public ProgramController(IProgramRepository programRepository)
        {
            _programRepo = programRepository;
        }


        //grabbing all programs
        [HttpGet("getAllPrograms")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllPrograms()
        {
            var programs = await _programRepo.GetAllPrograms();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(programs);
        }


        //grab program by id
        [HttpGet("getProgramById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetProgramId([FromRoute] int id)
        {
            var program = await _programRepo.GetProgramById(id);
            if (program == null)
            {
                return BadRequest("Program is not found in database");
            }
            return Ok(program);
        }

        //getting program by name
        [HttpGet("getProgramByName/{name}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetProgramByName([FromRoute] string name)
        {
            var program = await _programRepo.GetProgramByName(name);
            if (program == null)
            {
                return BadRequest("Program is not found in database");
            }
            return Ok(program);
        }

        //creating program to purchase
        [HttpPost("createProgram")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> createProgram([FromBody] CreateProgramDto ProgramFromBody)
        {
            var program = ProgramFromBody.CreateProgramFromProgramDto();

            var ProgramResponse = await _programRepo.CreateProgramTracker(program);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ProgramResponse);

        }
    }


}