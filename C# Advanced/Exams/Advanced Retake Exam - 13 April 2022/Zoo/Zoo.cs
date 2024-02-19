using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; private set; }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int removedAnimalsCount = 0;

            while (Animals.Any(a => a.Species == species))
            {
                Animal animalToRemove = Animals.FirstOrDefault(a => a.Species == species);
                Animals.Remove(animalToRemove);
                removedAnimalsCount++;
            }

            return removedAnimalsCount;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsByDiet = Animals
                                            .Where(a => a.Diet == diet)
                                            .ToList();

            return animalsByDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.First(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals
                .Where(a => a.Length >= minimumLength && a.Length <= maximumLength)
                .Count();

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
