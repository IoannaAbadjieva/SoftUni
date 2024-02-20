namespace AnimalFarm.Factories
{
    using Exceptions;
    using Factories.Contracts;
    using Models.Animals;
    using Models.Contracts;
   
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] arguments)
        {
            string type = arguments[0];
            string name = arguments[1];
            double weight = double.Parse(arguments[2]);
            string fourthArg = arguments[3];

            IAnimal animal;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(fourthArg));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(fourthArg));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, fourthArg);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, fourthArg);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, fourthArg, arguments[4]);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, fourthArg, arguments[4]);
            }
            else
            {
                throw new InvalidAnimalTypeException();
            }

            return animal;
        }
    }
}
