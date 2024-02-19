namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {

            SortedDictionary<string, List<FileInfo>> extensions = new SortedDictionary<string, List<FileInfo>>();

            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!extensions.ContainsKey(fileInfo.Extension))
                {
                    extensions.Add(fileInfo.Extension, new List<FileInfo>());
                }
                extensions[fileInfo.Extension].Add(fileInfo);
            }

            Dictionary<string, List<FileInfo>> orderedExtensions = extensions
                .OrderByDescending(x => x.Value.Count())
                .ToDictionary(x => x.Key, x => x.Value);

            StringBuilder sb = new StringBuilder();

            foreach (var extension in orderedExtensions)
            {
                sb.AppendLine(extension.Key);

                List<FileInfo> orderedFiles = extension.Value
                    .OrderByDescending(x => x.Length)
                    .ToList();

                foreach (var file in orderedFiles)
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }
            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName, textContent);
        }
    }
}
