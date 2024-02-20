namespace FoodShortage.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Contarcts;

    using IO.Contracts;

    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IDictionary<string, IBuyer> buyers;
        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            buyers = new Dictionary<string, IBuyer>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int count = int.Parse(this.reader.ReadLine());
            IBuyer buyer = null;

            for (int i = 0; i < count; i++)
            {
                string[] input = this.reader.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthdate = input[3];

                    buyer = new Citizen(name, age, id, birthdate);
                }
                else if (input.Length == 3)
                {
                    string group = input[2];

                    buyer = new Rebel(name, age, group);
                }

                if (buyer != null)
                {
                    buyers.Add(name, buyer);
                }
            }

            string buyerName;
            while ((buyerName = this.reader.ReadLine()) != "End")
            {
                if (!buyers.ContainsKey(buyerName))
                {
                    continue;
                }

                buyers[buyerName].BuyFood();
            }

            if (buyers.Count > 0)
            {
                this.writer.WriteLine(buyers.Values.Sum(b => b.Food).ToString());
            }
        }
    }
}
