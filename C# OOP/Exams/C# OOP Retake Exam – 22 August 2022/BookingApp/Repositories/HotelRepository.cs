using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly ICollection<IHotel> hotels;

        public HotelRepository()
        {
            this.hotels = new HashSet<IHotel>();
        }

        public void AddNew(IHotel model)
        {
            this.hotels.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        => (IReadOnlyCollection<IHotel>)this.hotels;

        public IHotel Select(string criteria)
        => this.hotels.FirstOrDefault(h => h.FullName == criteria);
    }
}
