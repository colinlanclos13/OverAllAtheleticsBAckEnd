using System.Runtime.CompilerServices;
using backEnd_EM.Dtos;
using backEnd_EM.Interfaces;
using backEnd_EM.Models;
using backEnd_EM.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Engines;

namespace backEnd_EM.Repository
{
    public class SubprogramRep : ISubProgramRepo
    {
        private readonly AppDBContext _context;
        public SubprogramRep(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Subprogram>> GetAllSubPrograms()
        {
            var programs = await _context.Subprograms.ToListAsync();
            if (programs == null)
            {
                return null;
            }
            return programs;
        }

        public async Task<Subprogram> GetSubProgramById(int id)
        {
            var program = await _context.Subprograms.FirstOrDefaultAsync(a => a.SubprogramId == id);
            if (program == null)
            {
                return null;
            }
            return program;
        }


        public async Task<Subprogram> GetSubProgramByMonth(int month)
        {
            var program = await _context.Subprograms.FirstOrDefaultAsync(a => a.Month == month);
            if (program == null)
            {
                return null;
            }
            return program;

        }

        public async Task<Subprogram?> UpdateSubprogram(int month, string level, string UpdateProgramJSON)
        {
            var program = await _context.Subprograms.FirstOrDefaultAsync(a => a.Month == month && a.Level == level);
            if (program == null)
            {
                return null;
            }
            program.ProgramJSON = UpdateProgramJSON;
            await _context.SaveChangesAsync();
            return program;

        }

        public async Task<Subprogram?> DeleteSubprogram(int month, string level)
        {
            var program = await _context.Subprograms.FirstOrDefaultAsync(a => a.Month == month && a.Level == level);
            if (program == null)
            {
                return null;
            }
            _context.Remove(program);
            await _context.SaveChangesAsync();
            return program;

        }

        public async Task<Subprogram> CreateSubProgram(Subprogram subprogram)
        {
            await _context.Subprograms.AddAsync(subprogram);
            await _context.SaveChangesAsync();
            return subprogram;
        }

    }
}
