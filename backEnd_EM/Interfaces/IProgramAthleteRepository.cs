using backEnd_EM.Dtos;
using backEnd_EM.Dtos.Athletes;
using backEnd_EM.Properties.Models;

namespace backEnd_EM.Interfaces
{
    public interface IProgramAthelteRepository
    {
        Task<List<Programs>> GetListOfProgramsFromAtheleteId(int AthletesId);

        Task<List<ProgramAthlete>> GetListOfProgramsAthelteFromAthelete(int AthletesId);
        Task<List<AthleteAthletesNumbersDto>> GetListOfAtheletesFromPrgramId(int ProgramId);
        //done
        Task<Boolean?> GetPaymentValidation(int Athleteid, int ProgramId);
        //done
        Task<ProgramAthlete?> UpdatePurchase(int Athleteid, int ProgramId, string OrderId, int cost);
        //done
        Task<ProgramAthlete?> DeletePrgramById(int id);
        //done
        Task<ProgramAthlete> CreateProgramAthelte(ProgramAthlete programAthleteModel);

    }
}