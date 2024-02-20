namespace AnimalFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;
   
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFoods => 
            new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier => CatWeightMultiplier;

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
