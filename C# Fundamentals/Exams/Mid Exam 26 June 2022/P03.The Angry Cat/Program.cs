using System;
using System.Linq;
using System.Numerics;

namespace P03.The_Angry_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pricesRating = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int entryPoint = int.Parse(Console.ReadLine());
            string itemsType = Console.ReadLine();

            BigInteger leftSum = GetLeftSum(pricesRating, entryPoint, itemsType);
            BigInteger rightSum = GetRightSum(pricesRating, entryPoint, itemsType);

            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }
        }

        static BigInteger GetLeftSum(int[] priceRating, int entryPoint, string itemsType)
        {
            BigInteger leftSum = 0;
            int compareRating = priceRating[entryPoint];

            if (itemsType == "cheap")
            {
                for (int index = 0; index < entryPoint; index++)
                {
                    int currentPriceRating = priceRating[index];

                    if (currentPriceRating < compareRating)
                    {
                        leftSum += currentPriceRating;
                    }
                }
            }
            else if (itemsType == "expensive")
            {
                for (int index = 0; index < entryPoint; index++)
                {
                    int currentPriceRating = priceRating[index];

                    if (currentPriceRating >= compareRating)
                    {
                        leftSum += currentPriceRating;
                    }
                }
            }
            return leftSum;
        }


        static BigInteger GetRightSum(int[] priceRating, int entryPoint, string itemsType)
        {
            BigInteger rightSum = 0;
            int CompareRating = priceRating[entryPoint];

            if (itemsType == "cheap")
            {
                for (int index = entryPoint + 1; index < priceRating.Length; index++)
                {
                    int currentPriceRating = priceRating[index];

                    if (currentPriceRating < CompareRating)
                    {
                        rightSum += currentPriceRating;
                    }
                }
            }
            else if (itemsType == "expensive")
            {
                for (int index = entryPoint + 1; index < priceRating.Length; index++)
                {
                    int currentPriceRating = priceRating[index];

                    if (currentPriceRating >= CompareRating)
                    {
                        rightSum += currentPriceRating;
                    }
                }
            }
            return rightSum;
        }
    }
}
