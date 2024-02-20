namespace FightingArena.Tests
{
	using System;
	using System.Linq;

	using NUnit.Framework;

	[TestFixture]
	public class ArenaTests
	{
		private Arena arena;

		[SetUp]
		public void SetUp()
		{
			this.arena = new Arena();
		}

		[Test]
		public void ConstructorShouldInitializeCollectionOfWarriors()
		{
			Arena ctorArena = new Arena();
			Assert.IsNotNull(ctorArena);
		}

		[Test]
		public void EnrollMethodShouldAddWarriorsToCollection()
		{
			Warrior attacker = new Warrior("attacker", 50, 50);
			this.arena.Enroll(attacker);

			Assert.IsTrue(this.arena.Warriors.Contains(attacker));
		}

		[Test]
		public void EnrollMethodShouldThrowExceptionWhenSameWarriorIsEnrolled()
		{
			Warrior attacker = new Warrior("attacker", 50, 50);
			this.arena.Enroll(attacker);

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.arena.Enroll(attacker);
			}, "Warrior is already enrolled for the fights!");
		}

		[Test]
		public void EnrollMethodShouldThrowExceptionWhenWarriorWithSameNameIsEnrolled()
		{
			Warrior attacker = new Warrior("attacker", 50, 50);
			Warrior defender = new Warrior("attacker", 35, 50);
			this.arena.Enroll(attacker);

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.arena.Enroll(defender);
			}, "Warrior is already enrolled for the fights!");
		}

		[Test]
		public void CountShouldReturnProperNumberOfWarriorsInCollection()
		{

			Warrior attacker = new Warrior("attacker", 50, 50);
			Warrior defender = new Warrior("defender", 35, 50);

			this.arena.Enroll(attacker);
			this.arena.Enroll(defender);

			Assert.AreEqual(2, this.arena.Count);
		}

		[Test]
		public void FightMethodShouldThrowExceptionWhenAttackerDoesNotExist()
		{
			Warrior attacker = new Warrior("attacker", 50, 50);
			Warrior defender = new Warrior("defender", 35, 50);

			this.arena.Enroll(defender);

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.arena.Fight(attacker.Name, defender.Name);
			}, $"There is no fighter with name {attacker.Name} enrolled for the fights!");
		}

		[Test]
		public void FightMethodShouldThrowExceptionWhenDefenderDoesNotExist()
		{
			Warrior attacker = new Warrior("attacker", 50, 50);
			Warrior defender = new Warrior("defender", 35, 50);

			this.arena.Enroll(attacker);

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.arena.Fight(attacker.Name, defender.Name);
			}, $"There is no fighter with name {defender.Name} enrolled for the fights!");
		}

		[Test]
		public void FightMethodShouldSetHPProperly()
		{
			Warrior attacker = new Warrior("attacker", 50, 100);
			Warrior defender = new Warrior("defender", 35, 100);

			this.arena.Enroll(attacker);
			this.arena.Enroll(defender);

			this.arena.Fight(attacker.Name, defender.Name);

			Assert.AreEqual(65, attacker.HP);
			Assert.AreEqual(50, defender.HP);
		}
	}
}
