using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private readonly IRepository<IRoom> rooms;
        private readonly IRepository<IBooking> bookings;

        private Hotel()
        {
            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }

        public Hotel(string fullName, int category)
            : this()
        {
            this.FullName = fullName;
            this.Category = category;
        }

        public string FullName
        {
            get => this.fullName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }

                this.fullName = value;
            }
        }

        public int Category
        {
            get => this.category;

            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }

                this.category = value;
            }
        }

        public double Turnover
            => Math.Round(this.Bookings.All().Sum(b => b.ResidenceDuration * b.Room.PricePerNight), 2);

        public IRepository<IRoom> Rooms => this.rooms;

        public IRepository<IBooking> Bookings => this.bookings;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Hotel name: {this.fullName}")
                .AppendLine($"--{this.Category} star hotel")
                .AppendLine($"--Turnover: {this.Turnover:f2} $")
                .AppendLine("--Bookings:")
                .AppendLine();

            if (!this.Bookings.All().Any())
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in this.Bookings.All())
                {
                    sb
                        .AppendLine(booking.BookingSummary())
                        .AppendLine();
                }
            }

            return sb.ToString().Trim();
        }
    }
}
