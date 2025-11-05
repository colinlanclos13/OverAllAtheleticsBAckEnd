
using backEnd_EM.Dtos;
using backEnd_EM.Migrations;
using backEnd_EM.Properties.Models;

namespace backEnd_EM.Mapper
{
    public static class SubprogramMapper
    {
        public static Subprogram CreateSubprogramFromDto(this CreateSubprogramDto subProgramDto)
        {
            return new Subprogram
            {
                Level = subProgramDto.Level,
                ProgramJSON = subProgramDto.ProgramJSON,
                Month = subProgramDto.Month,
            };
        }
    }
}