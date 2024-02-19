using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    public class Manager : IManager
    {
        private Dictionary<string, Task> tasks;

        public Manager()
        {
            this.tasks = new Dictionary<string, Task>();
        }

        public void AddTask(Task task)
        {
            if (this.tasks.ContainsKey(task.Id))
            {
                throw new ArgumentException();
            }

            this.tasks.Add(task.Id, task);
        }

        public void RemoveTask(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var task = this.tasks[taskId];
            this.tasks.Remove(taskId);

            foreach (var item in task.Dependencies)
            {
                item.Dependents.Remove(task);
            }

            foreach (var item in task.Dependents)
            {
                item.Dependencies.Remove(task);
            }
        }

        public bool Contains(string taskId)
        {
            return this.tasks.ContainsKey(taskId);
        }

        public Task Get(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return this.tasks[taskId];
        }

        public int Size()
        {
            return this.tasks.Count;
        }

        public void AddDependency(string taskId, string dependentTaskId)
        {
            if (!this.tasks.ContainsKey(taskId) || !this.tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            var task = this.tasks[taskId];
            var dependency = this.tasks[dependentTaskId];

            if (this.GetDependents(taskId).Contains(dependency) || this.GetDependencies(dependentTaskId).Contains(task))
            {
                throw new ArgumentException();
            }

            task.Dependencies.Add(dependency);
            dependency.Dependents.Add(task);

        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            if (!this.tasks.ContainsKey(taskId) || !this.tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            var task = this.tasks[taskId];
            var dependency = this.tasks[dependentTaskId];

            if (!task.Dependencies.Contains(dependency) || !dependency.Dependents.Contains(task))
            {
                throw new ArgumentException();
            }

            task.Dependencies.Remove(dependency);
            dependency.Dependents.Remove(task);
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                return Enumerable.Empty<Task>();
            }

            var dependencies = new HashSet<Task>();
            var task = this.tasks[taskId];

            this.GetAllDependencies(task, dependencies);

            return dependencies;
        }

        private void GetAllDependencies(Task task, HashSet<Task> dependencies)
        {
            foreach (var dependency in task.Dependencies)
            {
                dependencies.Add(dependency);
                this.GetAllDependencies(dependency, dependencies);
            }
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                return Enumerable.Empty<Task>();
            }

            var dependents = new HashSet<Task>();
            var task = this.tasks[taskId];

            this.GetAllDependents(task, dependents);

            return dependents;
        }

        private void GetAllDependents(Task task, HashSet<Task> dependents)
        {
            foreach (var taskItem in task.Dependents)
            {
                dependents.Add(taskItem);
                this.GetAllDependents(taskItem, dependents);
            }
        }
    }
}