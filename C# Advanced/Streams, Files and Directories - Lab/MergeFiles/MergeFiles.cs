namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstReader = new StreamReader(firstInputFilePath))
            {
                using (StreamReader secondReader = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        while (!firstReader.EndOfStream && !secondReader.EndOfStream)
                        {
                            string lineFromFirstInput = firstReader.ReadLine();
                            string lineFromSecondInput = secondReader.ReadLine();
                            writer.WriteLine(lineFromFirstInput);
                            writer.WriteLine(lineFromSecondInput);
                        }

                        if (!firstReader.EndOfStream)
                        {
                            while (!firstReader.EndOfStream)
                            {
                                string lineFromFirstInput = firstReader.ReadLine();
                                writer.WriteLine(lineFromFirstInput);
                            }
                        }
                        else 
                        {
                            while (!secondReader.EndOfStream)
                            {
                                string lineFromSecondInput = secondReader.ReadLine();
                                writer.WriteLine(lineFromSecondInput);
                            }
                        }
                    }
                }
            }
        }
    }
}
