function solve(input) {
  class Song {
    constructor(typeList, name, time) {
      this.typeList = typeList;
      this.name = name;
      this.time = time;
    }
  }

  const typeToDisplay = input.pop();
  const [_, ...songs] = input;

  const result = songs
    .map((element) => {
      const [typeList, name, time] = element.split("_");
      const song = new Song(typeList, name, time);
      return song;
    })
    .filter((song) => {
      if (typeToDisplay === "all") {
        return song;
      }
      return song.typeList === typeToDisplay;
    });

  result.forEach((song) => console.log(song.name));
}

// solve([
//   4,
//   "favourite_DownTown_3:14",
//   "listenLater_Andalouse_3:24",
//   "favourite_In To The Night_3:58",
//   "favourite_Live It Up_3:48",
//   "listenLater",
// ]);

// solve([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);

solve([
  3,
  "favourite_DownTown_3:14",
  "favourite_Kiss_4:16",
  "favourite_Smooth Criminal_4:01",
  "favourite",
]);
