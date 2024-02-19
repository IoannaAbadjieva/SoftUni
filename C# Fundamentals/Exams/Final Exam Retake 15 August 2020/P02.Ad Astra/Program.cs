using System.Text.RegularExpressions;

namespace P02.Ad_Astra
{
    class Food
    {
        public Food(string name, string expDate, int calories)
        {
            Name = name;
            ExpDate = expDate;
            Calories = calories;
        }

        public string Name { get; set; }

        public string ExpDate { get; set; }

        public int Calories { get; set; }

        public override string ToString()
        {
            return $"Item: {Name}, Best before: {ExpDate}, Nutrition: {Calories}";
        }
    }

    internal class Program
    {
        const int CaloriesNededADay = 2000;

        static void Main(string[] args)
        {
            List<Food> foodList = new List<Food>();

            string pattern = @"([#|\|])(?<item>[A-za-z]+\s?[A-Za-z]+?)\1(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>[0-9]+)\1";

            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);

            foreach (Match food in matches)
            {
                string name = food.Groups["item"].Value;
                string expDate = food.Groups["date"].Value;
                int calories = int.Parse(food.Groups["calories"].Value);

                Food newFood = new Food(name, expDate, calories);
                foodList.Add(newFood);
            }
            PrintNutritions(foodList);
        }

        static void PrintNutritions(List<Food> foodList)
        {
            int calories = foodList.Sum(x => x.Calories);
            Console.WriteLine($"You have food to last you for: {calories / CaloriesNededADay} days!");
            foodList.ForEach(x => Console.WriteLine(x));
        }
    }
}
