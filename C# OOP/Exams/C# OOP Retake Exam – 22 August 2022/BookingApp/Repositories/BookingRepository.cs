using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly ICollection<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new HashSet<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            this.bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        =>(IReadOnlyCollection<IBooking>)this.bookings;

        public IBooking Select(string criteria)
        =>this.bookings.FirstOrDefault(b => b.BookingNumber.ToString() == criteria);
    }
}
