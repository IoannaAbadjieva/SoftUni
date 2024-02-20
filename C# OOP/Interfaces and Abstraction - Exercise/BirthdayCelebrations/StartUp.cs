namespace BirthdayCelebrations
{
    using IO;
    using IO.Contracts;
 
    using Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
