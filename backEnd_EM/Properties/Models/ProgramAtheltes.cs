using System;
using System.ComponentModel.DataAnnotations;
namespace backEnd_EM.Properties.Models
{
    public class ProgramAthlete
    {
        public int ProgramsId { get; set; }
        public int? AthletesId { get; set; }
        public string PurchasedDate { get; set; } = string.Empty;
        public string orderId { get; set; } = string.Empty;
        public Programs Program { get; set; }
        public Athletes Athlete { get; set; }
    }
}