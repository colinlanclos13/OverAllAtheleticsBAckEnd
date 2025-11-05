using backEnd_EM.Properties.Models;

namespace backEnd_EM.Interfaces
{
    public interface ISubProgramRepo
    {

        Task<List<Subprogram>> GetAllSubPrograms();

        Task<Subprogram?> GetSubProgramById(int id);

        Task<Subprogram?> GetSubProgramByMonth(int month);

        Task<Subprogram?> UpdateSubprogram(int month, string level, string UpdateProgramJSON);

        Task<Subprogram?> DeleteSubprogram(int month, string level);
        Task<Subprogram> CreateSubProgram(Subprogram subprogram);
    }
}