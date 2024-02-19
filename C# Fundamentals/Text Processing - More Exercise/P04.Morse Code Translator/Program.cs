using System.Text;

namespace P04.Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] morseAlpfabet = { ".-", "-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",
                ".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};

            string[] inputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var item in inputLine)
            {
                if (morseAlpfabet.Contains(item))
                {
                    sb.Append((char)(GetIndexOfMatchingItem(morseAlpfabet, item) + 65));
                }
                else
                {
                    sb.Append(' ');
                }
            }
            Console.WriteLine(sb.ToString());

        }
        static int GetIndexOfMatchingItem(string[] morseAlphabet, string item)
        {
            int index = -1;

            for (int i = 0; i < morseAlphabet.Length; i++)
            {
                if (morseAlphabet[i] == item)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
