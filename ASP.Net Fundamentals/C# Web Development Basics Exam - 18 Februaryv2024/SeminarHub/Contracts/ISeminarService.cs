namespace SeminarHub.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Category;
    using Models.Seminar;

    public interface ISeminarService
	{
		Task AddSeminarAsync(SeminarFormViewModel model, string userId);

		Task EditSeminarAsync(int id, SeminarFormViewModel model, string userId);

		Task<IEnumerable<SeminarInfoViewModel>> GetAllSeminarsAsync();

		Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();

		Task<IEnumerable<SeminarInfoViewModel>> GetJoinedSeminarsAsync(string userId);

		Task<SeminarDetailsViewModel> GetSeminarDetailsAsync(int id);

		Task<SeminarFormViewModel> GetSeminarByIdAsync(int id, string userId);

		Task JoinSeminarAsync(int id, string userId);

		Task LeaveSeminarAsync(int id, string userId);

		Task DeleteSeminarAsync(int id, string userId);

		Task<SeminarDeleteViewModel> GetSeminarToDeleteByIdAsync(int id, string userId);
	}
}
