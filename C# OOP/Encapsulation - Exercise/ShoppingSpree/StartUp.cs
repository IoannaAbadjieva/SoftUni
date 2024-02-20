namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] personInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var item in personInfo)
                {
                    string personName = item.Split("=", StringSplitOptions.RemoveEmptyEntries)[0];
                    decimal personMoney = decimal.Parse(item.Split("=", StringSplitOptions.RemoveEmptyEntries)[1]);

                    Person newPerson = new Person(personName, personMoney);
                    persons.Add(personName, newPerson);
                }

                foreach (var item in productInfo)
                {
                    string productName = item.Split("=", StringSplitOptions.RemoveEmptyEntries)[0];
                    decimal productCost = decimal.Parse(item.Split("=", StringSplitOptions.RemoveEmptyEntries)[1]);

                    Product newProduct = new Product(productName, productCost);
                    products.Add(productName, newProduct);
                }

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    Product product = products[productName];
                    Person person = persons[personName];

                    Console.WriteLine(person.AddProduct(product));
                }

                foreach (var person in persons.Values)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception exeption)
            {

                Console.WriteLine(exeption.Message);
            }

        }
    }
}
