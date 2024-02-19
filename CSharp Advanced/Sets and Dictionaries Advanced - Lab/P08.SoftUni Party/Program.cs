namespace P08.SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> guestsVIP = new HashSet<string>();

            string reservation;
            while ((reservation = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(reservation[0]))
                {
                    guestsVIP.Add(reservation);
                }
                else
                {
                    guests.Add(reservation);
                }
            }

            while ((reservation = Console.ReadLine()) != "END")
            {
                if (guestsVIP.Contains(reservation))
                {
                    guestsVIP.Remove(reservation);
                }
                else
                {
                    guests.Remove(reservation);
                }
            }
            Console.WriteLine(guestsVIP.Count + guests.Count);

            if (guestsVIP.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, guestsVIP));
            }
            Console.WriteLine(string.Join(Environment.NewLine, guests));

        }
    }
}
