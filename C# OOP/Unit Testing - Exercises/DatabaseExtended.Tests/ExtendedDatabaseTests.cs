namespace DatabaseExtended.Tests
{
	using System;

	using NUnit.Framework;

	using ExtendedDatabase;


	[TestFixture]
	public class ExtendedDatabaseTests
	{

		[Test]
		public void ConstructorShouldInitializePersonCollection()
		{
			Person[] persons = new Person[] { new Person(1, "someUsername"), new Person(2, "someOtherUsername") };
			Database ctorDatabase = new Database(persons);

			Assert.IsNotNull(ctorDatabase);
		}


		[Test]
		public void ConstructorShouldAddDataToCollection()
		{
			Person[] persons = new Person[] { new Person(1, "someUsername"), new Person(2, "someOtherUsername") };
			Database ctorDatabase = new Database(persons);

			Assert.IsNotNull(ctorDatabase.FindByUsername("someUsername"));
		}

		[Test]
		public void ConstructorShouldThrowExceptionWhenInitializePersonCollectionWithMoreThan16Count()
		{
			Person[] persons = new Person[17];
			for (int i = 0; i < persons.Length; i++)
			{
				persons[i] = new Person(i + 1, $"{i}name");
			}

			Assert.Throws<ArgumentException>(() =>
			{
				Database ctorDatabase = new Database(persons);
			}, "Provided data length should be in range [0..16]!");

		}

		[Test]
		public void CountSholdReturnCorrectNumberOfPersonsInCollection()
		{
			Person[] persons = new Person[] { new Person(1, "someUsername"), new Person(2, "someOtherUsername") };
			Database ctorDatabase = new Database(persons);

			Assert.That(ctorDatabase.Count, Is.EqualTo(persons.Length));
		}

		[Test]
		public void AddMethodShouldAddPersonsToCollection()
		{
			Database database = new Database();
			database.Add(new Person(1, "someUsername"));

			Assert.IsNotNull(database.FindById(1));
		}

		[Test]
		public void AddMethodShouldIncreaseCount()
		{
			Database database = new Database();
			database.Add(new Person(1, "someUsername"));

			Assert.That(database.Count, Is.EqualTo(1));
		}

		[Test]
		public void AddMethodShouldThrowExceptionIfCollectionCountIs16()
		{
			Person[] persons = new Person[16];
			for (int i = 0; i < persons.Length; i++)
			{
				persons[i] = new Person(i + 1, $"{i}name");
			}

			Database database = new Database(persons);

			Assert.Throws<InvalidOperationException>(() =>
			{
				database.Add(new Person(17, "someUsername"));
			}, "Array's capacity must be exactly 16 integers!");

		}

		[Test]
		public void AddMethodShouldThrowExceptionIfAddingPersonWithSameName()
		{
			Person[] persons = new Person[] { new Person(1, "someUsername"), new Person(2, "someOtherUsername") };
			Database database = new Database(persons);

			Assert.Throws<InvalidOperationException>(() =>
			{
				database.Add(new Person(3, "someUsername"));
			}, "There is already user with this username!");

		}

		[Test]
		public void AddMethodShouldThrowExceptionIfAddingPersonWithSameID()
		{
			Person[] persons = new Person[] { new Person(1, "someUsername"), new Person(2, "someOtherUsername") };
			Database database = new Database(persons);

			Assert.Throws<InvalidOperationException>(() =>
			{
				database.Add(new Person(1, "someDifferentUsername"));
			}, "There is already user with this Id!");

		}

		[Test]
		public void RemoveMethodShouldRemovePersonsFromCollection()
		{
			Database database = new Database();
			database.Add(new Person(1, "someUsername"));
			database.Add(new Person(2, "someOtherUsername"));

			database.Remove();

			Assert.Throws<InvalidOperationException>(() =>
			{
				database.FindById(2);
			}, "No user is present by this ID!");
		}

		[Test]
		public void RemoveMethodShouldDecreaseCount()
		{
			Database database = new Database();
			database.Add(new Person(1, "someUsername"));
			database.Add(new Person(2, "someOtherUsername"));

			database.Remove();

			Assert.That(database.Count, Is.EqualTo(1));
		}

		[Test]
		public void RemoveMethodShouldThrowExceptionWhenNoPersonsInCollection()
		{
			Database database = new Database();

			Assert.Throws<InvalidOperationException>(() =>
			{
				database.Remove();
			});
		}

		[Test]
		public void FindByNameMethodShouldShouldReturnExactPerson()
		{
			Person firstPersons = new Person(1, "someUsername");
			Person secondPersons = new Person(2, "someOtherUsername");
			Database database = new Database();
			database.Add(firstPersons);
			database.Add(secondPersons);

			Person searchedPerson = database.FindByUsername("someUsername");

			Assert.That(searchedPerson, Is.EqualTo(firstPersons));
		}

		[TestCase(null)]
		[TestCase("")]
		public void FindByNameMethodShouldThrowExceptionWhenNameIsNullOrEmpty(string name)
		{
			Person[] persons = new Person[] { new Person(1, "someUsername"), new Person(2, "someOtherUsername") };
			Database database = new Database(persons);

			Assert.Throws<ArgumentNullException>(() =>
			{
				database.FindByUsername(name);
			}, "Username parameter is null!");
		}


		[Test]
		public void FindByNameMethodShouldThrowExceptionWhenNameDoesNotExist()
		{
			Person[] persons = new Person[] { new Person(1, "someUsername"), new Person(2, "someOtherUsername") };
			Database database = new Database(persons);

			Assert.Throws<InvalidOperationException>(() =>
			{
				database.FindByUsername("someDifferentUsername");
			}, "No user is present by this username!");
		}

		[Test]
		public void FindByIdMethodShouldShouldReturnExactPerson()
		{
			Person firstPersons = new Person(1, "someUsername");
			Person secondPersons = new Person(2, "someOtherUsername");
			Database database = new Database();
			database.Add(firstPersons);
			database.Add(secondPersons);

			Person searchedPerson = database.FindById(2);

			Assert.That(searchedPerson, Is.EqualTo(secondPersons));
		}

		[TestCase(-1)]
		[TestCase(-357)]
		public void FindByIdMethodShouldThrowExceptionWhenIdIsNegative(int id)
		{
			Person[] persons = new Person[] { new Person(1, "someUsername"), new Person(2, "someOtherUsername") };
			Database database = new Database(persons);

			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				database.FindById(id);
			}, "Id should be a positive number!");
		}

	}


}