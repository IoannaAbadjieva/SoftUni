namespace Exam.RePlay
{
    public class Track
    {
        public Track(string id, string title, string artist, int plays, int durationInSeconds)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Plays = plays;
            DurationInSeconds = durationInSeconds;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public int Plays { get; set; }

        public int DurationInSeconds { get; set; }

        public string Album { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Track;

            return Id.Equals(other.Id);
        }
    }
}
