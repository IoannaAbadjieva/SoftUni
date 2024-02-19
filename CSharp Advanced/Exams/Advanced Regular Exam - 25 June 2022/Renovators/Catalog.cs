using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        private string name;

        private int neededRenovators;

        private string project;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.name = name;
            this.neededRenovators = neededRenovators;
            this.project = project;
            renovators = new List<Renovator>();
        }

        public List<Renovator> Renovators { get { return renovators; } }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int NeededRenovators
        {
            get { return neededRenovators; }
            private set { neededRenovators = value; }
        }

        public string Project
        {
            get { return project; }
            private set { project = value; }
        }

        public int Count { get { return renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (this.renovators.Count == this.neededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            return renovators.Remove(this.renovators.FirstOrDefault(r => r.Name == name));
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedRenovatorsCount = 0;
            while (this.renovators.Any(r => r.Type == type))
            {
                Renovator renovatorToRemove = this.renovators.FirstOrDefault(r => r.Type == type);
                renovators.Remove(renovatorToRemove);
                removedRenovatorsCount++;
            }

            return removedRenovatorsCount;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovatorToHire = this.renovators.FirstOrDefault(r => r.Name == name);

            if (renovatorToHire != null)
            {
                renovatorToHire.Hired = true;
            }
            return renovatorToHire;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovatorsToBePayd = this.renovators
                                                 .Where(r => r.Days >= days)
                                                 .ToList();

            return renovatorsToBePayd;
        }

        public string Report()
        {
            List<Renovator> filteredRenovators = this.renovators
                                                   .Where(r => r.Hired == false)
                                                   .ToList();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.project}:");
            foreach (Renovator renovator in filteredRenovators)
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
