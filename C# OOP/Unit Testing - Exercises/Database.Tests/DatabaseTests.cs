namespace Database.Tests
{
	using NUnit.Framework;

	using System;

	[TestFixture]
	public class DatabaseTests
	{
		private Database database;

		[SetUp]
		public void SetUp()
		{
			this.database = new Database();
		}

		[TestCase(new int[] { })]
		[TestCase(new int[] { 1, 2, 3, 4, 5 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
		public void ConstructorShouldInitializeDataWithCorrectCount(int[] data)
		{
			Database db = new Database(data);
			Assert.That(db.Count, Is.EqualTo(data.Length));
		}

		[TestCase(new int[] { })]
		[TestCase(new int[] { 1, 2, 3, 4, 5 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, })]
		public void ConstructorShouldInitializeDataWithCorrectValues(int[] data)
		{
			Database db = new Database(data);
			CollectionAssert.AreEqual(data, db.Fetch());
		}

		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
		public void ConstructorShouldThrowExcpetionWhenInputDataIsAbove16Count(int[] data)
		{
			Assert.Throws<InvalidOperationException>(() =>
			{
				Database db = new Database(data);
			}, "Array's capacity must be exactly 16 integers!");
		}

		[TestCase(new int[] { })]
		[TestCase(new int[] { 1, 2, 3, 4, 5 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, })]
		public void CountShouldReturnProperNumberOfElements(int[] data)
		{
			Database db = new Database(data);
			Assert.That(db.Count, Is.EqualTo(data.Length));
		}

		[Test]
		public void AddMethodShouldAddElementsToDataCollection()
		{
			for (int i = 1; i <= 4; i++)
			{
				this.database.Add(i);
			}

			CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, this.database.Fetch());
		}


		[Test]
		public void AddMethodShouldIncreaseCount()
		{
			for (int i = 1; i <= 4; i++)
			{
				this.database.Add(i);
			}

			Assert.That(this.database.Count, Is.EqualTo(4));
		}

		[Test]
		public void AddMethodShouldThrowExceptionWhenAddingMoreThan16Elements()
		{
			for (int i = 1; i <= 16; i++)
			{
				this.database.Add(i);
			}

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.database.Add(17);
			}, "Array's capacity must be exactly 16 integers!");
		}

		[Test]
		public void RemoveMethodShouldRemoveElementsFromDataCollection()
		{
			for (int i = 1; i <= 4; i++)
			{
				this.database.Add(i);
			}

			for (int i = 1; i <= 2; i++)
			{
				this.database.Remove();
			}

			CollectionAssert.AreEqual(new[] { 1, 2 }, this.database.Fetch());
		}

		[Test]
		public void RemoveMethodShouldDecreaseCount()
		{
			for (int i = 1; i <= 4; i++)
			{
				this.database.Add(i);
			}

			for (int i = 1; i <= 2; i++)
			{
				this.database.Remove();
			}

			Assert.That(this.database.Count, Is.EqualTo(2));
		}


		[Test]
		public void RemoveMethodShouldThrowExceptionWhenCountIsZero()
		{
			Assert.Throws<InvalidOperationException>(() =>
			{
				this.database.Remove();
			}, "The collection is empty!");
		}

		[TestCase(new int[] { })]
		[TestCase(new int[] { 1, 2, 3, 4, 5 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
		public void FetchShouldReturnCollectionWithElementsInTheDb(int[] data)
		{
			Database db = new Database(data);
			CollectionAssert.AreEqual(data, db.Fetch());
		}
	}
}
