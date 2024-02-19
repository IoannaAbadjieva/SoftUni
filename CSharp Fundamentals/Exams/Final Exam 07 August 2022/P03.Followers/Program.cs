using System;
using System.Collections.Generic;

namespace P03.Followers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> followers = new Dictionary<string, int[]>();

            string command;
            while ((command = Console.ReadLine()) != "Log out")
            {
                string[] cmdArgs = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string username = cmdArgs[1];

                if (cmdType == "New follower")
                {
                    if (followers.ContainsKey(username))
                    {
                        continue;
                    }
                    followers[username] = new int[2];
                }
                else if (cmdType == "Like")
                {
                    int count = int.Parse(cmdArgs[2]);

                    if (!followers.ContainsKey(username))
                    {
                        followers[username] = new int[2];
                    }
                    followers[username][0] += count;

                }
                else if (cmdType == "Comment")
                {
                    if (!followers.ContainsKey(username))
                    {
                        followers[username] = new int[2];
                    }
                    followers[username][1]++;
                }
                else if (cmdType == "Blocked")
                {
                    if (!followers.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                        continue;
                    }
                    followers.Remove(username);
                }
            }
            PrintFollowersInfo(followers);
        }

        static void PrintFollowersInfo(Dictionary<string, int[]> followers)
        {
            Console.WriteLine($"{followers.Count} followers");

            foreach (var username in followers)
            {
                int sumOfLikesAndComments = username.Value[0] + username.Value[1];
                Console.WriteLine($"{username.Key}: {sumOfLikesAndComments}");
            }
        }
    }
}
