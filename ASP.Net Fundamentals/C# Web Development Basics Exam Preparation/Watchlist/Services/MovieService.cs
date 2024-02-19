namespace Watchlist.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data;
    using Data.Models;
    using Models;

    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }

        public async Task AddMovieAsync(MovieFormViewModel model)
        {
            Movie movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var userMovie = await context.UsersMovies
                .FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);

            if (userMovie == null)
            {
                await context.UsersMovies.AddAsync(new UserMovie()
                {
                    MovieId = movieId,
                    UserId = userId
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieInfoViewModel>> GetAllMoviesAsync()
        {
            return await context.Movies
                .Select(m => new MovieInfoViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.Name
                }).ToArrayAsync();
        }

        public async Task<MovieFormViewModel> GetNewMovieFormViewModelAsync()
        {
            var model = new MovieFormViewModel();

            model.Genres = await context.Genres
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                }).ToArrayAsync();

            return model;
        }

        public async Task<IEnumerable<MovieInfoViewModel>> GetWatchedMoviesAsync(string userId)
        {
            return await context.UsersMovies
                .Where(um => um.UserId == userId)
                .Select(um => new MovieInfoViewModel()
                {
                    Id = um.MovieId,
                    Title = um.Movie.Title,
                    Director = um.Movie.Director,
                    ImageUrl = um.Movie.ImageUrl,
                    Rating = um.Movie.Rating,
                    Genre = um.Movie.Genre.Name
                }).ToArrayAsync();
        }

        public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        {
            var userMovie = await context.UsersMovies
               .FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);

            if (userMovie != null)
            {
                context.UsersMovies.Remove(userMovie);
                await context.SaveChangesAsync();
            }
        }
    }
}
