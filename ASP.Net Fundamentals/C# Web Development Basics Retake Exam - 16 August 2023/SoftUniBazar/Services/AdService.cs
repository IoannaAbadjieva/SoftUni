namespace SoftUniBazar.Services
{
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Data;
	using Data.Models;
	using Models;

	public class AdService : IAdService
	{
		private readonly BazarDbContext context;

		public AdService(BazarDbContext _context)
		{
			context = _context;
		}

		public async Task<IEnumerable<AdInfoViewModel>> GetAllAdsAsync()
		{
			return await context.Ads
				.AsNoTracking()
				.Select(a => new AdInfoViewModel()
				{
					Id = a.Id,
					Name = a.Name,
					ImageUrl = a.ImageUrl,
					CreatedOn = a.CreatedOn.ToString(Validations.ValidationConstants.Ad.DateFormat),
					Category = a.Category.Name,
					Description = a.Description,
					Price = a.Price,
					Owner = a.Owner.UserName

				}).ToArrayAsync();
		}


		public async Task AddAdAsync(AdFormViewModel model, string userId)
		{
			var ad = new Ad()
			{
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
				OwnerId = userId,
				ImageUrl = model.ImageUrl,
				CreatedOn = DateTime.Now,
				CategoryId = model.CategoryId,
			};

			await context.Ads.AddAsync(ad);
			await context.SaveChangesAsync();

		}

		public async Task EditAdAsync(AdFormViewModel model, int id, string userId)
		{
			var ad = await context.Ads.FindAsync(id);

			if (ad == null)
			{
				throw new ArgumentNullException();
			}

			if (ad.OwnerId != userId)
			{
				throw new InvalidOperationException();
			}

			ad.Name = model.Name;
			ad.Description = model.Description;
			ad.Price = model.Price;
			ad.ImageUrl = model.ImageUrl;
			ad.CategoryId = model.CategoryId;

			await context.SaveChangesAsync();
		}


		public async Task AddAdToCartAsync(int id, string userId)
		{
			Ad? ad = await context.Ads.FindAsync(id);

			if (ad == null)
			{
				throw new ArgumentNullException();
			}

			var adByer = await context.AdsBuyers
				.Where(ab => ab.BuyerId == userId && ab.AdId == id)
				.FirstOrDefaultAsync();

			if (adByer == null)
			{
				await context.AdsBuyers.AddAsync(new AdBuyer()
				{
					BuyerId = userId,
					AdId = id
				});
				await context.SaveChangesAsync();
			}
		}

		public async Task RemoveAdFromCartAsync(int id, string userId)
		{
			Ad? ad = await context.Ads.FindAsync(id);

			if (ad == null)
			{
				throw new ArgumentNullException();
			}

			var adByer = await context.AdsBuyers
				.Where(ab => ab.BuyerId == userId && ab.AdId == id)
				.FirstOrDefaultAsync();

			if (adByer == null)
			{
				throw new ArgumentNullException();
			}
			context.AdsBuyers.Remove(adByer);
			await context.SaveChangesAsync();
		}

		public async Task<AdFormViewModel> GetNewAdFormViewModelAsync()
		{
			var model = new AdFormViewModel()
			{
				Categories = await GetCategoriesAsync()
			};

			return model;
		}

		private async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
		{
			return await context.Categories
				.AsNoTracking()
				.Select(c => new CategoryViewModel()
				{
					Id = c.Id,
					Name = c.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<AdInfoViewModel>> GetCartAsync(string userId)
		{
			return await context.AdsBuyers
				.AsNoTracking()
				.Where(ab => ab.BuyerId == userId)
				.Select(ab => new AdInfoViewModel()
				{
					Id = ab.AdId,
					Name = ab.Ad.Name,
					ImageUrl = ab.Ad.ImageUrl,
					CreatedOn = ab.Ad.CreatedOn.ToString(Validations.ValidationConstants.Ad.DateFormat),
					Category = ab.Ad.Category.Name,
					Description = ab.Ad.Description,
					Price = ab.Ad.Price,
					Owner = ab.Ad.Owner.UserName
				}).ToArrayAsync();
		}

		public async Task<AdFormViewModel> GetNewAdEditViewModelAsync(int id, string userId)
		{
			Ad? ad = await context.Ads.FindAsync(id);

			if (ad == null)
			{
				throw new ArgumentException();
			}

			if (ad.OwnerId != userId)
			{
				throw new UnauthorizedAccessException();
			}

			IEnumerable<CategoryViewModel> categories = await GetCategoriesAsync();

			return new AdFormViewModel()
			{
				Name = ad.Name,
				Description = ad.Description,
				ImageUrl = ad.ImageUrl,
				Price = ad.Price,
				CategoryId = ad.CategoryId,
				Categories = categories
			};
		}
	}
}
