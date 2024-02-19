namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int lineNumber = 0;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (lineNumber++ % 2 == 0)
                    {
                        line = ReplaceSymbols(line);
                        line = ReverseLine(line);
                        sb.AppendLine(line);
                    }
                }
            }
            return sb.ToString();

        }

        public static string ReplaceSymbols(string line)
        {
            char[] charsToReplace = new char[] { '-', ',', '.', '!', '?' };
            foreach (char ch in charsToReplace)
            {
                line = line.Replace(ch, '@');
            }
            return line;
        }

        public static string ReverseLine(string line)
        {
            string[] reversed = line
                .Split(' ')
                .Reverse()
                .ToArray();

            return string.Join(" ", reversed);
        }
    }
}
