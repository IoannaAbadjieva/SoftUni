using System.Text;

namespace P05.Shopping_Spree
{
    class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name { get; set; }

        public int Money { get; set; }

        public List<Product> BagOfProducts { get; set; }

        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                BagOfProducts.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name} - ");

            if (BagOfProducts.Count == 0)
            {
                sb.Append("Nothing bought");
            }
            else
            {

                for (int i = 0; i < BagOfProducts.Count; i++)
                {
                    if (i == BagOfProducts.Count - 1)
                    {
                        sb.Append(BagOfProducts[i].Name);
                    }
                    else
                    {
                        sb.Append($"{BagOfProducts[i].Name}, ");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }

    class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }

        public int Cost { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();


            string[] personsArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < personsArgs.Length; index++)
            {
                string[] currPersonArgs = personsArgs[index]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string personName = currPersonArgs[0];
                int personMoney = int.Parse(currPersonArgs[1]);

                Person newPerson = new Person(personName, personMoney);
                persons.Add(newPerson);
            }

            string[] productsArgs = Console.ReadLine()
               .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < productsArgs.Length; index++)
            {
                string[] currProductArgs = productsArgs[index]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                string productName = currProductArgs[0];
                int productCost = int.Parse(currProductArgs[1]);

                Product newProduct = new Product(productName, productCost);
                products.Add(newProduct);
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = cmdArgs[0];
                string productName = cmdArgs[1];

                Person searchedPerson = persons
                    .FirstOrDefault(x => x.Name == personName);

                if (searchedPerson == null)
                {
                    continue;
                }

                Product searchedProduct = products
                    .FirstOrDefault(x => x.Name == productName);
                if (searchedProduct == null)
                {
                    continue;
                }

                searchedPerson.BuyProduct(searchedProduct);
            }

            persons.ForEach(x => Console.WriteLine(x));
        }
    }
}
