namespace SeminarHub.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data;
    using Data.DataValidation;
    using Data.Models;
    using Models.Seminar;
    using Models.Category;

    public class SeminarService : ISeminarService
	{
		private readonly SeminarHubDbContext context;

		public SeminarService(SeminarHubDbContext _context)
		{
			context = _context;
		}

		public async Task AddSeminarAsync(SeminarFormViewModel model, string userId)
		{
			var entity = new Seminar()
			{
				Topic = model.Topic,
				Lecturer = model.Lecturer,
				Details = model.Details,
				OrganizerId = userId,
				DateAndTime = model.DateAndTime,
				Duration = model.Duration,
				CategoryId = model.CategoryId
			};

			await context.Seminars.AddAsync(entity);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<SeminarInfoViewModel>> GetAllSeminarsAsync()
		{
			return await context.Seminars
				.AsNoTracking()
				.Select(s => new SeminarInfoViewModel
				{
					Id = s.Id,
					Topic = s.Topic,
					Lecturer = s.Lecturer,
					Organizer = s.Organizer.UserName,
					DateAndTime = s.DateAndTime.ToString(DataConstants.Seminar.DateFormat),
					Category = s.Category.Name
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<SeminarInfoViewModel>> GetJoinedSeminarsAsync(string userId)
		{
			return await context.SeminarsParticipants
			 .AsNoTracking()
			 .Where(sp => sp.ParticipantId == userId)
			 .Select(sp => new SeminarInfoViewModel()
			 {
				 Id = sp.SeminarId,
				 Topic = sp.Seminar.Topic,
				 Lecturer = sp.Seminar.Lecturer,
				 Organizer = sp.Seminar.Organizer.UserName,
				 DateAndTime = sp.Seminar.DateAndTime.ToString(DataConstants.Seminar.DateFormat),
				 Category = sp.Seminar.Category.Name
			 }).ToArrayAsync();
		}

		public async Task<SeminarFormViewModel> GetSeminarByIdAsync(int id, string userId)
		{
			var seminar = await context.Seminars.FindAsync(id);

			if (seminar == null)
			{
				throw new ArgumentException();
			}

			if (seminar.OrganizerId != userId)
			{
				throw new InvalidOperationException();
			}


			return new SeminarFormViewModel()
			{
				Topic = seminar.Topic,
				Lecturer = seminar.Lecturer,
				Details = seminar.Details,
				DateAndTime = seminar.DateAndTime,
				Duration = seminar.Duration,
				CategoryId = seminar.CategoryId,
				Categories = await GetCategoriesAsync()
			};
		}

		public async Task EditSeminarAsync(int id, SeminarFormViewModel model, string userId)
		{
			var seminar = await context.Seminars.FindAsync(id);

			if (seminar == null)
			{
				throw new ArgumentException();
			}

			if (seminar.OrganizerId != userId)
			{
				throw new InvalidOperationException();
			}

			seminar.Topic = model.Topic;
			seminar.Lecturer = model.Lecturer;
			seminar.Details = model.Details;
			seminar.DateAndTime = model.DateAndTime;
			seminar.Duration = model.Duration;
			seminar.CategoryId = model.CategoryId;

			await context.SaveChangesAsync();
		}

		public async Task JoinSeminarAsync(int id, string userId)
		{
			var seminar = await context.Seminars
				.Where(s => s.Id == id)
				.Include(s => s.SeminarsParticipants)
				.FirstOrDefaultAsync();

			if (seminar == null)
			{
				throw new ArgumentException();
			}

			if (seminar.SeminarsParticipants.Any(ep => ep.ParticipantId == userId))
			{
				throw new InvalidOperationException();
			}

			seminar.SeminarsParticipants.Add(new SeminarParticipant()
			{
				ParticipantId = userId,
			});

			await context.SaveChangesAsync();
		}

		public async Task LeaveSeminarAsync(int id, string userId)
		{
			var seminar = await context.Seminars
			   .Where(e => e.Id == id)
			   .Include(e => e.SeminarsParticipants)
			   .FirstOrDefaultAsync();

			if (seminar == null)
			{
				throw new ArgumentException();
			}

			var entry = seminar.SeminarsParticipants.FirstOrDefault(ep => ep.ParticipantId == userId);

			if (entry != null)
			{
				seminar.SeminarsParticipants.Remove(entry);
			}

			await context.SaveChangesAsync();
		}

		public async Task<SeminarDetailsViewModel> GetSeminarDetailsAsync(int id)
		{
			var model = await context.Seminars
				.AsNoTracking()
				.Where(s => s.Id == id)
				.Select(s => new SeminarDetailsViewModel()
				{
					Id = id,
					Topic = s.Topic,
					Lecturer = s.Lecturer,
					Details = s.Details,
					Organizer = s.Organizer.UserName,
					DateAndTime = s.DateAndTime.ToString(DataConstants.Seminar.DateFormat),
					Duration = s.Duration,
					Category = s.Category.Name
				}).FirstOrDefaultAsync();

			if (model == null)
			{
				throw new ArgumentException();
			}

			return model;
		}

		public async Task<SeminarDeleteViewModel> GetSeminarToDeleteByIdAsync(int id, string userId)
		{
			var seminar = await context.Seminars.FindAsync(id);

			if (seminar == null)
			{
				throw new ArgumentException();
			}

			if (seminar.OrganizerId != userId)
			{
				throw new InvalidOperationException();
			}

			return new SeminarDeleteViewModel()
			{
				Id = seminar.Id,
				Topic = seminar.Topic,
				DateAndTime = seminar.DateAndTime
			};
		}

		public async Task DeleteSeminarAsync(int id, string userId)
		{
			var seminar = await context.Seminars.FindAsync(id);

			if (seminar == null)
			{
				throw new ArgumentException();
			}

			if (seminar.OrganizerId != userId)
			{
				throw new InvalidOperationException();
			}

			context.Seminars.Remove(seminar);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
		{
			return await context.Categories
				.Select(c => new CategoryViewModel
				{
					Id = c.Id,
					Name = c.Name
				}).ToArrayAsync();
		}

	}
}

