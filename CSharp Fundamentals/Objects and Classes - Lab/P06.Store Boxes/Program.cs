namespace P06.Store_Boxes
{
    class Program
    {
        class Item
        {
            public Item()
            {

            }

            public Item(string name, decimal price)
            {
                this.Name = name;
                this.Price = price;
            }

            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        class Box
        {
            public Box()
            {
                this.Item = new Item();
            }

            public Box(int serialNumber, Item item, int itemQuantuty)
            {
                this.SerialNumber = serialNumber;
                this.Item = item;
                this.ItemQuantity = itemQuantuty;
            }

            public int SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public decimal BoxPrice
            {
                get
                {
                    return ItemQuantity * Item.Price;
                }
            }
        }

        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] itemsData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int serialNumber = int.Parse(itemsData[0]);
                string itemName = itemsData[1];
                int itemQuantity = int.Parse(itemsData[2]);
                decimal itemPrice = decimal.Parse(itemsData[3]);

                Item newItem = new Item(itemName, itemPrice);
                Box newBox = new Box(serialNumber, newItem, itemQuantity);
                boxes.Add(newBox);
            }

            PrintOrderedBoxes(boxes);
        }

        static void PrintOrderedBoxes(List<Box> boxes)
        {
            List<Box> ordreredBoxes = boxes.OrderByDescending(x => x.BoxPrice).ToList();

            foreach (var box in ordreredBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }
        }
    }
}
