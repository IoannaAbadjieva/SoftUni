namespace P10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            int carsPassed = 0;

            string car;
            while ((car = Console.ReadLine()) != "END")
            {
                if (car != "green")
                {
                    queue.Enqueue(car);
                    continue;
                }

                int greenLight = greenLightDuration;
                int freeWindow = freeWindowDuration;

                while (greenLight > 0 && queue.Count > 0)
                {
                    string carToPass = queue.Dequeue();
                    greenLight -= carToPass.Length;

                    if (greenLight >= 0)
                    {
                        carsPassed++;
                    }
                    else
                    {
                        freeWindow += greenLight;
                        if (freeWindow >= 0)
                        {
                            carsPassed++;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{carToPass} was hit at {carToPass[carToPass.Length + freeWindow]}.");
                            return;
                        }
                    }
                }


            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
