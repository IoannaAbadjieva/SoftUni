namespace P03.Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            string fileFullName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            string fileName = fileFullName.Substring(0, fileFullName.LastIndexOf('.'));
            string fileExtension = fileFullName.Substring(fileFullName.LastIndexOf('.') + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
