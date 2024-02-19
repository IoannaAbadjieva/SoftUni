
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private Dictionary<string, User> usersById;
        private Dictionary<string, Video> videosById;

        public ViTubeRepository()
        {
            this.usersById = new Dictionary<string, User>();
            this.videosById = new Dictionary<string, Video>();
        }

        public bool Contains(User user)
        {
            return usersById.ContainsKey(user.Id);
        }

        public bool Contains(Video video)
        {
            return videosById.ContainsKey(video.Id);
        }

        public void DislikeVideo(User user, Video video)
        {
            if (!usersById.ContainsKey(user.Id) || !videosById.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            usersById[user.Id].LikedOrDislikedVideos.Add(videosById[video.Id]);
            videosById[video.Id].Dislikes++;
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            return usersById.Values
                .Where(u => u.WatchedVideos.Count == 0 && u.LikedOrDislikedVideos.Count == 0 && u.LikedOrDislikedVideos.Count == 0);
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            return usersById.Values
                .OrderByDescending(u => u.WatchedVideos.Count)
                .ThenByDescending(u => u.LikedOrDislikedVideos.Count)
                .ThenBy(u => u.Username);
        }

        public IEnumerable<Video> GetVideos()
        {
            return videosById.Values;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            return videosById.Values
                 .OrderByDescending(v => v.Views)
                 .ThenByDescending(v => v.Likes)
                 .ThenBy(v => v.Dislikes);
        }

        public void LikeVideo(User user, Video video)
        {

            if (!usersById.ContainsKey(user.Id) || !videosById.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            usersById[user.Id].LikedOrDislikedVideos.Add(videosById[video.Id]);
            videosById[video.Id].Likes++;
        }

        public void PostVideo(Video video)
        {
            videosById[video.Id] = video;
        }

        public void RegisterUser(User user)
        {
            usersById[user.Id] = user;
        }

        public void WatchVideo(User user, Video video)
        {
            if (!usersById.ContainsKey(user.Id) || !videosById.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }


            usersById[user.Id].WatchedVideos.Add(videosById[video.Id]);
            videosById[video.Id].Views++;
        }
    }
}
