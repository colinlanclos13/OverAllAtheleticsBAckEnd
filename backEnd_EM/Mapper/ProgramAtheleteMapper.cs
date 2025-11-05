using backEnd_EM.Dtos;
using backEnd_EM.Migrations;
using backEnd_EM.Properties.Models;
using Org.BouncyCastle.Bcpg;

namespace backEnd_EM.Mapper
{
    public static class ProgramAthleteMapper
    {
        public static ProgramAthlete CreateProgramAthelteFromProgramDto(this CreateProgramAthleteDto programAthleteDtoModel, string dateString)
        {
            return new ProgramAthlete
            {
                AthletesId = programAthleteDtoModel.athleteId,
                ProgramsId = programAthleteDtoModel.programId,
                orderId = programAthleteDtoModel.orderId,
                PurchasedDate = dateString
            };
        }

    }
}