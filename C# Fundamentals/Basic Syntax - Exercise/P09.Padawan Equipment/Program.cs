namespace P09.Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double saberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double totalSabers = Math.Ceiling(studentsCount * 1.1) * saberPrice;
            double totalRobes = studentsCount * robePrice;
            double totalBelts = (studentsCount - studentsCount / 6) * beltPrice;

            double moneyNeeded = totalSabers + totalRobes + totalBelts;

            if (money >= moneyNeeded)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {moneyNeeded - money:f2}lv more.");
            }
        }
    }
}
