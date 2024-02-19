namespace Homies.Services
{
    using Homies.Contracts;
    using Homies.Data;
    using Homies.Data.DataValidations;
    using Homies.Data.Models;
    using Homies.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext _context)
        {
            context = _context;
        }

        public async Task AddEventAsync(EventFormViewModel model, string userId)
        {
            var entity = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = userId,
                CreatedOn = DateTime.Now,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId
            };

            await context.Events.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditEventAsync(int id, EventFormViewModel model, string userId)
        {
            var @event = await context.Events.FindAsync(id);

            if (@event == null)
            {
                throw new ArgumentException();
            }

            if (@event.OrganiserId != userId)
            {
                throw new InvalidOperationException();
            }

            @event.Name = model.Name;
            @event.Description = model.Description;
            @event.Start = model.Start;
            @event.End = model.End;
            @event.TypeId = model.TypeId;

            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<EventInfoViewModel>> GetAllEventsAsync()
        {
            return await context.Events
                .AsNoTracking()
                .Select(e => new EventInfoViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Organiser = e.Organiser.UserName,
                    Start = e.Start.ToString(DataConstants.DateFormat),
                    Type = e.Type.Name
                }).ToArrayAsync();
        }

        public async Task<EventDetailsViewModel> GetEventDetailsAsync(int id)
        {
            var model = await context.Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new EventDetailsViewModel()
                {
                    Id = id,
                    Name = e.Name,
                    Description = e.Description,
                    Organiser = e.Organiser.UserName,
                    CreatedOn = e.CreatedOn.ToString(DataConstants.DateFormat),
                    Start = e.Start.ToString(DataConstants.DateFormat),
                    End =   e.End.ToString(DataConstants.DateFormat),
                    Type = e.Type.Name
                }).FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentException();
            }

            return model;
        }

        public async Task<EventFormViewModel> GetEventFormViewModelAsync(int id, string userId)
        {
            var @event = await context.Events.FindAsync(id);

            if (@event == null)
            {
                throw new ArgumentException();
            }

            if (@event.OrganiserId != userId)
            {
                throw new InvalidOperationException();
            }

            return new EventFormViewModel()
            {
                Name = @event.Name,
                Description = @event.Description,
                Start = @event.Start,
                End = @event.End,
                TypeId = @event.TypeId,
                Types = await GetEventTypesAsync()
            };

        }

        public async Task<IEnumerable<TypeViewModel>> GetEventTypesAsync()
        {
            return await context.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToArrayAsync();
        }

        public async Task<IEnumerable<EventInfoViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await context.EventsParticipants
                .AsNoTracking()
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new EventInfoViewModel()
                {
                    Id = ep.EventId,
                    Name = ep.Event.Name,
                    Organiser = ep.Event.Organiser.UserName,
                    Start = ep.Event.Start.ToString(DataConstants.DateFormat),
                    Type = ep.Event.Type.Name
                }).ToArrayAsync();

        }

        public async Task JoinToEventAsync(int id, string userId)
        {
            var @event = await context.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (@event == null)
            {
                throw new ArgumentException();
            }

            if (!@event.EventsParticipants.Any(ep => ep.HelperId == userId))
            {
                @event.EventsParticipants.Add(new EventParticipant()
                {
                    HelperId = userId,
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task LeaveEventAsync(int id, string userId)
        {
            var @event = await context.Events
               .Where(e => e.Id == id)
               .Include(e => e.EventsParticipants)
               .FirstOrDefaultAsync();

            if (@event == null)
            {
                throw new ArgumentException();
            }

            var entry = @event.EventsParticipants.FirstOrDefault(ep => ep.HelperId == userId);

            if (entry != null)
            {
                @event.EventsParticipants.Remove(entry);
            }

            await context.SaveChangesAsync();
        }
    }
}
