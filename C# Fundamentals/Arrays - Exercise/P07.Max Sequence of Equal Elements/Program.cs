namespace P07.Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

            int sequenceLenght = 1;
            int maxSequenceLenght = 1;
            int sequenceEndIndex = -1;
            int maxSequenceEndIndex = -1;

            for (int index = 0; index < numbers.Length - 1; index++)
            {
                if (numbers[index] == numbers[index + 1])
                {
                    sequenceLenght++;
                    sequenceEndIndex = index + 1;
                }
                else
                {
                    sequenceLenght = 1;
                    sequenceEndIndex = -1;
                }

                if (sequenceLenght > maxSequenceLenght)
                {
                    maxSequenceLenght = sequenceLenght;
                    maxSequenceEndIndex = sequenceEndIndex;
                }
            }

            if (maxSequenceEndIndex != -1)
            {
                for (int count = 0; count < maxSequenceLenght; count++)
                {
                    Console.Write($"{numbers[maxSequenceEndIndex]} ");
                    maxSequenceEndIndex--;
                }
            }
        }
    }
}
