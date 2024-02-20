namespace BookigApp.Tests
{
	using System;

	using NUnit.Framework;

	using FrontDeskApp;

	public class Tests
	{
		private const string fullName = "SomeFancyHotelName";
		private const int category = 5;
		private const double turnover = 0;
		private Hotel hotel;

		[SetUp]
		public void Setup()
		{
			this.hotel = new Hotel(fullName, category);
		}

		[Test]
		public void TestConstructorShouldInitialazeCollections()
		{
			Assert.IsNotNull(this.hotel.Rooms);
			Assert.IsNotNull(this.hotel.Bookings);
		}

		[Test]
		public void TestConstructorShouldSetValuesProperly()
		{
			Assert.That(hotel.FullName, Is.EqualTo(fullName));
			Assert.That(hotel.Category, Is.EqualTo(category));
			Assert.That(hotel.Turnover, Is.EqualTo(turnover));
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("        ")]
		public void ConstructorShouldThrowWhenNameNullEmptyOrWhitespace(string fullName)
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				Hotel hotel = new Hotel(fullName, category);

			});
		}

		[TestCase(0)]
		[TestCase(6)]
		[TestCase(357)]
		[TestCase(-45)]
		public void ConstructorShouldThrowWhenCategoryNotBetween1And5(int category)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				Hotel hotel = new Hotel(fullName, category);

			});
		}

		[Test]
		public void AddRoomShouldWorkProperly()
		{
			Room room = new Room(2, 137);
			this.hotel.AddRoom(room);

			Assert.That(this.hotel.Rooms.Count, Is.EqualTo(1));
		}

		[TestCase(0)]
		[TestCase(-1)]
		[TestCase(-48)]
		public void BookRoomShouldThrowIfAdultsCountZeroOrNegative(int adults)
		{
			Room room = new Room(2, 137);
			this.hotel.AddRoom(room);

			Assert.Throws<ArgumentException>(() =>
			{
				this.hotel.BookRoom(adults, 0, 2, 100);
			});
		}


		[TestCase(-1)]
		[TestCase(-48)]
		public void BookRoomShouldThrowIfChildrenCountNegative(int children)
		{
			Room room = new Room(2, 137);
			this.hotel.AddRoom(room);

			Assert.Throws<ArgumentException>(() =>
			{
				this.hotel.BookRoom(2, children, 2, 100);
			});
		}

		[TestCase(0)]
		[TestCase(-1)]
		[TestCase(-48)]
		public void BookRoomShouldThrowIfDurationZeroOrNegative(int duration)
		{
			Room room = new Room(2, 137);
			this.hotel.AddRoom(room);

			Assert.Throws<ArgumentException>(() =>
			{
				this.hotel.BookRoom(2, 2, duration, 100);
			});
		}

		[TestCase(2, 1)]
		[TestCase(2, 3)]
		public void BookRoomMethodShouldNotAddBookingIfBedcapacityLowerThanBedsNeeded(int adults, int children)
		{
			Room room = new Room(2, 137);
			this.hotel.AddRoom(room);

			this.hotel.BookRoom(adults, children, 2, 100);

			Assert.That(this.hotel.Bookings.Count, Is.EqualTo(0));
		}

		[TestCase(199)]
		[TestCase(50)]
		public void BookRoomMethodShouldNotAddBookingIfBudgetLowerThanPrice(int budget)
		{
			Room room = new Room(4, 100);
			this.hotel.AddRoom(room);

			this.hotel.BookRoom(2, 2, 2, 100);

			Assert.That(this.hotel.Bookings.Count, Is.EqualTo(0));
		}

		[TestCase(200)]
		[TestCase(1050)]
		public void BookRoomMethodShouldAddBooking(int budget)
		{
			Room room = new Room(4, 100);
			this.hotel.AddRoom(room);

			this.hotel.BookRoom(2, 2, 2, budget);

			Assert.That(this.hotel.Bookings.Count, Is.EqualTo(1));
			Assert.That(this.hotel.Turnover, Is.EqualTo(200));
		}

	}
}