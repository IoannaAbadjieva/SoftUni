using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            data = new List<Pet>();
            Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(data.FirstOrDefault(p => p.Name == name));
        }

        public Pet GetPet(string name, string owner)
        {
            return data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            if (data.Count == 0)
            {
                return default;
            }
            return data.OrderByDescending(p => p.Age).First();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (Pet pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().Trim();
        }
    }
}
