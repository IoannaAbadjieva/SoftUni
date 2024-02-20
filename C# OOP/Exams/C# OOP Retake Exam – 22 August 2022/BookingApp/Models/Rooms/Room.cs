using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double pricePerNight = 0;

        protected Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
        }

        public int BedCapacity { get; private set; }

        public double PricePerNight
        {
            get => this.pricePerNight;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }

                this.pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
