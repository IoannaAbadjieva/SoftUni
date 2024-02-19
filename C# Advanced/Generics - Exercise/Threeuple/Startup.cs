using System;
using System.Linq;

namespace Threeuple
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string personName = $"{personInfo[0]} {personInfo[1]}";
            string personAdress = $"{personInfo[2]}";
            string personTown = string.Join(' ', personInfo.Skip(3).Take(personInfo.Length - 2).ToArray());
            Tuple<string, string,string> person = new Tuple<string, string,string>(personName, personAdress,personTown);

            string[] drinksInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int,bool> drinks = new Tuple<string, int,bool>(drinksInfo[0], int.Parse(drinksInfo[1]), drinksInfo[2] == "drunk");

            string[] accountInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, double,string> accountBallance = new Tuple<string, double, string>(accountInfo[0], double.Parse(accountInfo[1]), accountInfo[2]);

            Console.WriteLine(person);
            Console.WriteLine(drinks);
            Console.WriteLine(accountBallance);

        }
    }
}
