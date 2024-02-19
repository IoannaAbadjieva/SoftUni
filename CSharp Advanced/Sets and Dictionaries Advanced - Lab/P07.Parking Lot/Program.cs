namespace P07.Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string carNumber = cmdArgs[1];

                if (cmdType == "IN")
                {
                    set.Add(carNumber);
                }
                else
                {
                    set.Remove(carNumber);
                }
            }

            if (set.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, set));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
