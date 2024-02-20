namespace BorderControl.Core
{
    using System.Collections.Generic;

    using Contarcts;

    using IO.Contracts;

    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly ICollection<IIdentifiable> identifiables;
        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            identifiables = new List<IIdentifiable>();
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

                IIdentifiable identifiable = null;

                if (inputLine.Length == 2)
                {
                    string model = inputLine[0];
                    string id = inputLine[1];

                    identifiable = new Robot(model, id);
                }
                else if (inputLine.Length == 3)
                {
                    string name = inputLine[0];
                    int age = int.Parse(inputLine[1]);
                    string id = inputLine[2];

                    identifiable = new Citizen(name, age, id);
                }

                identifiables.Add(identifiable);
            }

            string fakeIdLastDigits = this.reader.ReadLine();

            foreach (var identifiable in identifiables)
            {
                if (identifiable.Id.EndsWith(fakeIdLastDigits))
                {
                    this.writer.WriteLine(identifiable.Id);
                }
            }

        }
    }
}
