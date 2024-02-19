namespace P04.reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            string reversed = string.Empty;
            for (int i = sentence.Length - 1; i >= 0; i--)
            {
                reversed += sentence[i];
            }
            Console.WriteLine(reversed);
        }
    }
}
