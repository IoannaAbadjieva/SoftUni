using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam defTeam;

        [SetUp]
        public void Setup()
        {
            this.defTeam = new FootballTeam("Team", 15);
        }

        [Test]
        public void CtorShouldInitializeCollection()
        {
            Type defTeamType = defTeam.GetType();
            FieldInfo field = defTeamType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "players");

            ICollection collection = (ICollection)field.GetValue(defTeam);

            Assert.IsNotNull(collection);
            Assert.That(collection.Count, Is.EqualTo(0));
        }

        [Test]
        public void CtorShouldSetValuesProperly()
        {
            Assert.That(defTeam.Name, Is.EqualTo("Team"));
            Assert.That(defTeam.Capacity, Is.EqualTo(15));
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameShouldThrowWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam footballTeam = new FootballTeam(name, 15);

            }, "Name cannot be null or empty!");
        }

        [TestCase(14)]
        [TestCase(-2)]
        [TestCase(0)]
        public void CapacityShouldThrowWhenBellow15(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam footballTeam = new FootballTeam("team", capacity);

            }, "Capacity min value = 15");
        }

        [Test]
        public void PlayerShouldReturnCollection()
        {
            FootballPlayer playerOne = new FootballPlayer("PlayerOne", 1, "Goalkeeper");
            FootballPlayer playerTwo = new FootballPlayer("PlayerTwo", 2, "Midfielder");
            this.defTeam.AddNewPlayer(playerOne);
            this.defTeam.AddNewPlayer(playerTwo);

            Type defTeamtype = defTeam.GetType();
            FieldInfo field = defTeamtype.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "players");
            List<FootballPlayer> collection = (List<FootballPlayer>)field.GetValue(this.defTeam);

            CollectionAssert.AreEqual(this.defTeam.Players, collection);
        }

        [Test]
        public void AddPlayerShouldAddPlayersToCollection()
        {
            FootballPlayer playerOne = new FootballPlayer("PlayerOne", 1, "Goalkeeper");
            FootballPlayer playerTwo = new FootballPlayer("PlayerTwo", 2, "Midfielder");
            this.defTeam.AddNewPlayer(playerOne);
            this.defTeam.AddNewPlayer(playerTwo);

            Type defTeamtype = defTeam.GetType();
            FieldInfo field = defTeamtype.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "players");
            List<FootballPlayer> collection = (List<FootballPlayer>)field.GetValue(this.defTeam);

            Assert.IsTrue(collection.Contains(playerOne));
            Assert.IsTrue(collection.Contains(playerTwo));
            Assert.That(collection.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddNewPlayerShouldThrowWhenOverCapacity()
        {
            for (int i = 1; i <= 15; i++)
            {
                this.defTeam.AddNewPlayer(new FootballPlayer($"player{i}", i, "Goalkeeper"));
            }

            string expected = "No more positions available!";
            string actual = this.defTeam.AddNewPlayer(new FootballPlayer("player16", 16, "Goalkeeper"));


            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void AddNewPlayerShouldReturnProperMessage()
        {
            FootballPlayer playerOne = new FootballPlayer("PlayerOne", 1, "Goalkeeper");

            string expected = $"Added player {playerOne.Name} in position {playerOne.Position} with number {playerOne.PlayerNumber}";
            string actual = this.defTeam.AddNewPlayer(playerOne);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PickPlayerShouldReturnProperPlayerWhenExist()
        {
            FootballPlayer playerOne = new FootballPlayer("PlayerOne", 1, "Goalkeeper");
            FootballPlayer playerTwo = new FootballPlayer("PlayerTwo", 2, "Midfielder");
            this.defTeam.AddNewPlayer(playerOne);
            this.defTeam.AddNewPlayer(playerTwo);

            FootballPlayer player = this.defTeam.PickPlayer("PlayerOne");

            Assert.That(player, Is.EqualTo(playerOne));
        }

        [Test]
        public void PickPlayerShouldReturnProperPlayerWhenDoesNotExist()
        {
            FootballPlayer playerOne = new FootballPlayer("PlayerOne", 1, "Goalkeeper");
            FootballPlayer playerTwo = new FootballPlayer("PlayerTwo", 2, "Midfielder");
            this.defTeam.AddNewPlayer(playerOne);
            

            FootballPlayer player = this.defTeam.PickPlayer("Playertwo");

            Assert.That(player, Is.EqualTo(null));
        }

        [Test]
        public void PlayerScoreShouldWorkWhenPlayerExist()
        {
            FootballPlayer playerOne = new FootballPlayer("PlayerOne", 1, "Goalkeeper");
            this.defTeam.AddNewPlayer(playerOne);

            string expected = $"PlayerOne scored and now has 1 for this season!";
            string actual = this.defTeam.PlayerScore(1);

            Assert.That(actual, Is.EqualTo(expected));
        }
       
    }
}