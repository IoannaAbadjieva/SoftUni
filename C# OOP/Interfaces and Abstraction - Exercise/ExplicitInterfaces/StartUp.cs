namespace ExplicitInterfaces
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] sitizenInfo = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string name = sitizenInfo[0];
                string country = sitizenInfo[1];
                int age = int.Parse(sitizenInfo[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }


        }
    }
}
