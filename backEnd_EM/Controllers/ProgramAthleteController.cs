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
    [Route("api/programathlete")]
    [ApiController]
    public class ProgramAtheltesController : ControllerBase
    {
        private readonly IProgramAthelteRepository _programAthleteRepo;
        private readonly IProgramRepository _programRepository;
        public ProgramAtheltesController(IProgramAthelteRepository programAthleteRepo, IProgramRepository programRepo)
        {
            _programAthleteRepo = programAthleteRepo;
            _programRepository = programRepo;

        }

        //create programathlete when program when purchased
        [HttpPost("createProgramAthlete")]
        [Authorize]

        public async Task<IActionResult> CreateProgramAthlete([FromBody] CreateProgramAthleteDto createProgramDto)
        {

            var checkProgramCostVar = await _programRepository.GetProgramByIdandCost(createProgramDto.programId, createProgramDto.cost);
            if (checkProgramCostVar == null)
            {
                return BadRequest("Cost do not match");
            }
            else
            {
                Console.WriteLine("All Good");
            }

            DateTime myDateTime = DateTime.Now;

            var dateString = myDateTime.ToString("dd/MM/yy");

            var programAthlete = createProgramDto.CreateProgramAthelteFromProgramDto(dateString);

            var response = await _programAthleteRepo.CreateProgramAthelte(programAthlete);
            Console.WriteLine(response);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(response);
        }

        //programathlete list with athlete id 
        [HttpGet("getListOfProgramsWithAthleteId/{athleteId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetListOfProgramsWithAthleteId([FromRoute] int athleteId)
        {
            return Ok(await _programAthleteRepo.GetListOfProgramsFromAtheleteId(athleteId));
        }

        //return list of programs that athletes have purchased and filter out program that have not been purchased
        [HttpGet("getProgramsPurchasedWithAthleteId/{athleteId}")]
        public async Task<IActionResult> GetProgramsPurchasedWithAthleteId([FromRoute] int athleteId)
        {
            List<Programs> programList = await _programRepository.GetAllPrograms();
            Console.WriteLine(athleteId);
            List<ProgramAthlete> ProgramAthleteList = await _programAthleteRepo.GetListOfProgramsAthelteFromAthelete(athleteId);

            var listOfPurchasedPrograms = CheckForProgramPurchased(programList, ProgramAthleteList);

            return Ok(listOfPurchasedPrograms);
        }
        private List<Programs> CheckForProgramPurchased(List<Programs> programList, List<ProgramAthlete> programAthleteList)
        {
            var skip = false;

            List<Programs> programs = new List<Programs>();
            for (int x = 0; x < programList.Count; x++)
            {
                if (programAthleteList != null)
                {
                    for (int y = 0; y < programAthleteList.Count; y++)
                    {
                        if (programList[x].ProgramId == programAthleteList[y].ProgramsId)
                        {
                            skip = true;
                            programs.Add(programList[x]);
                            break;
                        }
                    }
                }
                if (!skip)
                {
                    programList[x].linkToProgram = "Not Purchased";
                    programs.Add(programList[x]);
                }
                skip = false;
            }
            return programs;

        }

        //getting list of Athletes that purchased certain program
        [HttpGet("getListOfAthletesWithPorgramId/{programId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetListOfAthletesWithPorgramId([FromRoute] int programId)
        {
            return Ok(await _programAthleteRepo.GetListOfAtheletesFromPrgramId(programId));
        }


        //uselesss
        [HttpGet("validatePurchase/{programId}/{athleteId}")]
        [Authorize]
        public async Task<IActionResult> ValidatePurchase([FromRoute] int programId, [FromRoute] int athleteId)
        {
            var response = await _programAthleteRepo.GetPaymentValidation(athleteId, programId);

            if (response == null)
            {
                BadRequest("Program or Athlete was missinputed");
            }
            return Ok(response);
        }

        //useless
        [HttpGet("updatePurchase/{programId}/{athleteId}/{purchaseId}/{cost}")]
        [Authorize]
        public async Task<IActionResult> UpdatePurchase([FromRoute] int programId, [FromRoute] int athleteId, [FromRoute] string orderId, [FromRoute] int cost)
        {
            var response = await _programAthleteRepo.UpdatePurchase(athleteId, programId, orderId, cost);
            if (response == null)
            {
                BadRequest("Program or Athlete was missinputed");
            }
            return Ok(response);
        }
    }

}