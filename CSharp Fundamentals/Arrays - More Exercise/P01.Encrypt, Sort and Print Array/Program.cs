namespace P01.Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] encryptedNames = new int[n];

            char[] vowels = { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };

            for (int i = 0; i < n; i++)
            {
                int value = 0;
                string name = Console.ReadLine();

                for (int index = 0; index < name.Length; index++)
                {
                    char ch = name[index];

                    if (vowels.Contains(ch))
                    {
                        value += ch * name.Length;
                    }
                    else
                    {
                        value += ch / name.Length;
                    }
                }

                encryptedNames[i] = value;
            }

            Array.Sort(encryptedNames);

            foreach (var num in encryptedNames)
            {
                Console.WriteLine(num);
            }
        }
    }
}
