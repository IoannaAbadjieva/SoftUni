namespace ChristmasPastryShop.Core
{
    using ChristmasPastryShop.Core.Contracts;
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using ChristmasPastryShop.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IBooth> booths;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = this.booths.Models.Count + 1;

            IBooth booth = new Booth(boothId, capacity);

            this.booths.AddModel(booth);

            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            IBooth booth = this.booths.Models.First(b => b.BoothId == boothId);

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {


            if (cocktailTypeName != nameof(MulledWine) && cocktailTypeName != nameof(Hibernation))
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            if (!Helper.cocktailPriceMultyplier.ContainsKey(size))
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            IBooth booth = this.booths.Models.First(b => b.BoothId == boothId);
            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            ICocktail cocktail = null;

            if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);
            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";

        }

        public string ReserveBooth(int countOfPeople)
        {
            var boothToReserve = this.booths.Models
                .Where(b => !b.IsReserved && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (boothToReserve == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }

            boothToReserve.ChangeStatus();

            return $"Booth {boothToReserve.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = this.booths.Models.First(b => b.BoothId == boothId);

            string[] orderArgs = order.Split('/');
            string itemTypeName = orderArgs[0];
            string itemName = orderArgs[1];
            int orderedPiecesCount = int.Parse(orderArgs[2]);



            if (!(itemTypeName == nameof(Gingerbread)) && !(itemTypeName == nameof(Stolen))
                && !(itemTypeName == nameof(MulledWine)) && !(itemTypeName == nameof(Hibernation)))
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if ((!booth.DelicacyMenu.Models.Any(d => d.GetType().Name == itemTypeName && d.Name == itemName))
                && (!booth.CocktailMenu.Models.Any(c => c.GetType().Name == itemTypeName && c.Name == itemName)))
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }

            if (itemTypeName == nameof(Gingerbread) || itemTypeName == nameof(Stolen))
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models
                    .FirstOrDefault(d => d.GetType().Name == itemTypeName && d.Name == itemName);

                if (delicacy == null)
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }

                booth.UpdateCurrentBill(orderedPiecesCount * delicacy.Price);
            }
            else
            {
                string size = orderArgs[3];

                ICocktail cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(c => c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == size);

                if (cocktail == null)
                {
                    return $"There is no {size} {itemName} available!";
                }

                booth.UpdateCurrentBill(orderedPiecesCount * cocktail.Price);
            }

            return $"Booth {boothId} ordered {orderedPiecesCount} {itemName}!";
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.booths.Models.First(b => b.BoothId == boothId);
            double currentBill = booth.CurrentBill;

            booth.Charge();
            booth.ChangeStatus();

            return $"Bill {currentBill:f2} lv" 
                + Environment.NewLine
                + $"Booth {boothId} is now available!";
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = this.booths.Models.First(b => b.BoothId == boothId);

            return booth.ToString() ;
        }



    }
}
