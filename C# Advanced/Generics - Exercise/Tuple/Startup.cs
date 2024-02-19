using System;
using System.Linq;

namespace Tuple
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string personName = $"{personInfo[0]} {personInfo[1]}";
            string personAdress = string.Join(' ', personInfo.Skip(2).Take(personInfo.Length - 2).ToArray());
            Tuple<string, string> person = new Tuple<string, string>(personName, personAdress);

            string[] drinksInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int> drinks = new Tuple<string, int>(drinksInfo[0], int.Parse(drinksInfo[1]));

            string[] numsInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<int, double> nums = new Tuple<int, double>(int.Parse(numsInfo[0]), double.Parse(numsInfo[1]));

            Console.WriteLine(person);
            Console.WriteLine(drinks);
            Console.WriteLine(nums);

        }
    }
}
