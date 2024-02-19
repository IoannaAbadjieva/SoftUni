using System.Text;

namespace P03.Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> inputLine = Console.ReadLine().ToCharArray().ToList();
            List<int> numbers = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            RemoveDigits(inputLine, numbers);
            DivideNumbersList(numbers, takeList, skipList);
            Console.WriteLine(DecryptMessage(inputLine, takeList, skipList));

        }

        static void RemoveDigits(List<char> inputLine, List<int> numbers)
        {
            for (int index = 0; index < inputLine.Count; index++)
            {
                char currCh = inputLine[index];

                if (char.IsDigit(currCh))
                {
                    numbers.Add(currCh - 48);
                    inputLine.RemoveAt(index);
                    index--;
                }
            }
        }

        static void DivideNumbersList(List<int> numbers, List<int> takeList, List<int> skipList)
        {
            for (int index = 0; index < numbers.Count; index++)
            {
                int currNumber = numbers[index];

                if (index % 2 != 0)
                {
                    skipList.Add(currNumber);
                }
                else
                {
                    takeList.Add(currNumber);
                }
            }
        }
        static string DecryptMessage(List<char> inputLine, List<int> takeList, List<int> skipList)
        {
            string input = new string(inputLine.ToArray());
            StringBuilder result = new StringBuilder();
            char[] currSequense;
            int skipped = 0;

            for (int index = 0; index < skipList.Count; index++)
            {
                currSequense = input
                    .Skip(skipped)
                    .Take(takeList[index])
                    .ToArray();

                result.Append(new string(currSequense));
                skipped += takeList[index];
                skipped += skipList[index];
            }

            return result.ToString();
        }
    }
}
