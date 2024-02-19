namespace P06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothesByColor = new Dictionary<string, Dictionary<string, int>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] clothesInfo = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = clothesInfo[0];

                if (!clothesByColor.ContainsKey(color))
                {
                    clothesByColor.Add(color, new Dictionary<string, int>());
                }

                for (int index = 1; index < clothesInfo.Length; index++)
                {
                    string item = clothesInfo[index];

                    if (!clothesByColor[color].ContainsKey(item))
                    {
                        clothesByColor[color].Add(item, 0);
                    }
                    clothesByColor[color][item]++;
                }
            }

            string[] searchedItem = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in clothesByColor)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    if (color.Key == searchedItem[0] && item.Key == searchedItem[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
