using System.Runtime.CompilerServices;
using backEnd_EM.Dtos;
using backEnd_EM.Interfaces;
using backEnd_EM.Models;
using backEnd_EM.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Engines;

namespace backEnd_EM.Repository
{
    public class ProgramRepository : IProgramRepository
    {

        private readonly AppDBContext _context;

        public ProgramRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Programs> CreateProgramTracker(Programs program)
        {
            await _context.Programs.AddAsync(program);
            await _context.SaveChangesAsync();
            return program;

        }

        public async Task<Programs?> DeletePrgramById(int id)
        {
            var program = await _context.Programs.FirstOrDefaultAsync(a => a.ProgramId == id);
            if (program == null)
            {
                return null;
            }
            _context.Remove(program);
            await _context.SaveChangesAsync();
            return program;

        }

        //done
        public async Task<List<Programs>> GetAllPrograms()
        {
            var programs = await _context.Programs.ToListAsync();
            return programs;
        }
        //done
        public async Task<Programs?> GetProgramById(int id)
        {
            var program = await _context.Programs.FirstOrDefaultAsync(a => a.ProgramId == id);
            if (program == null)
            {
                return null;
            }
            return program;
        }

        public async Task<Programs?> GetProgramByIdandCost(int programId, int cost)
        {
            var program = await _context.Programs.FirstOrDefaultAsync(a => a.ProgramId == programId && a.cost == cost);

            if (program == null)
            {
                return null;
            }
            return program;
        }

        public async Task<Programs?> GetProgramByName(string name)
        {
            var program = await _context.Programs.FirstOrDefaultAsync(a => a.ProgramName == name);
            if (program == null)
            {
                return null;
            }
            return program;
        }

        public async Task<Programs?> UpdatePromgramIdAndUserId(int id, UpdateProgramDto updateModel)
        {
            var program = await _context.Programs.FirstOrDefaultAsync(a => a.ProgramId == id);
            if (program == null)
            {
                return null;
            }
            var time = DateTime.Now;

            await _context.SaveChangesAsync();

            return program;
        }
    }
}