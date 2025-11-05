using System;
using System.ComponentModel.DataAnnotations;
namespace backEnd_EM.Dtos
{
    public class CreateSubprogramDto
    {
        public string Level { get; set; }
        public string ProgramJSON { get; set; } = string.Empty;
        public int Month { get; set; }
    }
}