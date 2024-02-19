using System;
using System.Collections.Generic;
using System.Linq;


namespace Exam.TaskManager
{
    public class TaskManager : ITaskManager
    {
        private Dictionary<string, Task> allTasks;
        private LinkedList<Task> taskQueue;
        private HashSet<Task> executedTasks;

        public TaskManager()
        {
            this.allTasks = new Dictionary<string, Task>();
            this.taskQueue = new LinkedList<Task>();
            this.executedTasks = new HashSet<Task>();
        }

        public void AddTask(Task task)
        {
            this.allTasks.Add(task.Id, task);
            this.taskQueue.AddLast(task);
        }

        public bool Contains(Task task)
        {
            return this.allTasks.ContainsKey(task.Id);
        }

        public void DeleteTask(string taskId)
        {

            if (!this.allTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var task = this.allTasks[taskId];

            this.allTasks.Remove(taskId);

            if (this.executedTasks.Contains(task))
            {
                this.executedTasks.Remove(task);
            }
            else
            {
                this.taskQueue.Remove(task);
            }
        }

        public Task ExecuteTask()
        {
            var task = this.taskQueue.First.Value;

            if (task == null)
            {
                throw new ArgumentException();
            }

            this.taskQueue.RemoveFirst();
            this.executedTasks.Add(task);

            return task;
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
        {
            return this.allTasks.Values
                .OrderByDescending(t => t.EstimatedExecutionTime)
                .ThenBy(t => t.Name.Length);
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            var domeinTasks = this.taskQueue
                .Where(t => t.Domain == domain);

            if (domeinTasks.Count() == 0)
            {
                throw new ArgumentException();
            }

            return domeinTasks;
        }

        public Task GetTask(string taskId)
        {
            if (!this.allTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return this.allTasks[taskId];
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
        {
            return this.taskQueue
                .Where(t => t.EstimatedExecutionTime >= lowerBound && t.EstimatedExecutionTime <= upperBound);
        }

        public void RescheduleTask(string taskId)
        {

            if (!this.allTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }
            var task = this.allTasks[taskId];

            this.executedTasks.Remove(task);
            this.taskQueue.AddLast(task);
        }

        public int Size()
        {
            return this.allTasks.Count();
        }
    }
}
