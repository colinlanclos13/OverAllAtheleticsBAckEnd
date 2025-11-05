using System;
using System.ComponentModel.DataAnnotations;

namespace backEnd_EM.Properties.Models
{

    public class Subprogram
    {
        [Key]
        public int SubprogramId { get; set; }

        public string Level { get; set; }

        public string ProgramJSON { get; set; } = string.Empty;
        public int Month { get; set; }

    }
}