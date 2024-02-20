namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        private int attackPoints;
        private int durabilityPoints;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            attackPoints = 10;
            durabilityPoints = 10;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(20, 20);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            //Assert
            Assert.That(axe.AttackPoints, Is.EqualTo(attackPoints));
            Assert.That(axe.DurabilityPoints, Is.EqualTo(durabilityPoints));
        }

        [Test]
        public void AxeAttackShouldDecreaseDurabilityPointsProperly()
        {
            //act
            axe.Attack(dummy);
            axe.Attack(dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(durabilityPoints - 2));

        }

        [Test]
        public void AxeAttackShouldThrowDurabilityPointsAre0()
        {
            //Arange
            axe = new Axe(attackPoints, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                //Assert & Act
                axe.Attack(dummy);
            },
             //Assert
             "Axe is broken.");
        }

        [Test]
        public void AxeAttackShouldThrowDurabilityPointsAreNegative()
        {
            //Arange
            Axe axe = new Axe(attackPoints, -5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                //Assert & Act
                axe.Attack(dummy);
            },
            //Assert
            "Axe is broken.");
        }
    }
}