namespace P04.Cinema_Voucher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int voucherValue = int.Parse(Console.ReadLine());
            string purchase = Console.ReadLine();
            int purchasesValue = 0;
            int tickets = 0;
            int other = 0;
            bool isTicket;

            while (purchase != "End")
            {
                isTicket = false;
                if (purchase.Length > 8)
                {
                    purchasesValue += purchase[0] + purchase[1];
                    isTicket = true;
                }
                else
                {
                    purchasesValue += purchase[0];
                }

                if (purchasesValue > voucherValue) break;
                else if (isTicket) tickets++;
                else other++;

                purchase = Console.ReadLine();
            }
            Console.WriteLine(tickets);
            Console.WriteLine(other);

        }
    }
}
