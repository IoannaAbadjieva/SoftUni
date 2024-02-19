using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private HashSet<Actor> actors;
        private HashSet<Movie> movies;
        private Dictionary<string, HashSet<Movie>> actorMovies;
        private HashSet<Actor> newbieActors;

        public MovieDatabase()
        {
            this.actors = new HashSet<Actor>();
            this.movies = new HashSet<Movie>();
            this.actorMovies = new Dictionary<string, HashSet<Movie>>();
            this.newbieActors = new HashSet<Actor>();
        }

        public void AddActor(Actor actor)
        {
            this.actors.Add(actor);
            this.newbieActors.Add(actor);
            this.actorMovies.Add(actor.Id, new HashSet<Movie>());
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!this.actors.Contains(actor))
            {
                throw new ArgumentException();
            }

            this.movies.Add(movie);
            this.actorMovies[actor.Id].Add(movie);
            this.newbieActors.Remove(actor);
        }

        public bool Contains(Actor actor)
        {
            return this.actors.Contains(actor);
        }

        public bool Contains(Movie movie)
        {
            return this.movies.Contains(movie);
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            return this.actors
                .OrderByDescending(a => actorMovies[a.Id].Max(movie => movie.Budget))
                .ThenByDescending(a => actorMovies[a.Id].Count);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return this.movies;
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            return this.movies
                .Where(m => m.Budget >= lower && m.Budget <= upper)
                .OrderByDescending(m => m.Rating);
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            return this.movies
                .OrderByDescending(m => m.Budget)
                .ThenByDescending(m => m.Rating);
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            return this.newbieActors;
        }
    }
}
