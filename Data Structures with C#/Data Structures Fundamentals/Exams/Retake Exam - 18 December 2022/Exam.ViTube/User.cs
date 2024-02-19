using System.Collections.Generic;

namespace Exam.ViTube
{
    public class User
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public User(string id, string username)
        {
            Id = id;
            Username = username;
            WatchedVideos = new HashSet<Video>();
            LikedOrDislikedVideos = new HashSet<Video>();

        }

        public ICollection<Video> WatchedVideos { get; set; }
        public ICollection<Video> LikedOrDislikedVideos { get; set; }

    }
}
