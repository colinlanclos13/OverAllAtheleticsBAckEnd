using backEnd_EM.Dtos;
using backEnd_EM.Dtos.Athletes;
using backEnd_EM.Interfaces;
using backEnd_EM.Models;
using backEnd_EM.Properties.Models;
using Microsoft.EntityFrameworkCore;

namespace backEnd_EM.Repository
{
    public class ProgramAthelteRepository : IProgramAthelteRepository
    {
        private readonly AppDBContext _context;

        public ProgramAthelteRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<ProgramAthlete> CreateProgramAthelte(ProgramAthlete programAthleteModel)
        {
            await _context.programAthletes.AddAsync(programAthleteModel);
            await _context.SaveChangesAsync();
            return programAthleteModel;
        }

        public async Task<ProgramAthlete?> DeletePrgramById(int id)
        {
            var program = await _context.programAthletes.FirstOrDefaultAsync(a => a.ProgramsId == id);
            if (program == null)
            {
                return null;
            }
            _context.programAthletes.Remove(program);
            await _context.SaveChangesAsync();
            return program;

        }

        public async Task<List<AthleteAthletesNumbersDto>> GetListOfAtheletesFromPrgramId(int ProgramId)
        {
            return await _context.programAthletes.Where(u => u.ProgramsId == ProgramId).Select(x => new AthleteAthletesNumbersDto
            {
                Name = x.Athlete.Name,
                Phone = x.Athlete.Phone
            }).ToListAsync();
        }

        public async Task<List<ProgramAthlete>> GetListOfProgramsAthelteFromAthelete(int AthletesId)
        {
            return await _context.programAthletes.Where(x => x.AthletesId == AthletesId).Select(u => new ProgramAthlete
            {
                AthletesId = u.AthletesId,
                ProgramsId = u.ProgramsId,
                PurchasedDate = u.PurchasedDate,
                orderId = u.orderId

            }).ToListAsync();
        }

        public async Task<List<Programs>> GetListOfProgramsFromAtheleteId(int AthletesId)
        {
            return await _context.programAthletes.Where(u => u.AthletesId == AthletesId && u.orderId != " " && u.PurchasedDate != " ").Select(x => new Programs
            {
                ProgramId = x.Program.ProgramId,
                ProgramName = x.Program.ProgramName
            }).ToListAsync();
        }

        public async Task<Boolean?> GetPaymentValidation(int Athleteid, int ProgramId)
        {
            var programAthleteVar = await _context.programAthletes.FirstOrDefaultAsync(a => a.AthletesId == Athleteid && a.ProgramsId == ProgramId);
            if (programAthleteVar == null)
            {
                return false;
            }
            if (!(programAthleteVar.PurchasedDate == ""))
            {
                return true;
            }
            return null;
        }

        public async Task<ProgramAthlete?> UpdatePurchase(int AthleteId, int ProgramId, string OrderId, int cost)
        {
            var programAthleteVar = await _context.programAthletes.FirstOrDefaultAsync(a => a.AthletesId == AthleteId && a.ProgramsId == ProgramId);

            var programVar = _context.Programs.FirstOrDefault(p => p.cost == cost && p.ProgramId == ProgramId);
            if (programVar == null)
            {
                return null;
            }

            if (programAthleteVar == null)
            {
                return null;
            }

            DateTime myDateTime = DateTime.Now;

            var dateString = myDateTime.ToString("dd/MM/yy");

            programAthleteVar.orderId = OrderId;

            programAthleteVar.PurchasedDate = dateString;

            await _context.SaveChangesAsync();

            return null;

        }
    }
}