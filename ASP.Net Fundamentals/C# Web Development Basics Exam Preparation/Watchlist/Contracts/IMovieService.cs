namespace Watchlist.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Watchlist.Models;

    public interface IMovieService
    {
        Task AddMovieAsync(MovieFormViewModel model);

        Task AddMovieToCollectionAsync(int movieId, string userId);

        Task<IEnumerable<MovieInfoViewModel>> GetAllMoviesAsync();

        Task<MovieFormViewModel> GetNewMovieFormViewModelAsync();

        Task<IEnumerable<MovieInfoViewModel>> GetWatchedMoviesAsync(string userId);

        Task RemoveMovieFromCollectionAsync(int movieId, string userId);
    }
}
