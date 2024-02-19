namespace Watchlist.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Contracts;
    using Models;

    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<MovieInfoViewModel> model = await movieService.GetAllMoviesAsync();

            return View(model);
        }

        public async Task<IActionResult> Watched()
        {
            var userId = GetUserId();

            IEnumerable<MovieInfoViewModel> model = await movieService.GetWatchedMoviesAsync(userId);

            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = GetUserId();

            await movieService.AddMovieToCollectionAsync(movieId, userId);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = GetUserId();

            await movieService.RemoveMovieFromCollectionAsync(movieId, userId);

            return RedirectToAction(nameof(Watched));
        }

        public async Task<IActionResult> Add()
        {
            MovieFormViewModel model = await movieService.GetNewMovieFormViewModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await movieService.AddMovieAsync(model);

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
