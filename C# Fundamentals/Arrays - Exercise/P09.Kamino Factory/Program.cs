namespace P09.Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int DNALenght = int.Parse(Console.ReadLine());
            int[] bestDNA = new int[DNALenght];
            string input;

            int bestSampleSum = -1;
            int bestSampleStartIndex = -1;
            int bestSampleLenght = 0;
            int bestSampleNumber = 0;
            int samplesCounter = 0;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] DNASample = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                samplesCounter++;

                int sequenceLenght = 0;
                int secuenceStartIndex = -1;
                int sampleSum = 0;

                int maxSequenceLenght = 0;
                int maxSequenceStartIndex = -1;


                for (int index = 0; index < DNALenght; index++)
                {

                    if (DNASample[index] == 1)
                    {
                        if (secuenceStartIndex == -1)
                        {
                            secuenceStartIndex = index;
                        }

                        sequenceLenght++;

                        if (sequenceLenght > maxSequenceLenght)
                        {
                            maxSequenceLenght = sequenceLenght;
                            maxSequenceStartIndex = secuenceStartIndex;
                        }
                    }
                    else
                    {
                        sequenceLenght = 0;
                        secuenceStartIndex = -1;
                    }
                }

                sampleSum = DNASample.Sum();


                if (maxSequenceLenght > bestSampleLenght
                    || (maxSequenceLenght == bestSampleLenght && maxSequenceStartIndex < bestSampleStartIndex)
                    || (maxSequenceLenght == bestSampleLenght && maxSequenceStartIndex == bestSampleStartIndex && sampleSum > bestSampleSum))
                {
                    bestSampleSum = sampleSum;
                    bestSampleNumber = samplesCounter;
                    bestSampleLenght = maxSequenceLenght;
                    bestSampleStartIndex = maxSequenceStartIndex;
                    bestDNA = DNASample;

                }
            }
            Console.WriteLine($"Best DNA sample {bestSampleNumber} with sum: {bestSampleSum}.");
            Console.WriteLine(string.Join(' ', bestDNA));
        }
    }
}
