namespace P07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int vCardCount = int.Parse(Console.ReadLine());
            int processorCount = int.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());

            //•	Видеокарта – 250 лв./бр.
            //•	Процесор – 35 % от цената на закупените видеокарти/ бр.
            //•	Рам памет – 10 % от цената на закупените видеокарти/ бр.

            int vCardPrice = vCardCount * 250;
            double totalPrice = vCardPrice + processorCount * vCardPrice * 0.35 + ramCount * vCardPrice * 0.1;

            //Ако броя на видеокартите е по-голям от този на процесорите получава 15% отстъпка от крайната сметка
            if (vCardCount > processorCount)
            {
                totalPrice -= totalPrice * 0.15;
            }

            double difference = budget - totalPrice;

            if (difference >= 0)
            {
                Console.WriteLine($"You have {difference:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(difference):f2} leva more!");
            }
        }
    }
}
