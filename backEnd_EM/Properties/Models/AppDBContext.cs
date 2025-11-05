using backEnd_EM.Migrations;
using backEnd_EM.Properties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace backEnd_EM.Models
{
    public class AppDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Analyse> Analyses { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Athletes> Athletes { get; set; }

        public DbSet<Guardians> Guardians { get; set; }
        public DbSet<ProgramAthlete> programAthletes { get; set; }
        public DbSet<ProgressTracker> ProgressTrackers { get; set; }
        public DbSet<Analytics> Analytics { get; set; }

        public DbSet<Programs> Programs { get; set; }

        public DbSet<Subprogram> Subprograms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProgramAthlete>(x => x.HasKey(p => new { p.ProgramsId, p.AthletesId }));

            modelBuilder.Entity<ProgramAthlete>().HasOne(u => u.Athlete).WithMany(u => u.ProgramAthletes).HasForeignKey(p => p.AthletesId);

            modelBuilder.Entity<ProgramAthlete>().HasOne(u => u.Program).WithMany(u => u.ProgramAthletes).HasForeignKey(p => p.ProgramsId);

        }
    }
}