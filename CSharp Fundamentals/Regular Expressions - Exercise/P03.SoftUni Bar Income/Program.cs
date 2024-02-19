using System.Text.RegularExpressions;

namespace P03.SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%(?<name>[A-Z]{1}[a-z]+)\%[^.%$|]*?\<(?<item>\w+)\>[^.|$%]*?\|(?<qty>\d+)\|[^.|$%]*?(?<price>\d+(\.\d+)?)\$";

            double income = 0;
            string input;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string item = match.Groups["item"].Value;
                    int qty = int.Parse(match.Groups["qty"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    income += qty * price;

                    Console.WriteLine($"{name}: {item} - {qty * price:f2}");
                }
            }
            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
