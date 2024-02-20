namespace Telephony.Core
{
    using Contracts;

    using IO.Contracts;

    using Models;
    using Models.Contracts;

    using Exeptions;

    public class Engine : IEngine
    {
        private IStationary stationaryphone;
        private ISmart smartphone;

        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            this.stationaryphone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = this.reader.ReadLine().Split();
            string[] urls = this.reader.ReadLine().Split();

            foreach (string phonenumber in phoneNumbers)
            {

                try
                {
                    if (phonenumber.Length == 7)
                    {
                        this.writer.WriteLine(stationaryphone.Call(phonenumber));
                    }
                    else if (phonenumber.Length == 10)
                    {
                        this.writer.WriteLine(smartphone.Call(phonenumber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberExeption();
                    }
                }
                catch (InvalidPhoneNumberExeption exeption)
                {
                    this.writer.WriteLine(exeption.Message);
                }

            }

            foreach (string url in urls)
            {
                try
                {
                    this.writer.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidURLExeption exeption)
                {
                    this.writer.WriteLine(exeption.Message);
                }
            }
        }
    }
}
