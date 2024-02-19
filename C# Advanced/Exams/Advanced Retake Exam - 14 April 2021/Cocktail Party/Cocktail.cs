using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CocktailParty
{
    public class Cocktail
    {
        private Dictionary<string,Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            ingredients = new Dictionary<string,Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public Dictionary<string,Ingredient> Ingredients => ingredients;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => ingredients.Values.Sum(v => v.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.ContainsKey(ingredient.Name) && Ingredients.Count < Capacity
                && (CurrentAlcoholLevel + ingredient.Alcohol) <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient.Name, ingredient);
            }
        }

        public bool Remove(string name)
        {
            return Ingredients.Remove(name);
        }

        public Ingredient FindIngredient(string name)
        {
            if (!Ingredients.ContainsKey(name))
            {
                return null;
            }

            return Ingredients[name];
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            if (!Ingredients.Any())
            {
                return null;
            }

            return Ingredients.Values.OrderByDescending(i => i.Alcohol).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients.Values)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
