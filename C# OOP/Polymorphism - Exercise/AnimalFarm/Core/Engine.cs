namespace AnimalFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;


    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;
        private readonly ICollection<IAnimal> animals;

        private Engine()
        {
            this.animals = new HashSet<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }



        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "End")
            {
                this.ProcessInput(input);
            }

            this.PrintAnimals();
        }

        private void ProcessInput(string input)
        {
            IAnimal animal = null;

            try
            {
                animal = this.CreateNewAnimal(input);
                IFood food = this.CreateNewFood();

                this.writer.WriteLine(animal.ProduceSound());
                animal.Eat(food);
            }
            catch (InvalidAnimalTypeException iate)
            {

                this.writer.WriteLine(iate.Message);
            }
            catch (InvalidFoodTypeException ifte)
            {

                this.writer.WriteLine(ifte.Message);
            }
            catch (FoodNotEatenException fnee)
            {

                this.writer.WriteLine(fnee.Message);
            }
            catch
            {
                throw;
            }

            animals.Add(animal);
        }

        private IAnimal CreateNewAnimal(string input)
        {
            string[] animalInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            IAnimal animal = this.animalFactory.CreateAnimal(animalInfo);

            return animal;
        }

        private IFood CreateNewFood()
        {
            string[] foodInfo = this.reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            IFood food = this.foodFactory.CreateFood(type, quantity);

            return food;
        }

        private void PrintAnimals()
        {
            foreach (IAnimal animal in this.animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }


}
