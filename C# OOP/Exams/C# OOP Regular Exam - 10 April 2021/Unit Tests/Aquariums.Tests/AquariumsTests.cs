namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium defAquarium;

        [SetUp]
        public void SetUp()
        {
            this.defAquarium = new Aquarium("NameOfAquarium", 4);
        }

        [Test]
        public void CtorShousdInitializeCollection()
        {
            Type defAquariumType = this.defAquarium.GetType();

            FieldInfo fieldInfo = defAquariumType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "fish");

            ICollection<Fish> list = (ICollection<Fish>)fieldInfo.GetValue(this.defAquarium);

            Assert.IsNotNull(list);
            Assert.That(list.Count, Is.EqualTo(0));

        }

        [TestCase("Some Name", 10)]
        [TestCase("Some  Other Name", 14)]
        public void CtorShousdSetValuesProperly(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.That(aquarium.Name, Is.EqualTo(name));
            Assert.That(aquarium.Capacity, Is.EqualTo(capacity));
        }

        [TestCase("")]
        [TestCase(null)]
        public void NameShouldThrowWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 5);

            });
        }

        [TestCase(-1)]
        [TestCase(-447)]
        public void CapacityShouldThrowWhenNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Some Name", capacity);

            }, "Invalid aquarium capacity!");
        }

        [Test]
        public void CountShouldReturnCorrectNumberOfItemsInCollection()
        {
            Fish fishOne = new Fish("something");
            Fish fishTwo = new Fish("something else");
            Fish fishThree = new Fish("something new");
            Fish fishFour = new Fish("something different");

            this.defAquarium.Add(fishOne);
            this.defAquarium.Add(fishTwo);
            this.defAquarium.Add(fishThree);
            this.defAquarium.Add(fishFour);

            Assert.That(this.defAquarium.Count, Is.EqualTo(4));

        }

        [Test]
        public void AddShouldAddsItemsToCollection()
        {
            Fish fishOne = new Fish("something");
            this.defAquarium.Add(fishOne);

            Type defAquariumType = this.defAquarium.GetType();

            FieldInfo fieldInfo = defAquariumType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "fish");

            ICollection<Fish> list = (ICollection<Fish>)fieldInfo.GetValue(this.defAquarium);

            Assert.IsTrue(list.Contains(fishOne));
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddShouldThrowWhenAddingMoreThenCapacity()
        {
            Fish fishOne = new Fish("something");
            Fish fishTwo = new Fish("something else");
            Fish fishThree = new Fish("something new");
            Fish fishFour = new Fish("something different");
            Fish fishFive = new Fish("something bad");

            this.defAquarium.Add(fishOne);
            this.defAquarium.Add(fishTwo);
            this.defAquarium.Add(fishThree);
            this.defAquarium.Add(fishFour);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defAquarium.Add(fishFive);
            }, "Aquarium is full!");
        }

        [Test]
        public void RemoveShouldRemovessItemsFromCollection()
        {
            Fish fishOne = new Fish("something");
            this.defAquarium.Add(fishOne);


            this.defAquarium.RemoveFish("something");

            Type defAquariumType = this.defAquarium.GetType();

            FieldInfo fieldInfo = defAquariumType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "fish");

            ICollection<Fish> list = (ICollection<Fish>)fieldInfo.GetValue(this.defAquarium);

            Assert.IsFalse(list.Contains(fishOne));
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void removeShouldThrowWhenRemovingUnexistingItem()
        {
            Fish fishOne = new Fish("something");
            Fish fishTwo = new Fish("something else");
            this.defAquarium.Add(fishOne);


            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defAquarium.RemoveFish("something else");
            }, $"Fish with the name {fishTwo.Name} doesn't exist!");
        }

        [Test]
        public void SellFishShouldThrowWhenSellingUnexistingItem()
        {
            Fish fishOne = new Fish("something");
            Fish fishTwo = new Fish("something else");
            this.defAquarium.Add(fishOne);


            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defAquarium.SellFish("something else");
            }, $"Fish with the name {fishTwo.Name} doesn't exist!");
        }

        [Test]
        public void SellFishShouldWorkProperly()
        {
            Fish fishOne = new Fish("something");
            Fish fishTwo = new Fish("something else");
            this.defAquarium.Add(fishOne);
            this.defAquarium.Add(fishTwo);

            Fish requestedFish = this.defAquarium.SellFish("something else");

            Assert.That(requestedFish, Is.EqualTo(fishTwo));
            Assert.That(fishTwo.Available, Is.False);

        }

        [Test]
        public void ReportShouldWorkProperlyWhenThereIsItemsInCollection()
        {
            Fish fishOne = new Fish("something");
            Fish fishTwo = new Fish("something else");
            this.defAquarium.Add(fishOne);
            this.defAquarium.Add(fishTwo);

            string expectedResult = $"Fish available at NameOfAquarium: something, something else";

            Assert.That(this.defAquarium.Report(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void ReportShouldWorkProperlyWhenNoItemsInCollection()
        {
            string expectedResult = $"Fish available at NameOfAquarium: ";

            Assert.That(this.defAquarium.Report(), Is.EqualTo(expectedResult));
        }
    }
}
