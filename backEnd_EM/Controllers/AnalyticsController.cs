using Microsoft.AspNetCore.Mvc;
using backEnd_EM.Interfaces;
using backEnd_EM.Properties.Models;
using backEnd_EM.Models;
using backEnd_EM.Mapper;
using backEnd_EM.Dtos.Analyse;
using backEnd_EM.Dtos.Analytics;
using Microsoft.AspNetCore.Authorization;
namespace backEnd_EM.Controllers

{
    [Route("api/analytics")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {

        private readonly IAthleteRepository _athleteRepository;

        private readonly IAnalyticsRepository _analyticsRepo;



        public AnalyticsController(IAthleteRepository athleteRepo, IAnalyticsRepository analyticsRepo)
        {
            _athleteRepository = athleteRepo;
            _analyticsRepo = analyticsRepo;
        }


        //grabs all analytics
        [HttpGet]
        [Route("GetAllAnalytics"), Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllAnalytics()
        {
            var Analytics = await _analyticsRepo.AllAnalyticsSorted();

            var analyticDto = Analytics.Select(a => a.ToAnalyticsDto());

            return Ok(analyticDto);
        }


        //create analytics 
        [HttpPost]
        [Route("CreateAnalytis"), Authorize]
        public async Task<IActionResult> CreateAnalytis([FromBody] CreateRequestAnalyticsDto analyticsDto)
        {
            var analyticModel = analyticsDto.CreateRequest();

            var analytic = await _analyticsRepo.CreateAnalytics(analyticModel);
            if (analytic == null)
            {
                return BadRequest("thing messed up");
            }
            return Ok(analytic);
        }

        //grab analytics for athlete by id
        [HttpGet]
        [Route("GetAnalytisById/{id}"), Authorize]

        //grabbing analytics by athlete phone 
        public async Task<IActionResult> GetAnalytisById([FromRoute] int id)
        {
            var analytic = await _analyticsRepo.GetAnalyticsByAthleteId(id);
            if (analytic == null)
            {
                return BadRequest("System Error");
            }
            return Ok(analytic.ToAnalyticsDto());
        }
        [HttpGet]
        [Route("GetAnalytisByPhone/{phone}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAnalytisByPhone([FromRoute] long phone)
        {
            var AthletesId = await _athleteRepository.GetAthletesByPhoneForId(phone);

            if (AthletesId == null)
            {
                return BadRequest("Phone not found");
            }

            var analytic = await _analyticsRepo.GetAnalyticsByAthleteId((int)AthletesId);
            if (analytic == null)
            {
                return BadRequest("System Error");
            }
            return Ok(analytic.ToAnalyticsDto());
        }


        //updating rank manually 
        [HttpPut]
        [Route("UpdateRank/{phone}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateRank([FromRoute] long phone, [FromBody] UpdateAnalyticsDto updateDto)
        {
            var AthletesId = await _athleteRepository.GetAthletesByPhoneForId(phone);

            if (AthletesId == null)
            {
                return BadRequest("Phone not found");
            }
            var UpdateResponce = await _analyticsRepo.UpdateRank(updateDto, (int)AthletesId);
            if (UpdateResponce == null)
            {
                return BadRequest("System Error");
            }
            return Ok(UpdateResponce);
        }

    }
}
