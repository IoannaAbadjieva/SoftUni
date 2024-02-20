namespace PizzaCalories
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();

                string[] doughInfo = Console.ReadLine().Split();

                string pizzaName = pizzaInfo[1];
                string flourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                int doughWeight = int.Parse(doughInfo[3]);

                Pizza pizza = new Pizza(pizzaName, new Dough(flourType, bakingTechnique, doughWeight));

                string inputLine;
                while ((inputLine = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = inputLine.Split();

                    string toppingType = toppingInfo[1];
                    int toppingWeight = int.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (Exception exeption)
            {

                Console.WriteLine(exeption.Message);
            }
        }
    }
}
