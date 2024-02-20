namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        private int health;
        private int experience;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            health = 10;
            experience = 10;
            dummy = new Dummy(health, experience);
        }


        [Test]
        public void ConstructorShouldSetDataProperly()
        {
            //Assert
            Assert.That(dummy.Health, Is.EqualTo(health));
        }


        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            //Arange
            int attackPoints = 2;

            //act
            dummy.TakeAttack(attackPoints);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(health - attackPoints));

        }

        [Test]
        public void DummyShouldThrowExceptionWhenAttackedIfHealthIs0()
        {
            //Arange
            int attackPoints = 2;
            dummy.TakeAttack(health);

            Assert.Throws<InvalidOperationException>(() =>
            {
                //act 
                dummy.TakeAttack(attackPoints);
            },
            //Assert
            "Dummy is dead.");
        }

        [Test]
        public void DummyShouldThrowExceptionWhenAttackedIfHealthIsBelow0()
        {
            //Arange
            int attackPoints = 2;
            dummy.TakeAttack(health + 5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                //act 
                dummy.TakeAttack(attackPoints);
            },
            //Assert
            "Dummy is dead.");
        }

        [Test]
        public void DummyShouldGiveExperienceIfDead()
        {
            //Arrange
            Dummy dummy = new Dummy(0, experience);

            //Act & Assert
            Assert.That(dummy.GiveExperience(), Is.EqualTo(experience));
        }


        [Test]
        public void DummyShouldThrowWhenGiveExperienceIfNotDead()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                dummy.GiveExperience();
            },
             // Assert
             "Target is not dead.");
        }
    }
}