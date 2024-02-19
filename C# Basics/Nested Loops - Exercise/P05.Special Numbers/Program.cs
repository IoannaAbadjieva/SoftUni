namespace P05.Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                bool isSpecial = true;
                string currNum = i.ToString();

                for (int j = 0; j < 4; j++)
                {
                    int currDigit = int.Parse(currNum[j].ToString());
                    if (currDigit == 0 || num % currDigit != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                }
                if (isSpecial)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
