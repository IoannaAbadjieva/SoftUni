namespace RepairShop.Tests
{
	using NUnit.Framework;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

	public class Tests
	{
		[TestFixture]
		public class RepairsShopTests
		{
			private Garage defGarage;

			[SetUp]
			public void SetUp()
			{
				this.defGarage = new Garage("NameOfGarage", 2);
			}

			[Test]
			public void CtorShouldInitializeCollection()
			{
				Type defGarageType = defGarage.GetType();
				FieldInfo field = defGarageType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
					.FirstOrDefault(fi => fi.Name == "cars");

				ICollection collection = (ICollection)field.GetValue(defGarage);

				Assert.IsNotNull(collection);
				Assert.That(collection.Count, Is.EqualTo(0));
			}

			[Test]
			public void CtorShouldSetValuesProperly()
			{
				Assert.That(defGarage.Name, Is.EqualTo("NameOfGarage"));
				Assert.That(defGarage.MechanicsAvailable, Is.EqualTo(2));
			}

			[TestCase(null)]
			[TestCase("")]
			public void NameSetterShouldThrowWhenNullOrEmpty(string name)
			{
				Assert.Throws<ArgumentNullException>(() =>
				{
					Garage garage = new Garage(name, 2);
				});
			}

			[TestCase(0)]
			[TestCase(-1)]
			[TestCase(-55)]
			public void MechanicsAvailableSetterShouldThrowWhenNegative(int mechanicsAvailable)
			{
				Assert.Throws<ArgumentException>(() =>
				{
					Garage garage = new Garage("NameOfGarage", mechanicsAvailable);
				}, "At least one mechanic must work in the garage.");
			}

			[Test]
			public void CarsInGarageShouldReturnCorrectValue()
			{
				Car carOne = new Car("opel", 3);
				Car carTwo = new Car("volkswagen", 2);
				this.defGarage.AddCar(carOne);
				this.defGarage.AddCar(carTwo);

				Assert.That(defGarage.CarsInGarage, Is.EqualTo(2));
			}

			[Test]
			public void AddCarShousdAddItemToCollection()
			{
				Car carOne = new Car("opel", 3);
				Car carTwo = new Car("volkswagen", 2);
				this.defGarage.AddCar(carOne);
				this.defGarage.AddCar(carTwo);

				Type defGarageType = defGarage.GetType();
				FieldInfo field = defGarageType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
					.FirstOrDefault(fi => fi.Name == "cars");

				List<Car> collection = (List<Car>)field.GetValue(defGarage);

				Assert.IsTrue(collection.Contains(carOne));
				Assert.IsTrue(collection.Contains(carTwo));
				Assert.That(collection.Count, Is.EqualTo(2));
			}

			[Test]
			public void AddCarShousdThrowWhenNoMechanicsAvailable()
			{
				Car carOne = new Car("opel", 3);
				Car carTwo = new Car("volkswagen", 2);
				Car carTHree = new Car("ford", 4);
				this.defGarage.AddCar(carOne);
				this.defGarage.AddCar(carTwo);

				Assert.Throws<InvalidOperationException>(() =>
				{
					defGarage.AddCar(carTHree);
				}, "No mechanic available.");
			}

			[Test]
			public void FixCarShouldWorkProperly()
			{
				Car carOne = new Car("opel", 3);
				this.defGarage.AddCar(carOne);

				Car fixedCar = this.defGarage.FixCar("opel");

				Assert.That(fixedCar, Is.EqualTo(carOne));
				Assert.That(carOne.IsFixed, Is.True);
				Assert.That(carOne.NumberOfIssues, Is.EqualTo(0));
			}

			[Test]
			public void FixCarShouldThrowWhenCarDoesNotExist()
			{

				Car carOne = new Car("opel", 3);
				Car carTwo = new Car("volkswagen", 2);
				this.defGarage.AddCar(carOne);

				Assert.Throws<InvalidOperationException>(() =>
				{
					Car fixedCar = this.defGarage.FixCar("volkswagen");
				}, $"The car volkswagen doesn't exist.");
			}

			[Test]
			public void RemoveCarShousdRemoveItemFromCollection()
			{
				Car carOne = new Car("opel", 3);
				Car carTwo = new Car("volkswagen", 2);
				this.defGarage.AddCar(carOne);
				this.defGarage.AddCar(carTwo);

				this.defGarage.FixCar("opel");
				this.defGarage.RemoveFixedCar();

				Type defGarageType = defGarage.GetType();
				FieldInfo field = defGarageType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
					.FirstOrDefault(fi => fi.Name == "cars");

				List<Car> collection = (List<Car>)field.GetValue(defGarage);

				Assert.IsFalse(collection.Contains(carOne));
				Assert.That(collection.Count, Is.EqualTo(1));
			}

			[Test]
			public void RemoveCarShousdThrowWhenNoFixedCars()
			{
				Car carOne = new Car("opel", 3);
				Car carTwo = new Car("volkswagen", 2);
				this.defGarage.AddCar(carOne);
				this.defGarage.AddCar(carTwo);

				Assert.Throws<InvalidOperationException>(() =>
				{
					this.defGarage.RemoveFixedCar();
				}, "No fixed cars available.");

			}

			[Test]
			public void ReportShouldWork()
			{
				Car carOne = new Car("opel", 3);
				Car carTwo = new Car("volkswagen", 2);
				this.defGarage.AddCar(carOne);
				this.defGarage.AddCar(carTwo);

				string expected = "There are 2 which are not fixed: opel, volkswagen.";

				Assert.That(this.defGarage.Report(), Is.EqualTo(expected));
			}

			[Test]
			public void ReportShouldWorkWhenAllcarsAreFixed()
			{
				Car carOne = new Car("opel", 3);
				Car carTwo = new Car("volkswagen", 2);
				this.defGarage.AddCar(carOne);
				this.defGarage.FixCar("opel");
				this.defGarage.AddCar(carTwo);
				this.defGarage.FixCar("volkswagen");



				string expected = "There are 0 which are not fixed: .";

				Assert.That(this.defGarage.Report(), Is.EqualTo(expected));
			}

		}
	}
}