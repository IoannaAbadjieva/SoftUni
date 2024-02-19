namespace P03.Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public Song(string typeList, string name, string time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 1; i <= numberOfSongs; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);

                string typeList = input[0];
                string name = input[1];
                string time = input[2];

                Song currentSong = new Song(typeList, name, time);
                songs.Add(currentSong);
            }

            string filter = Console.ReadLine();

            if (filter == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs.FindAll(x => x.TypeList == filter);

                foreach (var song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
