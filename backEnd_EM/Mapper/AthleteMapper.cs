using backEnd_EM.Dtos.Athletes;
using backEnd_EM.Properties.Models;

namespace backEnd_EM.Mapper
{

    public static class AthleteMapper
    {
        public static AthletesDto ToAthletesDto(this Athletes athletesModel)
        {
            return new AthletesDto
            {
                Name = athletesModel.Name,
                Guardian = athletesModel.Guardian,
                Email = athletesModel.Email,
                age = athletesModel.Age,
                Classification = athletesModel.Classification,
                Height = athletesModel.Height,
                Weight = athletesModel.Weight,
                School = athletesModel.School,
                Phone = athletesModel.Phone
            };
        }

        public static Athletes ToAthleteFromCreateDTO(this CreateAthleteRequestDto athleteDto, byte[] HashPassword, byte[] Passwordsalt)
        {
            return new Athletes
            {
                Name = athleteDto.Name,
                Age = athleteDto.age,
                Phone = athleteDto.Phone,
                Email = athleteDto.Email,
                Password = HashPassword,
                PasswordSalt = Passwordsalt,
                Role = "user"
            };
        }

        public static AthleteAthletesNumbersDto ToAthleteAthleteNumberDto(this Athletes athleteIdDModel)
        {
            return new AthleteAthletesNumbersDto
            {
                Name = athleteIdDModel.Name,
                Phone = athleteIdDModel.Phone
            };
        }

        public static LoginResponseDto LoginResponseToDto(this Athletes model, string _jwt)
        {
            return new LoginResponseDto
            {
                Id = model.Id,
                Jwt = _jwt,
                Email = model.Email,
            };
        }
    }
}