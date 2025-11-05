namespace backEnd_EM.Dtos.Athletes
{
    public class LoginResponseDto
    {
        public int Id { get; set; }

        public string Jwt { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

    }
}