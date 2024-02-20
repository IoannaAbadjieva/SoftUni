namespace BirthdayCelebrations.Core
{
    using System.Collections.Generic;

    using Contarcts;

    using IO.Contracts;

    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly ICollection<IBirthable> birthables;
        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            birthables = new List<IBirthable>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "End")
            {
                string[] inputLine = input.Split();
                string birthableType = inputLine[0];
                string name = inputLine[1];

                IBirthable birthable = null;

                if (birthableType == "Citizen")
                {
                    int age = int.Parse(inputLine[2]);
                    string id = inputLine[3];
                    string birthdate = inputLine[4];

                    birthable = new Citizen(name,age,id,birthdate);
                }
                else if (birthableType == "Pet")
                {
                    string birthdate = inputLine[2];

                    birthable = new Pet(name, birthdate);
                }
                else
                {
                    continue;
                }

               birthables.Add(birthable);
            }

            string birthYear = this.reader.ReadLine();

            foreach (var birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(birthYear))
                {
                    this.writer.WriteLine(birthable.Birthdate);
                }
            }

        }
    }
}
