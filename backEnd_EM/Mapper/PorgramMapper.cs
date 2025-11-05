using backEnd_EM.Dtos;
using backEnd_EM.Migrations;
using backEnd_EM.Properties.Models;
using Org.BouncyCastle.Bcpg;

namespace backEnd_EM.Mapper
{
    public static class ProgramMapper
    {
        public static Programs CreateProgramFromProgramDto(this CreateProgramDto programDtoModel)
        {
            return new Programs
            {
                ProgramName = programDtoModel.ProgramName,
                Description = programDtoModel.Description,
                linkToProgram = programDtoModel.linkToProgram,
                cost = programDtoModel.cost,
            };
        }
    }
}