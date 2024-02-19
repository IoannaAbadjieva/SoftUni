namespace SeminarHub.Models.Seminar
{
    public class SeminarDetailsViewModel : SeminarInfoViewModel
    {
        public string Details { get; set; } = string.Empty;

        public int? Duration { get; set; }
    }
}
