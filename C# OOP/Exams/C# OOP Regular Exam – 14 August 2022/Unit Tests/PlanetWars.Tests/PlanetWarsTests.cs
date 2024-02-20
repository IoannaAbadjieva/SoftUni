namespace PlanetWars.Tests
{
	using NUnit.Framework;
	using System;

	public class Tests
	{
		[TestFixture]
		public class PlanetWarsTests
		{

			[Test]
			public void WeaponCtorShouldSetValuesCorectly()
			{
				Weapon weapon = new Weapon("Sword", 15.75, 25);

				Assert.That(weapon.Name, Is.EqualTo("Sword"));
				Assert.That(weapon.Price, Is.EqualTo(15.75));
				Assert.That(weapon.DestructionLevel, Is.EqualTo(25));
			}

			[TestCase(-0.00001)]
			[TestCase(-1)]
			[TestCase(-55)]
			public void WeaponCtorShouldThrowWhenPriceNegative(double price)
			{
				Assert.Throws<ArgumentException>(() =>
				{
					Weapon weapon = new Weapon("Sword", price, 25);

				}, "Price cannot be negative.");
			}

			[Test]
			public void IncreaseDestruvtionLevelShouldWorkProperly()
			{
				Weapon weapon = new Weapon("Sword", 15.75, 25);

				weapon.IncreaseDestructionLevel();
				weapon.IncreaseDestructionLevel();
				weapon.IncreaseDestructionLevel();

				Assert.That(weapon.DestructionLevel, Is.EqualTo(28));
			}

			[TestCase(10)]
			[TestCase(50)]
			public void IsNuclearShouldReturnProperValue(int destructionLevel)
			{
				Weapon weapon = new Weapon("Sword", 15.75, destructionLevel);

				Assert.That(weapon.IsNuclear, Is.EqualTo(true));
			}

			[TestCase(9)]
			[TestCase(1)]
			public void IsNuclearShouldReturnFalseWhenDestructionBelow10(int destructionLevel)
			{
				Weapon weapon = new Weapon("Sword", 15.75, destructionLevel);

				Assert.That(weapon.IsNuclear, Is.EqualTo(false));
			}

			[Test]
			public void PlanetCtorShouldInitializeCollectionOfWeapons()
			{
				Planet planet = new Planet("Nabu", 170);

				Assert.IsNotNull(planet.Weapons);
			}

			[Test]
			public void PlanetCtorShouldSetValuesProperly()
			{
				Planet planet = new Planet("Nabu", 170);

				Assert.That(planet.Name, Is.EqualTo("Nabu"));
				Assert.That(planet.Budget, Is.EqualTo(170));
				Assert.That(planet.Weapons.Count, Is.EqualTo(0));
			}

			[TestCase(null)]
			[TestCase("")]
			public void NameSetterThrowWhenNameIsNullOrEmpty(string name)
			{
				Assert.Throws<ArgumentException>(() =>
				{
					Planet planet = new Planet(name, 170);
				}, "Invalid planet Name");

			}


			[TestCase(-0.00001)]
			[TestCase(-1)]
			[TestCase(-55)]
			public void BudgetSetterShouldThrowWhenBudgetNegative(double budget)
			{
				Assert.Throws<ArgumentException>(() =>
				{
					Planet planet = new Planet("Nabu", budget);

				}, "Budget cannot drop below Zero!");
			}

			[Test]
			public void MilitaryPowerRatioShouldReturnProperValue()
			{
				Planet planet = new Planet("Nabu", 170);
				Weapon weapon1 = new Weapon("Sword", 15.75, 25);
				Weapon weapon2 = new Weapon("SomeWeapon", 5.75, 15);
				Weapon weapon3 = new Weapon("SomeOtherWeapon", 35.75, 40);

				planet.AddWeapon(weapon1);
				planet.AddWeapon(weapon2);
				planet.AddWeapon(weapon3);

				Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(80));

				planet.RemoveWeapon("SomeOtherWeapon");
				Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(40));

			}

			[Test]
			public void AddWeaponShouldAddWeaponToCollection()
			{
				Planet planet = new Planet("Nabu", 170);
				Weapon weapon1 = new Weapon("Sword", 15.75, 25);
				Weapon weapon2 = new Weapon("SomeWeapon", 5.75, 15);
				Weapon weapon3 = new Weapon("SomeOtherWeapon", 35.75, 40);

				planet.AddWeapon(weapon1);
				planet.AddWeapon(weapon2);
				planet.AddWeapon(weapon3);

				Assert.That(planet.Weapons.Count, Is.EqualTo(3));
			}


			[Test]
			public void AddWeaponShouldThrowWhenAddingWeaponWithSameName()
			{
				Planet planet = new Planet("Nabu", 170);
				Weapon weapon1 = new Weapon("Sword", 15.75, 25);
				Weapon weapon2 = new Weapon("SomeWeapon", 5.75, 15);
				Weapon weapon3 = new Weapon("SomeWeapon", 35.75, 40);

				planet.AddWeapon(weapon1);
				planet.AddWeapon(weapon2);


				Assert.Throws<InvalidOperationException>(() =>
				{
					planet.AddWeapon(weapon3);

				}, $"There is already a {weapon3.Name} weapon.");
			}

			[TestCase(0.5)]
			[TestCase(15)]
			[TestCase(130)]
			public void ProfitShouldIncreaseBudget(double amount)
			{
				double budget = 170;
				Planet planet = new Planet("Nabu", budget);

				planet.Profit(amount);

				Assert.That(planet.Budget, Is.EqualTo(budget + amount));
			}

			[TestCase(0.5)]
			[TestCase(15)]
			[TestCase(130)]
			public void SpendFundsShouldDecreaseBudget(double amount)
			{
				double budget = 170;
				Planet planet = new Planet("Nabu", budget);

				planet.SpendFunds(amount);

				Assert.That(planet.Budget, Is.EqualTo(budget - amount));
			}

			[TestCase(50.05)]
			[TestCase(75)]
			[TestCase(250)]
			public void SpendFundsShouldThrowWhenBudgetNotEnough(double amount)
			{
				double budget = 50;
				Planet planet = new Planet("Nabu", budget);

				Assert.Throws<InvalidOperationException>(() =>
				{
					planet.SpendFunds(amount);

				}, "Not enough funds to finalize the deal.");
			}


			[Test]
			public void RemoveWeaponShouldRemoveWeaponFromCollection()
			{
				Planet planet = new Planet("Nabu", 170);
				Weapon weapon1 = new Weapon("Sword", 15.75, 25);
				Weapon weapon2 = new Weapon("SomeWeapon", 5.75, 15);
				Weapon weapon3 = new Weapon("SomeOtherWeapon", 35.75, 40);
				planet.AddWeapon(weapon1);
				planet.AddWeapon(weapon2);

				planet.RemoveWeapon("SomeOtherWeapon");

				Assert.That(planet.Weapons.Count, Is.EqualTo(2));
				Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(40));
			}

			[Test]
			public void UpgradeWeaponShouldIncreaseDestructionLevelOfTheWeapon()
			{
				Planet planet = new Planet("Nabu", 170);
				Weapon weapon1 = new Weapon("Sword", 15.75, 25);
				planet.AddWeapon(weapon1);

				planet.UpgradeWeapon("Sword");

				Assert.That(weapon1.DestructionLevel, Is.EqualTo(26));
				Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(26));
			}

			[Test]
			public void UpgradeWeaponShouldThrowWhenNoSuchWeapon()
			{
				Planet planet = new Planet("Nabu", 170);
				Weapon weapon1 = new Weapon("Sword", 15.75, 25);
				planet.AddWeapon(weapon1);

				Assert.Throws<InvalidOperationException>(() =>
				{
					planet.UpgradeWeapon("SomeWeapon");
				}, $"SomeWeapon does not exist in the weapon repository of {planet.Name}");

			}

			[Test]
			public void DestructOpponentShouldReturnProperMessage()
			{
				Planet planet = new Planet("Nabu", 170);
				Weapon weapon1 = new Weapon("Sword", 15.75, 25);
				Weapon weapon2 = new Weapon("SomeWeapon", 5.75, 15);
				planet.AddWeapon(weapon1);
				planet.AddWeapon(weapon2);

				Planet opponent = new Planet("Opponent", 300);
				Weapon weapon3 = new Weapon("SomeOtherWeapon", 35.75, 20);
				Weapon weapon4 = new Weapon("SomeSecretWeapon", 25.75, 10);
				opponent.AddWeapon(weapon3);
				opponent.AddWeapon(weapon4);

				Assert.That(planet.DestructOpponent(opponent), Is.EqualTo($"{opponent.Name} is destructed!"));

			}

			[TestCase(25, 15)]
			[TestCase(50, 30)]
			public void DestructOpponentShouldThrowWhenOpponentTooStrong(int weapon3destructionLevel, int weapon4destructionLevel)
			{
				Planet planet = new Planet("Nabu", 170);
				Weapon weapon1 = new Weapon("Sword", 15.75, 25);
				Weapon weapon2 = new Weapon("SomeWeapon", 5.75, 15);
				planet.AddWeapon(weapon1);
				planet.AddWeapon(weapon2);

				Planet opponent = new Planet("Opponent", 300);
				Weapon weapon3 = new Weapon("SomeOtherWeapon", 35.75, weapon3destructionLevel);
				Weapon weapon4 = new Weapon("SomeSecretWeapon", 25.75, weapon4destructionLevel);
				opponent.AddWeapon(weapon3);
				opponent.AddWeapon(weapon4);

				Assert.Throws<InvalidOperationException>(() =>
				{
					planet.DestructOpponent(opponent);
				}, $"{opponent.Name} is too strong to declare war to!");


			}
		}
	}
}
