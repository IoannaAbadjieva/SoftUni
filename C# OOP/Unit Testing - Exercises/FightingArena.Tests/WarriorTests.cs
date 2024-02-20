namespace FightingArena.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class WarriorTests
	{
		private const string name = "warrior";
		private const int damage = 50;
		private const int hp = 50;
		private const int MIN_ATTACK_HP = 30;


		[Test]
		public void ConstructorShouldSetDataProperly()
		{
			Warrior warrior = new Warrior(name, damage, hp);

			Assert.AreEqual(warrior.Name, name);
			Assert.AreEqual(warrior.Damage, damage);
			Assert.AreEqual(warrior.HP, hp);
		}

		[TestCase("W")]
		[TestCase("NewWarrior")]
		[TestCase("NewWarrior   NewWarrior    NewWarrior")]
		public void NameSetterShouldSetDataProperly(string name)
		{
			Warrior warrior = new Warrior(name, damage, hp);

			Assert.AreEqual(warrior.Name, name);
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("           ")]
		public void NameSetterShouldThrowExceptionWhenNullOrWhiteSpace(string name)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				Warrior warrior = new Warrior(name, damage, hp);

			}, "Name should not be empty or whitespace!");
		}


		[TestCase(1)]
		[TestCase(150)]
		public void DamageSetterShouldSetDataProperly(int damage)
		{
			Warrior warrior = new Warrior(name, damage, hp);

			Assert.AreEqual(warrior.Damage, damage);
		}

		[TestCase(0)]
		[TestCase(-17)]
		public void DamageSetterShouldThrowExceptionWhenZeroOrNegative(int damage)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				Warrior warrior = new Warrior(name, damage, hp);

			}, "Damage value should be positive!");
		}

		[TestCase(0)]
		[TestCase(50)]
		public void HPSetterShouldSetDataProperly(int hp)
		{
			Warrior warrior = new Warrior(name, damage, hp);

			Assert.AreEqual(warrior.HP, hp);
		}

		[TestCase(-1)]
		[TestCase(-17)]
		public void HPSetterShouldThrowExceptionWhenZeroOrNegative(int hp)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				Warrior warrior = new Warrior(name, damage, hp);

			}, "HP should not be negative!");
		}

		[TestCase(0)]
		[TestCase(MIN_ATTACK_HP / 2)]
		[TestCase(MIN_ATTACK_HP)]
		public void AttackMethodShouldThrowExceptionWhenHpLowerThanMinHP(int hp)
		{
			Warrior warrior = new Warrior(name, damage, hp);
			Warrior enemyWarrior = new Warrior("enemy", 50, 50);

			Assert.Throws<InvalidOperationException>(() =>
			{
				warrior.Attack(enemyWarrior);

			}, "Your HP is too low in order to attack other warriors!");
		}

		[TestCase(0)]
		[TestCase(MIN_ATTACK_HP / 2)]
		[TestCase(MIN_ATTACK_HP)]
		public void AttackMethodShouldThrowExceptionWhenEnemyHpLowerThanMinHP(int enemyHP)
		{
			Warrior warrior = new Warrior(name, damage, hp);
			Warrior enemyWarrior = new Warrior("enemy", 50, enemyHP);

			Assert.Throws<InvalidOperationException>(() =>
			{
				warrior.Attack(enemyWarrior);

			}, $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
		}


		[TestCase(51)]
		[TestCase(75)]
		[TestCase(150)]
		public void AttackMethodShouldThrowExceptionWhenHpLowerThanEnemyDamage(int enemyDamage)
		{
			Warrior warrior = new Warrior(name, damage, hp);
			Warrior enemyWarrior = new Warrior("enemy", enemyDamage, 100);

			Assert.Throws<InvalidOperationException>(() =>
			{
				warrior.Attack(enemyWarrior);

			}, "You are trying to attack too strong enemy");
		}

		[TestCase(100, 150)]
		[TestCase(150, 150)]
		public void AttackMethodShouldSetProperHPToWarriorAndEnemyWhenEnemyIsKilled(int damage, int hp)
		{
			Warrior warrior = new Warrior(name, damage, hp);
			Warrior enemyWarrior = new Warrior("enemy", 100, 100);

			warrior.Attack(enemyWarrior);

			Assert.AreEqual(50, warrior.HP);
			Assert.AreEqual(0, enemyWarrior.HP);
		}


		[TestCase(15, 75)]
		[TestCase(30, 150)]
		[TestCase(30, 50)]
		public void AttackMethodShouldSetProperHPToWarriorAndEnemyWhenEnemyNotKilled(int damage, int hp)
		{
			Warrior warrior = new Warrior(name, damage, hp);
			Warrior enemyWarrior = new Warrior("enemy", 50, 50);

			warrior.Attack(enemyWarrior);

			Assert.AreEqual(hp - 50, warrior.HP);
			Assert.AreEqual(50 - damage, enemyWarrior.HP);
		}
	}
}
