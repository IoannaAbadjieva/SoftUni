namespace P05.Longest_Increasing_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int maxLenght = 0;
            int maxLastIndex = 0;

            int[] len = new int[nums.Length];
            int[] prev = new int[nums.Length];

            for (int currNumIndex = 0; currNumIndex < nums.Length; currNumIndex++)
            {
                len[currNumIndex] = 1;
                prev[currNumIndex] = -1;

                for (int prevNumIndex = 0; prevNumIndex < currNumIndex; prevNumIndex++)
                {
                    if (nums[currNumIndex] > nums[prevNumIndex] && len[currNumIndex] < len[prevNumIndex] + 1)
                    {
                        len[currNumIndex] = len[prevNumIndex] + 1;
                        prev[currNumIndex] = prevNumIndex;
                    }
                }
                if (len[currNumIndex] > maxLenght)
                {
                    maxLenght = len[currNumIndex];
                    maxLastIndex = currNumIndex;
                }
            }
          
            int[] LIS = new int[maxLenght];
            int prevIndex = maxLastIndex;

            for (int i = 0; i < LIS.Length; i++)
            {
                LIS[i] = nums[prevIndex];
                prevIndex = prev[prevIndex];
            }

            Array.Reverse(LIS);
            Console.WriteLine(string.Join(" ", LIS));


        }
    }
}
