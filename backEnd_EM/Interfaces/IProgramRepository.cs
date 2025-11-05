using backEnd_EM.Dtos;
using backEnd_EM.Properties.Models;

namespace backEnd_EM.Interfaces
{
    public interface IProgramRepository
    {

        Task<List<Programs>> GetAllPrograms();

        //done
        Task<Programs?> GetProgramById(int id);

        //done
        Task<Programs?> UpdatePromgramIdAndUserId(int id, UpdateProgramDto updateModel);

        //done
        Task<Programs?> DeletePrgramById(int id);

        //done
        Task<Programs> CreateProgramTracker(Programs progressTrackerModel);

        Task<Programs?> GetProgramByName(string name);

        Task<Programs?> GetProgramByIdandCost(int programId, int cost);
    }
}