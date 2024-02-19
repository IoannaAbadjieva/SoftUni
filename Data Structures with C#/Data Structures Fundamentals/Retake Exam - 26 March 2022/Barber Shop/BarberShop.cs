using System;
using System.Collections.Generic;
using System.Linq;

namespace BarberShop
{
    public class BarberShop : IBarberShop
    {
        private Dictionary<string, Barber> barbersByName;
        private Dictionary<string, Client> clientsByName;
        private Dictionary<string, Client> clientsWithouthBarber;
        private Dictionary<string, HashSet<Client>> barbersWithClients;

        public BarberShop()
        {
            this.barbersByName = new Dictionary<string, Barber>();
            this.clientsByName = new Dictionary<string, Client>();
            this.clientsWithouthBarber = new Dictionary<string, Client>();
            this.barbersWithClients = new Dictionary<string, HashSet<Client>>();
        }

        public void AddBarber(Barber b)
        {
            if (this.barbersByName.ContainsKey(b.Name))
            {
                throw new ArgumentException();
            }

            this.barbersByName.Add(b.Name, b);
            this.barbersWithClients[b.Name] = new HashSet<Client>();
        }

        public void AddClient(Client c)
        {
            if (this.clientsByName.ContainsKey(c.Name))
            {
                throw new ArgumentException();
            }

            this.clientsByName.Add(c.Name, c);
            this.clientsWithouthBarber.Add(c.Name, c);
        }

        public bool Exist(Barber b)
        {
            return this.barbersByName.ContainsKey(b.Name);
        }

        public bool Exist(Client c)
        {
            return this.clientsByName.ContainsKey(c.Name);
        }

        public IEnumerable<Barber> GetBarbers()
        {
            return this.barbersByName.Values;
        }

        public IEnumerable<Client> GetClients()
        {
            return this.clientsByName.Values;
        }

        public void AssignClient(Barber b, Client c)
        {
            if (!this.barbersByName.ContainsKey(b.Name) || !this.clientsByName.ContainsKey(c.Name))
            {
                throw new ArgumentException();
            }

            this.clientsByName[c.Name].Barber = this.barbersByName[b.Name];
            this.barbersWithClients[b.Name].Add(c);
            this.clientsWithouthBarber.Remove(c.Name);
        }

        public void DeleteAllClientsFrom(Barber b)
        {
            if (!this.barbersByName.ContainsKey(b.Name))
            {
                throw new ArgumentException();
            }

            foreach (var client in this.barbersWithClients[b.Name])
            {
                this.clientsByName.Remove(client.Name);
            }

            this.barbersWithClients[b.Name].Clear();
        }

        public IEnumerable<Client> GetClientsWithNoBarber()
        {
            return this.clientsWithouthBarber.Values;

        }

        public IEnumerable<Barber> GetAllBarbersSortedWithClientsCountDesc()
        {
            return this.barbersByName.Values
                .OrderByDescending(b => barbersWithClients[b.Name].Count());
        }

        public IEnumerable<Barber> GetAllBarbersSortedWithStarsDecsendingAndHaircutPriceAsc()
        {
            return this.barbersByName.Values
                .OrderByDescending(b => b.Stars)
                .ThenBy(b => b.HaircutPrice);
        }

        public IEnumerable<Client> GetClientsSortedByAgeDescAndBarbersStarsDesc()
        {
            return this.clientsByName.Values
                .Where(c => c.Barber != null)
                .OrderByDescending(c => c.Age)
                .ThenByDescending(c => c.Barber.Stars);
        }
    }
}
