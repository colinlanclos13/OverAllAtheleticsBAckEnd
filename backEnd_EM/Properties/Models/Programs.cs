using System;
using System.ComponentModel.DataAnnotations;
namespace backEnd_EM.Properties.Models
{
    public class Programs
    {
        [Key]
        public int ProgramId { get; set; }

        public string ProgramName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string linkToProgram { get; set; } = string.Empty;

        public float cost { get; set; }


        public List<ProgramAthlete> ProgramAthletes { get; set; } = new List<ProgramAthlete>();
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    }
}