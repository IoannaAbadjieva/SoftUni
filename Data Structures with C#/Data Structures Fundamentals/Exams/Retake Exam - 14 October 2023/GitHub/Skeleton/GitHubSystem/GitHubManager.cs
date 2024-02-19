using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubSystem
{
    public class GitHubManager : IGitHubManager
    {
        private Dictionary<string, User> usersById = new Dictionary<string, User>();
        private Dictionary<string, Repository> repositoryById = new Dictionary<string, Repository>();
        private Dictionary<string, int> repositoriesByForks = new Dictionary<string, int>();
        private Dictionary<string, List<Repository>> userRepositories = new Dictionary<string, List<Repository>>();
        private Dictionary<string, List<Commit>> repositoryCommits = new Dictionary<string, List<Commit>>();

        public void Create(User user)
        {
            this.usersById[user.Id] = user;
            this.userRepositories[user.Id] = new List<Repository>();
        }

        public void Create(Repository repository)
        {
            this.repositoryById[repository.Id] = repository;
            this.userRepositories[repository.OwnerId].Add(repository);
            this.repositoryCommits[repository.Id] = new List<Commit>();
            this.repositoriesByForks[repository.Id] = 0;
        }

        public bool Contains(User user)
        {
            return this.usersById.ContainsKey(user.Id);
        }

        public bool Contains(Repository repository)
        {
            return this.repositoryById.ContainsKey(repository.Id);
        }

        public void CommitChanges(Commit commit)
        {
            if (!this.repositoryById.ContainsKey(commit.RepositoryId))
            {
                throw new ArgumentException();
            }

            if (!this.usersById.ContainsKey(commit.UserId))
            {
                throw new ArgumentException();
            }

            this.repositoryCommits[commit.RepositoryId].Add(commit);
        }

        public Repository ForkRepository(string repositoryId, string userId)
        {
            if (!this.repositoryById.ContainsKey(repositoryId))
            {
                throw new ArgumentException();
            }

            if (!this.usersById.ContainsKey(userId))
            {
                throw new ArgumentException();
            }

            Repository forked = new Repository
            {
                Id = Guid.NewGuid().ToString(),
                Name = this.repositoryById[repositoryId].Name,
                OwnerId = userId
            };

            this.Create(forked);
            foreach (var commit in this.repositoryCommits[repositoryId])
            {
                repositoryCommits[forked.Id].Add(commit);
            }

            this.repositoriesByForks[repositoryId]++;

            return forked;
        }

        public IEnumerable<Commit> GetCommitsForRepository(string repositoryId)
        {
            return this.repositoryCommits[repositoryId];
        }

        public IEnumerable<Repository> GetRepositoriesByOwner(string userId)
        {
            return this.userRepositories[userId];
        }

        public IEnumerable<Repository> GetMostForkedRepositories()
        {
            return this.repositoryById.Values
                 .OrderByDescending(r => repositoriesByForks[r.Id]);
        }

        public IEnumerable<Repository> GetRepositoriesOrderedByCommitsInDescending()
        {
            return this.repositoryById.Values
                .OrderByDescending(r => repositoryCommits[r.Id].Count);
        }
    }
}