using System;
using System.Linq;

namespace Exam.MovieDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieDatabase movieDatabase = new MovieDatabase();

            Actor actor1 = new Actor("1", "One", 21);
            Actor actor2 = new Actor("2", "Two", 22);
            Actor actor3 = new Actor("3", "Three", 23);
            Actor actor4 = new Actor("4", "Four", 24);

            movieDatabase.AddActor(actor1);
            movieDatabase.AddActor(actor2);
            movieDatabase.AddActor(actor3);
            movieDatabase.AddActor(actor4);

            Movie movie1 = new Movie("1", 100, "MovieOne", 1, 200);
            Movie movie2 = new Movie("2", 200, "MovieTwo", 1, 200);
            Movie movie3 = new Movie("3", 300, "MovieThree", 1, 200);
            Movie movie4 = new Movie("4", 400, "MovieFour", 4, 300);
            Movie movie5 = new Movie("5", 500, "MovieFive", 5,800);

            movieDatabase.AddMovie(actor1, movie1);
            movieDatabase.AddMovie(actor1, movie4);
            movieDatabase.AddMovie(actor2, movie2);
            movieDatabase.AddMovie(actor2, movie5);
            movieDatabase.AddMovie(actor3, movie3);
            movieDatabase.AddMovie(actor4, movie5);

            Console.WriteLine(movieDatabase.Contains(movie5));
            Console.WriteLine(movieDatabase.Contains(actor4));
            
            Console.WriteLine(string.Join(", ", movieDatabase.GetNewbieActors().Select(a => a.Name)));
            Console.WriteLine(string.Join(", ", movieDatabase.GetActorsOrderedByMaxMovieBudgetThenByMoviesCount().Select(a => a.Name)));
            Console.WriteLine(string.Join(", ", movieDatabase.GetMoviesInRangeOfBudget(10, 20).Select(m => m.Title)));
            Console.WriteLine(string.Join(", ", movieDatabase.GetMoviesOrderedByBudgetThenByRating().Select(m => m.Title)));


        }
    }
}
