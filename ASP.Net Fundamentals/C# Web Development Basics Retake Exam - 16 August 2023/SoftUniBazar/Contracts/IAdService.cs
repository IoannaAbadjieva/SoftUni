namespace SoftUniBazar.Contracts
{
	using System.Collections.Generic;

	using Models;

	public interface IAdService
	{
		Task AddAdAsync(AdFormViewModel model, string userId);

		Task AddAdToCartAsync(int id, string userId);

		Task EditAdAsync(AdFormViewModel model, int id,string userId);

		Task<AdFormViewModel> GetNewAdEditViewModelAsync(int id,string userId);

		Task<IEnumerable<AdInfoViewModel>> GetAllAdsAsync();

		Task<IEnumerable<AdInfoViewModel>> GetCartAsync(string userId);

		Task<AdFormViewModel> GetNewAdFormViewModelAsync();

		Task RemoveAdFromCartAsync(int id, string userId);
	}
}
