using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel != null)
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            hotel = new Hotel(hotelName, category);
            this.hotels.AddNew(hotel);

            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return "Room type is already created!";
            }

            IRoom room = roomTypeName switch
            {
                nameof(DoubleBed) => new DoubleBed(),
                nameof(Studio) => new Studio(),
                nameof(Apartment) => new Apartment(),
                _ => throw new ArgumentException("Incorrect room type!")
            };

            hotel.Rooms.AddNew(room);
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room == null)
            {
                return "Room type is not created yet!";
            }

            if (room.PricePerNight != 0)
            {
                return "Price is already set!";
            }

            room.SetPrice(price);
            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
        }


        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var orderedHotels = this.hotels.All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.FullName);

            if (!orderedHotels.Any())
            {
                return $"{category} star hotel is not available in our platform.";
            }

            foreach (var hotel in orderedHotels)
            {
                IRoom room = hotel.Rooms.All()
                    .Where(r => r.PricePerNight > 0 && r.BedCapacity >= adults + children)
                    .OrderBy(r => r.BedCapacity)
                    .FirstOrDefault();

                if (room != null)
                {
                    int bookingNumber = hotel.Bookings.All().Count + 1;
                    IBooking booking = new Booking(room, duration, adults, children, bookingNumber);
                    hotel.Bookings.AddNew(booking);

                    return $"Booking number {bookingNumber} for {hotel.FullName} hotel is successful!";
                }
            }

            return "We cannot offer appropriate room for your request.";

        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            return hotel.ToString();
        }
    }
}
