namespace P04.Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> mixedArrays = new List<int>();

            FillMixedArrList(mixedArrays, firstArr, secondArr);
            int[] range = GetRange(firstArr, secondArr);
            mixedArrays = FilterAndSortMixedList(mixedArrays, range);
            Console.WriteLine(string.Join(" ", mixedArrays));
        }

        static void FillMixedArrList(List<int> mixedArrays, int[] firstArr, int[] secondArr)
        {
            int smallerLenght = Math.Min(firstArr.Length, secondArr.Length);

            for (int index = 0; index < smallerLenght; index++)
            {
                mixedArrays.Add(firstArr[index]);
                mixedArrays.Add(secondArr[secondArr.Length - 1 - index]);
            }
        }

        static int[] GetRange(int[] firstArr, int[] secondArr)
        {
            int n = Math.Abs(firstArr.Length - secondArr.Length);
            int[] range = new int[n];


            if (firstArr.Length > secondArr.Length)
            {
                int rangeIndex = 0;
                for (int index = secondArr.Length; index < firstArr.Length; index++)
                {
                    range[rangeIndex] = firstArr[index];
                    rangeIndex++;
                }
            }
            else
            {
                for (int index = 0; index < n; index++)
                {
                    range[index] = secondArr[index];
                }
            }

            return range;
        }

        static List<int> FilterAndSortMixedList(List<int> mixedArrays, int[] range)
        {
            mixedArrays = mixedArrays.FindAll(x => x > range.Min() && x < range.Max());
            mixedArrays.Sort();

            return mixedArrays;
        }
    }
}
