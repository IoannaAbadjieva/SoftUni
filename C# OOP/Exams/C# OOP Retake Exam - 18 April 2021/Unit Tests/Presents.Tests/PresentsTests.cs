namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class PresentsTests
    {

        private Bag defBag;

        [SetUp]
        public void SetUp()
        {
            this.defBag = new Bag();
        }

        [Test]
        public void CtorShouldInitializeCollection()
        {
            Type defBagType = this.defBag.GetType();
            FieldInfo fieldinfo = defBagType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "presents");

            ICollection<Present> collection = (ICollection<Present>)fieldinfo.GetValue(defBag);

            Assert.IsNotNull(collection);
            Assert.That(collection.Count, Is.EqualTo(0));
        }

        [Test]
        public void CreateShouldAddPresentToCollection()
        {
            Present present = new Present("SomeName", 12.5);
            this.defBag.Create(present);

            Type defBagType = this.defBag.GetType();
            FieldInfo fieldinfo = defBagType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "presents");

            ICollection<Present> collection = (ICollection<Present>)fieldinfo.GetValue(defBag);
            Assert.IsTrue(collection.Contains(present));
            Assert.IsTrue(collection.Count == 1);
        }

        [Test]
        public void CreateShouldreturnProperMessage()
        {
            Present present = new Present("SomeName", 12.5);

            Assert.That(this.defBag.Create(present), Is.EqualTo("Successfully added present SomeName."));
        }

        [Test]
        public void CreateShouldThrowWhenPresentIsNull()
        {
            Present present = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.defBag.Create(present);

            });
        }

        [Test]
        public void CreateShouldThrowWhenPresentAlreadyAdded()
        {
            Present present = new Present("SomeName", 12.5);
            this.defBag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defBag.Create(present);

            }, "This present already exists!");
        }

        [Test]
        public void RemoveShouldReturnProperValueIfPresentExist()
        {
            Present present = new Present("SomeName", 12.5);
            this.defBag.Create(present);

            bool result = this.defBag.Remove(present);

            Assert.That(result, Is.True);
        }


        [Test]
        public void RemoveShouldReturnProperValueIfPresentDoesNotExist()
        {
            Present presentOne = new Present("SomeName", 12.5);
            Present presentTwo = new Present("Some Other Name", 52.5);
            this.defBag.Create(presentOne);

            bool result = this.defBag.Remove(presentTwo);

            Assert.That(result, Is.False);
        }

        [Test]
        public void RemoveShouldRemovePresentFromCollection()
        {
            Present presentOne = new Present("SomeName", 12.5);
            Present presentTwo = new Present("Some Other Name", 52.5);
            this.defBag.Create(presentOne);
            this.defBag.Create(presentTwo);

            this.defBag.Remove(presentTwo);

            Type defBagType = this.defBag.GetType();
            FieldInfo fieldinfo = defBagType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "presents");

            ICollection<Present> collection = (ICollection<Present>)fieldinfo.GetValue(defBag);

            Assert.IsFalse(collection.Contains(presentTwo));
            Assert.That(collection.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetPresentWithLeastMagicShousdWorkProperly()
        {
            Present presentOne = new Present("SomeName", 12.5);
            Present presentTwo = new Present("Some Other Name", 52.5);
            this.defBag.Create(presentOne);
            this.defBag.Create(presentTwo);

            Present resultPresent = this.defBag.GetPresentWithLeastMagic();

            Assert.That(resultPresent,Is.EqualTo(presentOne));
        }

        [Test]
        public void GetPresentShousdWorkProperly()
        {
            Present presentOne = new Present("SomeName", 12.5);
            Present presentTwo = new Present("Some Other Name", 52.5);
            this.defBag.Create(presentOne);
            this.defBag.Create(presentTwo);

            Present resultPresent = this.defBag.GetPresent("SomeName");

            Assert.That(resultPresent, Is.EqualTo(presentOne));
        }

        [Test]
        public void GetPresentsShouldWorkProperly()
        {
            Present presentOne = new Present("SomeName", 12.5);
            Present presentTwo = new Present("Some Other Name", 52.5);
            this.defBag.Create(presentOne);
            this.defBag.Create(presentTwo);

            Type defBagType = this.defBag.GetType();
            FieldInfo fieldinfo = defBagType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "presents");

            ICollection<Present> expectedCollection = (ICollection<Present>)fieldinfo.GetValue(defBag);
            var actualCollection = this.defBag.GetPresents();

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }
    }
}
