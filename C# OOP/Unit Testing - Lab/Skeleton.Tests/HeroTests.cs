namespace Skeleton.Tests
{
    using Skeleton;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void GainExperienceWhentargetIsDead()
        {
            Mock<ITarget> target = new Mock<ITarget>();
            target.Setup(t => t.IsDead()).Returns(true);
            target.Setup(t => t.GiveExperience()).Returns(50);

            Mock<IWeapon> weapon = new Mock<IWeapon>();

            Hero hero = new Hero("SomeMagnifficientero",weapon.Object);

            hero.Attack(target.Object);

            Assert.That(hero.Experience, Is.EqualTo(50));

        }

    }
}
