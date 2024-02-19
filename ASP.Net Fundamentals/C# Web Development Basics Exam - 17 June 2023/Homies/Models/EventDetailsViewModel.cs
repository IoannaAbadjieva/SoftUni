namespace Homies.Models
{
    public class EventDetailsViewModel : EventInfoViewModel
    {
        public string Description {  get; set; } = string.Empty;

        public string CreatedOn { get; set; } = string.Empty;

        public string End { get; set; } = string.Empty;

    }
}
