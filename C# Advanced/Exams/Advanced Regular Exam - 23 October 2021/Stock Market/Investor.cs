using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace StockMarket
{
    public class Investor
    {
        private Dictionary<string, Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            portfolio = new Dictionary<string, Stock>();

            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public Dictionary<string, Stock> Portfolio => portfolio;

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public int Count => portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                portfolio.Add(stock.CompanyName, stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!portfolio.ContainsKey(companyName))
            {
                return $"{companyName} does not exist.";
            }

            Stock stock = portfolio[companyName];

            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            portfolio.Remove(companyName);

            MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            if (!portfolio.ContainsKey(companyName))
            {
                return null;
            }

            return portfolio[companyName];
        }

        public Stock FindBiggestCompany()
        {
            if (!portfolio.Any())
            {
                return null;
            }

            return portfolio.Values.OrderByDescending(s => s.MarketCapitalization).First();
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stock in portfolio)
            {
                sb.AppendLine(stock.Value.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
