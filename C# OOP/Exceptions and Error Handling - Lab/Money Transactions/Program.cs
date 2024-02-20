using System;
using System.Collections.Generic;

namespace P06.Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accountsBalance = new Dictionary<int, double>();

            string[] accountsInfo = Console.ReadLine().Split(',');

            foreach (var item in accountsInfo)
            {
                int accountNumber = int.Parse(item.Split("-")[0]);
                double balance = double.Parse(item.Split("-")[1]);

                accountsBalance.Add(accountNumber, balance);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    ProcessCommand(accountsBalance, command);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine(ioe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }

        }

        static void ProcessCommand(Dictionary<int, double> accountsBalance, string command)
        {
            string[] cmdArgs = command.Split(' ');

            string cmdType = cmdArgs[0];
            int accountNumber = int.Parse(cmdArgs[1]);
            double sum = double.Parse(cmdArgs[2]);

            if (!accountsBalance.ContainsKey(accountNumber))
            {
                throw new ArgumentException("Invalid account!");
            }

            if (cmdType == "Deposit")
            {
                accountsBalance[accountNumber] += sum;
                Console.WriteLine($"Account {accountNumber} has new balance: {accountsBalance[accountNumber]:f2}");
            }
            else if (cmdType == "Withdraw")
            {
                if (accountsBalance[accountNumber] < sum)
                {
                    throw new InvalidOperationException("Insufficient balance!");
                }
                accountsBalance[accountNumber] -= sum;
                Console.WriteLine($"Account {accountNumber} has new balance: {accountsBalance[accountNumber]:f2}");
            }
            else
            {
                throw new InvalidOperationException("Invalid command!");
            }

        }
    }
}
