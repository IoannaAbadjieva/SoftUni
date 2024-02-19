
using System;
using System.Linq;

namespace Exam.DeliveriesManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirlinesManager airlinesManager = new AirlinesManager();

            Airline firstOne = new Airline("1", "SofiaAir", 3.5);
            Airline secondOne = new Airline("2", "Lufthansa", 3.5);
            Airline thirdOne = new Airline("3", "RFranceAir", 6.5);
            Airline fourthOne = new Airline("4", "BritishAir", 5.75);

            airlinesManager.AddAirline(firstOne);
            airlinesManager.AddAirline(secondOne);
            airlinesManager.AddAirline(thirdOne);

            Flight first = new Flight("1", "11", "Sofia", "Burgas", false);
            Flight second = new Flight("2", "22", "Sofia", "Burgas", true);
            Flight third = new Flight("3", "33", "Sofia", "Pleven", false);
            Flight fourth = new Flight("4", "44", "Paris", "London", true);
            Flight fifth = new Flight("5", "55", "Sofia", "Burgas", true);
            Flight sixt = new Flight("6", "66", "Sofia", "Burgas", true);


            airlinesManager.AddFlight(firstOne, first);
            airlinesManager.AddFlight(firstOne, second);
            airlinesManager.AddFlight(firstOne, third);
            airlinesManager.AddFlight(secondOne, fourth);
            airlinesManager.AddFlight(thirdOne, fifth);

            Console.WriteLine(string.Join(", ", airlinesManager.GetFlightsOrderedByCompletionThenByNumber().Select(f => f.Number)));
            Console.WriteLine(string.Join(", ", airlinesManager.GetCompletedFlights().Select(f => f.Number)));
            Console.WriteLine(string.Join(", ", airlinesManager.GetAllFlights().Select(f => f.Number)));
            Console.WriteLine(string.Join(", ", airlinesManager.GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName().Select(a => a.Name)));
            Console.WriteLine(string.Join(", ", airlinesManager.GetAirlinesWithFlightsFromOriginToDestination("Sofia", "RBurgas").Select(a => a.Name)));


            //airlinesManager.DeleteAirline(thirdOne);
            Console.WriteLine(airlinesManager.Contains(thirdOne));  
            Console.WriteLine(airlinesManager.Contains(fifth));

            Console.WriteLine(airlinesManager.PerformFlight(secondOne, third).IsCompleted);
            Console.WriteLine(airlinesManager.PerformFlight(secondOne, third).Number);
        }
    }
}
