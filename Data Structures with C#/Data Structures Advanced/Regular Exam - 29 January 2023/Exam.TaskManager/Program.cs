using System;
using System.Linq;

namespace Exam.TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var manager = new TaskManager();

            Console.WriteLine(string.Join(Environment.NewLine, manager.GetTasksInEETRange(1,2).Select(t => t.Name)));
        }
    }
}
