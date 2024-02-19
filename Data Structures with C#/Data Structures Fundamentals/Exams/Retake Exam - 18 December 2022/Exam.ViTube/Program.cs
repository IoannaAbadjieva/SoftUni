using System;
using System.Linq;

namespace Exam.ViTube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ViTubeRepository viTubeRepository = new ViTubeRepository();

            User user1 = new User("1", "firstUser");
            User user2 = new User("2", "secondUser");
            User user3 = new User("3", "thirdUser");
            User user4 = new User("4", "fourthUser");

            viTubeRepository.RegisterUser(user1);
            viTubeRepository.RegisterUser(user2);
            viTubeRepository.RegisterUser(user3);

            Video video1 = new Video("1", "firstVideo", 1.1, 1, 1, 1);
            Video video2 = new Video("2", "secondVideo", 2.2, 2, 2, 2);
            Video video3 = new Video("3", "thirdVideo", 3.3, 3, 3, 3);
            Video video4 = new Video("4", "fourthVideo", 4.4, 4, 1, 4);
            Video video5 = new Video("5", "fifthVideo", 5.5, 5, 5, 5);

            viTubeRepository.PostVideo(video1);
            viTubeRepository.PostVideo(video2);
            viTubeRepository.PostVideo(video3);
            viTubeRepository.PostVideo(video4);
            viTubeRepository.PostVideo(video5);

            Console.WriteLine(string.Join(", ", viTubeRepository.GetVideos().Select(v => v.Title)));
            Console.WriteLine(string.Join(", ", viTubeRepository.GetPassiveUsers().Select(u => u.Username)));

            viTubeRepository.LikeVideo(user1, video2);
            viTubeRepository.WatchVideo(user1, video1);
            viTubeRepository.WatchVideo(user2, video1);
            viTubeRepository.WatchVideo(user3, video1);
            viTubeRepository.DislikeVideo(user2, video2);
            viTubeRepository.DislikeVideo(user3, video2);

            Console.WriteLine(string.Join(", ", viTubeRepository.GetVideosOrderedByViewsThenByLikesThenByDislikes().Select(v => v.Title)));

        }
    }
}
