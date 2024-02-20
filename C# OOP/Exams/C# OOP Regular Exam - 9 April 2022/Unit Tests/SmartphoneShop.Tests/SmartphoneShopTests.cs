namespace SmartphoneShop.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

	using NUnit.Framework;

	[TestFixture]
	public class SmartphoneShopTests
	{
		private Shop defShop;

		[SetUp]
		public void SetUp()
		{
			this.defShop = new Shop(5);
		}

		[Test]
		public void CtorShouldInitializeCollection()
		{


			Type type = this.defShop.GetType();
			FieldInfo collectionFieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.FirstOrDefault(fi => fi.Name == "phones");
			object fieldValue = collectionFieldInfo.GetValue(this.defShop);

			Assert.IsNotNull(fieldValue);
		}

		[TestCase(1)]
		[TestCase(100)]
		public void CtorShouldInitializeCapacityProperly(int capacity)
		{
			Shop shop = new Shop(capacity);

			Assert.AreEqual(capacity, shop.Capacity);
		}

		[TestCase(-1)]
		[TestCase(-100)]
		public void CapacityShouldThrowWhenNegative(int capacity)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				Shop shop = new Shop(capacity);
			}, "Invalid capacity.");
		}

		[Test]
		public void CountShouldReturnProperValueWhenCreatingInstance()
		{
			Assert.That(defShop.Count, Is.EqualTo(0));

			Shop shop = new Shop(1);

		}

		[Test]
		public void CountShouldReturnProperValuee()
		{
			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			Smartphone smartphone2 = new Smartphone("Samsung Something Else", 100);
			Smartphone smartphone3 = new Smartphone("Doogee Something Entirely Different", 100);

			defShop.Add(smartphone1);
			defShop.Add(smartphone2);
			defShop.Add(smartphone3);

			Assert.That(defShop.Count, Is.EqualTo(3));

		}

		[Test]
		public void AddSmartphoneShouldAddItemToCollection()
		{
			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			this.defShop.Add(smartphone1);

			Type defShopType = this.defShop.GetType();
			FieldInfo collectionFieldInfo = defShopType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.FirstOrDefault(fi => fi.Name == "phones");


			ICollection<Smartphone> phones = (ICollection<Smartphone>)collectionFieldInfo.GetValue(this.defShop);

			Assert.IsTrue(phones.Contains(smartphone1));
			Assert.That(this.defShop.Count, Is.EqualTo(1));

		}

		[Test]
		public void AddSmartphoneShouldThrowWhenAddingSameModelName()
		{
			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			defShop.Add(smartphone1);

			Assert.Throws<InvalidOperationException>(() =>
			{
				defShop.Add(smartphone1);
			}, $"The phone model {smartphone1.ModelName} already exist.");
		}

		[Test]
		public void AddSmartphoneShouldThrowWhenShopIsFull()
		{
			Shop shop = new Shop(1);
			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			Smartphone smartphone2 = new Smartphone("Samsung Something Else", 100);
			shop.Add(smartphone1);

			Assert.Throws<InvalidOperationException>(() =>
			{
				shop.Add(smartphone2);
			}, "The shop is full.");
		}

		[Test]
		public void RemoveShouldDecreaseCount()
		{
			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			Smartphone smartphone2 = new Smartphone("Samsung Something Else", 100);
			this.defShop.Add(smartphone1);
			this.defShop.Add(smartphone2);

			this.defShop.Remove("Sony Experia Something");

			Assert.That(this.defShop.Count, Is.EqualTo(1));
		}

		[Test]
		public void RemoveShouldRemoveItemFromCollection()
		{
			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			Smartphone smartphone2 = new Smartphone("Samsung Something Else", 100);
			this.defShop.Add(smartphone1);
			this.defShop.Add(smartphone2);

			this.defShop.Remove("Sony Experia Something");

			Type defShopType = this.defShop.GetType();
			FieldInfo collectionFieldInfo = defShopType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.FirstOrDefault(fi => fi.Name == "phones");
			ICollection<Smartphone> phones = (ICollection<Smartphone>)collectionFieldInfo.GetValue(this.defShop);

			Assert.IsFalse(phones.Contains(smartphone1));
		}

		[Test]
		public void RemoveShouldThrowWhenItemNotExists()
		{

			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			Smartphone smartphone2 = new Smartphone("Samsung Something Else", 100);
			this.defShop.Add(smartphone1);

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.defShop.Remove("Samsung Something Else");
			}, $"The phone model {smartphone2.ModelName} doesn't exist.");
		}


		[Test]
		public void TestPhoneShouldThrowWhenItemNotExists()
		{

			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			Smartphone smartphone2 = new Smartphone("Samsung Something Else", 100);
			this.defShop.Add(smartphone1);

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.defShop.TestPhone("Samsung Something Else", 50);
			}, $"The phone model {smartphone2.ModelName} doesn't exist.");
		}

		[Test]
		public void TestPhoneShouldThrowWhenLowBatery()
		{
			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			this.defShop.Add(smartphone1);

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.defShop.TestPhone("Sony Experia Something", 150);
			}, $"The phone model {smartphone1.ModelName} is low on batery.");
		}

		[TestCase(50)]
		[TestCase(100)]
		public void TestPhoneShouldDecreaseBateryCharge(int batteryUsage)
		{
			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			this.defShop.Add(smartphone1);

			this.defShop.TestPhone("Sony Experia Something", batteryUsage);

			Assert.That(smartphone1.CurrentBateryCharge, Is.EqualTo(100 - batteryUsage));

		}


		[Test]
		public void ChargePhoneShouldThrowWhenItemNotExists()
		{

			Smartphone smartphone1 = new Smartphone("Sony Experia Something", 100);
			Smartphone smartphone2 = new Smartphone("Samsung Something Else", 100);
			this.defShop.Add(smartphone1);

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.defShop.ChargePhone("Samsung Something Else");
			}, $"The phone model {smartphone2.ModelName} doesn't exist.");
		}

		[TestCase(50)]
		[TestCase(100)]
		public void ChargePhoneShouldSetBateryChargeToMaxCharge(int maxBatteryCharge)
		{
			Smartphone smartphone1 = new Smartphone("Sony Experia Something", maxBatteryCharge);
			this.defShop.Add(smartphone1);
			this.defShop.TestPhone("Sony Experia Something", 25);
			this.defShop.TestPhone("Sony Experia Something", 25);

			this.defShop.ChargePhone("Sony Experia Something");

			Assert.That(smartphone1.CurrentBateryCharge, Is.EqualTo(maxBatteryCharge));

		}

	}
}