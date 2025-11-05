namespace backEnd_EM.Dtos
{
    //idk if we need this type shit
    public class CreateProgramDto
    {
        public string ProgramName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string linkToProgram { get; set; } = string.Empty;

        public float cost { get; set; } = 0;

    }
}