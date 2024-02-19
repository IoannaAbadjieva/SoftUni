function printMovieInfo(input) {
  const movies = [];
  input.forEach((m) => {
    if (m.includes("addMovie")) {
      const [_, name] = m.split("addMovie ");
      movies.push({ name });
    } else if (m.includes("directedBy")) {
      const [name, director] = m.split(" directedBy ");
      const movie = movies.find((m) => m.name === name);
      if (movie) {
        movie.director = director;
      }
    } else if (m.includes("onDate")) {
      const [name, date] = m.split(" onDate ");
      const movie = movies.find((m) => m.name === name);
      if (movie) {
        movie.date = date;
      }
    }
  });

  movies
    .filter((m) => m.director && m.date)
    .forEach((m) => console.log(JSON.stringify(m)));
}

// printMovieInfo([
//   "addMovie Fast and Furious",
//   "addMovie Godfather",
//   "Inception directedBy Christopher Nolan",
//   "Godfather directedBy Francis Ford Coppola",
//   "Godfather onDate 29.07.2018",
//   "Fast and Furious onDate 30.07.2018",
//   "Batman onDate 01.08.2018",
//   "Fast and Furious directedBy Rob Cohen",
// ]);

printMovieInfo([
  "addMovie The Avengers",
  "addMovie Superman",
  "The Avengers directedBy Anthony Russo",
  "The Avengers onDate 30.07.2010",
  "Captain America onDate 30.07.2010",
  "Captain America directedBy Joe Russo",
]);
