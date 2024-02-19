using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            multiprocessor = new List<CPU>();
            Model = model;
            Capacity = capacity;
        }

        public string Model { get; set; }

        public int Capacity { get; set; }

        public List<CPU> Multiprocessor => multiprocessor;

        public int Count => multiprocessor.Count;

        public void  Add(CPU cpu)
        {
            if (multiprocessor.Count < Capacity)
            {
                multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU cpu = multiprocessor.FirstOrDefault(p => p.Brand == brand);
            return multiprocessor.Remove(cpu);
        }

        public CPU MostPowerful()
        {
            if (multiprocessor.Count == 0)
            {
                return default;
            }

            return multiprocessor.OrderByDescending(p => p.Frequency).First();
        }

        public CPU GetCPU(string brand)
        {
            return multiprocessor.FirstOrDefault(p => p.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (CPU cpu in multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
