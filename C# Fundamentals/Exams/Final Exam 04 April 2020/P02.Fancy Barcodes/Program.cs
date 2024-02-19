using System.Text.RegularExpressions;

namespace P02.Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string barcodePattern = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";
            string groupPattern = @"\d";

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Match barcodeMatch = Regex.Match(barcode, barcodePattern);
                if (!barcodeMatch.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                MatchCollection groupMatches = Regex.Matches(barcodeMatch.Value, groupPattern);
                if (groupMatches.Count == 0)
                {
                    Console.WriteLine("Product group: 00");
                    continue;
                }

                Console.WriteLine($"Product group: {string.Join("", groupMatches)}");
            }
        }
    }
}
