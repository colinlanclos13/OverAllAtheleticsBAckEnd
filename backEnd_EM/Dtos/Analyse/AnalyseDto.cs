namespace backEnd_EM.Dtos.Analyse
{
    public class AnalyseDto
    {
        public int id { get; set; }
        public string videoURL { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string BreakDown { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
    }
}