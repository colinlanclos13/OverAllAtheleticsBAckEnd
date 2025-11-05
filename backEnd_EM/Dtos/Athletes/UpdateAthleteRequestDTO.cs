namespace backEnd_EM.Dtos.Athletes
{

    public class UpdateAthleteRequestDTO
    {
        public string Name { get; set; } = string.Empty;

        public int age { get; set; }

        public long Phone { get; set; }

        public string email { get; set; }
    }
}