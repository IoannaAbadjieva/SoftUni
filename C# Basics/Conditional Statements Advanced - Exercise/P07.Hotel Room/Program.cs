namespace P07.Hotel_Room
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int overnightStays = int.Parse(Console.ReadLine());

            double studioPrice = 0.0;
            double apartmentPrice = 0.0;


            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    apartmentPrice = 65;

                    if (overnightStays > 14)
                    {
                        studioPrice -= studioPrice * 0.30;
                    }
                    else if (overnightStays > 7)
                    {
                        studioPrice -= studioPrice * 0.05;
                    }
                    break;

                case "June":
                case "September":
                    studioPrice = 75.20;
                    apartmentPrice = 68.70;

                    if (overnightStays > 14)
                    {
                        studioPrice -= studioPrice * 0.20;
                    }
                    break;

                case "July":
                case "August":
                    studioPrice = 76;
                    apartmentPrice = 77;
                    break;

            }
            if (overnightStays > 14)
            {
                apartmentPrice -= apartmentPrice * 0.10;
            }

            double studioTotalPrice = studioPrice * overnightStays;
            double apartmentTotalPrice = apartmentPrice * overnightStays;

            Console.WriteLine($"Apartment: {apartmentTotalPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioTotalPrice:f2} lv.");

        }
    }
}
