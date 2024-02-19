using System.Text;

namespace P04.Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textToBeEncrypted = Console.ReadLine();
            StringBuilder encryptedText = new StringBuilder();

            foreach (char ch in textToBeEncrypted)
            {
                encryptedText.Append((char)(ch + 3));
            }
            Console.WriteLine(encryptedText.ToString());
        }
    }
}
