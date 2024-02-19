namespace Homies.Contracts
{
    using System.Threading.Tasks;

    using Homies.Models;

    public interface IEventService
    {
        Task AddEventAsync(EventFormViewModel model,string userId);

        Task EditEventAsync(int id,EventFormViewModel model, string userId);

        Task<IEnumerable<EventInfoViewModel>> GetAllEventsAsync();

        Task<EventDetailsViewModel> GetEventDetailsAsync(int id);

        Task<EventFormViewModel> GetEventFormViewModelAsync(int id, string userId);

        Task<IEnumerable<TypeViewModel>> GetEventTypesAsync();

        Task<IEnumerable<EventInfoViewModel>> GetJoinedEventsAsync(string userId);

        Task JoinToEventAsync(int id, string userId);

        Task LeaveEventAsync(int id, string userId);
    }
}
