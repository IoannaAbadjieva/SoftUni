using System.Text;

namespace P08.Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    MergeListElements(inputLine, startIndex, endIndex);
                }
                else if (cmdType == "divide")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int partitionsCount = int.Parse(cmdArgs[2]);
                    DivideListElement(inputLine, index, partitionsCount);
                }
            }
            Console.WriteLine(string.Join(" ", inputLine));
        }

        static void MergeListElements(List<string> input, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex >= input.Count)
            {
                endIndex = input.Count - 1;
            }

            StringBuilder sb = new StringBuilder();
            for (int cnt = startIndex; cnt <= endIndex; cnt++)
            {
                sb.Append(input[startIndex]);
                input.RemoveAt(startIndex);
            }

            if (sb.Length > 0)
            {
                input.Insert(startIndex, sb.ToString());
            }

        }

        static void DivideListElement(List<string> input, int index, int partitionsCount)
        {
            string listElement = input[index];
            int partitionLenght = listElement.Length / partitionsCount;
            int lastPartitionLenght = partitionLenght + listElement.Length % partitionsCount;
            List<string> partitions = new List<string>();

            for (int i = 0; i < partitionsCount; i++)
            {
                char[] currPartition;

                if (i == partitionsCount - 1)
                {
                    currPartition = listElement
                                       .Skip(i * partitionLenght)
                                       .Take(lastPartitionLenght)
                                       .ToArray();
                }
                else
                {
                    currPartition = listElement
                                      .Skip(i * partitionLenght)
                                      .Take(partitionLenght)
                                      .ToArray();
                }
                partitions.Add(new string(currPartition));
            }
            input.RemoveAt(index);
            input.InsertRange(index, partitions);
        }
    }
}
