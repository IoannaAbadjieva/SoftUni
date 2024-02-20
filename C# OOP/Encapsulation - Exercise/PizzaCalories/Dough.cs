namespace PizzaCalories
{
    using System;

    public class Dough
    {
        private const int MinDoughWeight = 1;
        private const int MaxDoughWeight = 200;
        private const int BaseCalories = 2;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }

            private set
            {
                if (!Helper.Modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExeptionMessages.InvalidDoughType);
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }

            private set
            {
                if (!Helper.Modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExeptionMessages.InvalidDoughType);
                }

                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get { return this.weight; }

            private set
            {
                if (value < MinDoughWeight || value > MaxDoughWeight)
                {
                    throw new ArgumentException(ExeptionMessages.InvalidDoughWeight);
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                return

                     this.Weight
                    * BaseCalories
                    * Helper.Modifiers[this.FlourType.ToLower()]
                    * Helper.Modifiers[this.BakingTechnique.ToLower()];

            }
        }
    }
}
