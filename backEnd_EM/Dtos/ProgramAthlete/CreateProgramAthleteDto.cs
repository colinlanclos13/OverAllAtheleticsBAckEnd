namespace backEnd_EM.Dtos
{
    //idk if we need this type shit
    public class CreateProgramAthleteDto
    {
        public int athleteId { get; set; }
        public int programId { get; set; }
        public string orderId { get; set; } = string.Empty;
        public int cost { get; set; }

    }
}