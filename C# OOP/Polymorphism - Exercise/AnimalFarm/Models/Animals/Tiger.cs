﻿namespace AnimalFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Foods;

    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFoods =>
            new HashSet<Type>() { typeof(Meat) };


        protected override double WeightMultiplier => TigerWeightMultiplier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
