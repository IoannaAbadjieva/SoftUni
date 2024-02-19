using System.Text;

namespace P03.Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray();

            StringBuilder sb = new StringBuilder();
            string textToDecrypt;
            while ((textToDecrypt = Console.ReadLine()) != "find")
            {
                int keyIndex = 0;
                foreach (var ch in textToDecrypt)
                {
                    if (keyIndex == key.Length)
                    {
                        keyIndex = 0;
                    }
                    sb.Append((char)(ch - key[keyIndex]));
                    keyIndex++;
                }
                string decryptedMessage = sb.ToString();
                sb.Clear();

                string type = decryptedMessage.Substring(decryptedMessage.IndexOf('&') + 1
                    , decryptedMessage.LastIndexOf('&') - (decryptedMessage.IndexOf('&') + 1));

                string coordinates = decryptedMessage.Substring(decryptedMessage.IndexOf('<') + 1,
                    decryptedMessage.IndexOf('>') - (decryptedMessage.IndexOf('<') + 1));

                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
