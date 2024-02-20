namespace CarManager.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class CarManagerTests
	{
		private const string make = "Volkswagen";

		private const string model = "Phaeton";

		private const double fuelAmount = 0;

		private const double fuelConsumption = 10;

		private double fuelCapacity = 64;


		[Test]
		public void ConstructorShouldSetDataProperly()
		{
			//Act
			Car car = new Car(make, model, fuelConsumption, fuelCapacity);

			//Assert
			Assert.That(car.Make, Is.EqualTo(make));
			Assert.That(car.Model, Is.EqualTo(model));
			Assert.That(car.FuelAmount, Is.EqualTo(fuelAmount));
			Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
			Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
		}

		[Test]
		public void MakeShouldThrowExceptionIfNull()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				Car car = new Car(null, model, fuelConsumption, fuelCapacity);
			},
			//Assert
			"Make cannot be null or empty!");
		}

		[Test]
		public void MakeShouldThrowExceptionIfEmpty()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				Car car = new Car(string.Empty, model, fuelConsumption, fuelCapacity);
			},
			//Assert
			"Make cannot be null or empty!");
		}

		[Test]
		public void ModelShouldThrowExceptionIfNull()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				Car car = new Car(make, null, fuelConsumption, fuelCapacity);
			},
			//Assert
			"Model cannot be null or empty!");
		}

		[Test]
		public void ModelShouldThrowExceptionIfEmpty()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				Car car = new Car(make, string.Empty, fuelConsumption, fuelCapacity);
			},
			//Assert
			"Model cannot be null or empty!");
		}

		[Test]
		public void FuelConsumptionShouldThrowExceptionIfZero()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				Car car = new Car(make, model, 0, fuelCapacity);
			},
			//Assert
			"Fuel consumption cannot be zero or negative!");
		}


		[Test]
		public void FuelConsumptionShouldThrowExceptionIfNegative()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				Car car = new Car(make, model, -2, fuelCapacity);
			},
			 //Assert
			 "Fuel consumption cannot be zero or negative!");
		}

		[Test]
		public void FuelCapacityShouldThrowExceptionIfZero()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				Car car = new Car(make, model, fuelConsumption, 0);
			},
			//Assert
			"Fuel capacity cannot be zero or negative!");
		}

		[Test]
		public void FuelCapacityShouldThrowExceptionIfNegative()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				Car car = new Car(make, model, fuelConsumption, -54);
			},
			 //Assert
			 "Fuel capacity cannot be zero or negative!");
		}

		[Test]
		public void CarRefuelShouldThrowExceptionIfFuelIsZero()
		{
			//Arrange
			Car car = new Car(make, model, fuelConsumption, fuelCapacity);

			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				car.Refuel(0);
			},
			//Assert
			"Fuel amount cannot be zero or negative!");
		}


		[Test]
		public void CarRefuelShouldThrowExceptionIfFuelIsNegative()
		{
			//Arrange
			Car car = new Car(make, model, fuelConsumption, fuelCapacity);

			Assert.Throws<ArgumentException>(() =>
			{
				//Act
				car.Refuel(-34);
			},
			//Assert
			"Fuel amount cannot be zero or negative!");
		}

		[Test]
		public void CarRefuelShouldWorkProperlyWhenFuelIsEqualToCapacity()
		{
			//Arrange
			Car car = new Car(make, model, fuelConsumption, fuelCapacity);

			//Act
			car.Refuel(fuelCapacity);

			//Assert
			Assert.That(car.FuelAmount, Is.EqualTo(fuelCapacity));
		}

		[Test]
		public void CarRefuelShouldWorkProperlyWhenFuelIsMoreThanCapacity()
		{
			//Arrange
			Car car = new Car(make, model, fuelConsumption, fuelCapacity);

			//Act
			car.Refuel(fuelCapacity + 10);

			//Assert
			Assert.That(car.FuelAmount, Is.EqualTo(fuelCapacity));
		}

		[Test]
		public void CarDriveShouldThrowExceptionIfInsufficientFuelForDistance()
		{
			//Arrange
			double distance = 1000;
			Car car = new Car(make, model, fuelConsumption, fuelCapacity);
			car.Refuel(fuelCapacity);

			Assert.Throws<InvalidOperationException>(() =>
			{
				//Act
				car.Drive(distance);
			},
			//Assert
			"You don't have enough fuel to drive!");
		}

		[Test]
		public void CarDriveShouldSetFuelAmountProperlyWhenFuelIsEnoughForDistance()
		{
			//Arrange
			double distance = 640;
			Car car = new Car(make, model, fuelConsumption, fuelCapacity);
			car.Refuel(fuelCapacity);

			//Act
			car.Drive(distance);

			//Assert
			Assert.That(car.FuelAmount, Is.EqualTo(0));
		}

	}
}