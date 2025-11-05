namespace backEnd_EM.Dtos.Athletes
{

    public class CreateAthleteRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public int age { get; set; }
        public string Email { get; set; } = string.Empty;
        public long Phone { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}