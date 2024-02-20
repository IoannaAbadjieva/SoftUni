namespace ChristmasPastryShop.Models.Booths
{
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using System;
    using System.Text;

    public class Booth : IBooth
    {
        private int capacity;
        private readonly IRepository<IDelicacy> delicacyMenu;
        private readonly IRepository<ICocktail> cocktailMenu;

        private Booth()
        {
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
        }

        public Booth(int boothId, int capacity)
            : this()
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get => this.capacity;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }

                this.capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => this.cocktailMenu;

        public double CurrentBill { get; private set; } = 0;

        public double Turnover { get; private set; } = 0;

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
            this.IsReserved = !this.IsReserved;
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Booth: {this.BoothId}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Turnover: {this.Turnover:f2} lv")
                .AppendLine("-Cocktail menu:");

            foreach (var cocktail in this.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }

            sb.AppendLine("-Delicacy menu:");

            foreach (var delicacy in this.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{ delicacy.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
