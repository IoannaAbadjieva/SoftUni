namespace Book.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using NUnit.Framework;

	[TestFixture]
	public class Tests
	{
		private Book defBook;

		[SetUp]
		public void SetUp()
		{
			this.defBook = new Book("Some bookName", "Some Author");
		}

		[Test]
		public void CtorShouldInitializeCollection()
		{
			Type defBookType = this.defBook.GetType();
			FieldInfo fieldInfo = defBookType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.FirstOrDefault(fi => fi.Name == "footnote");

			var dict = fieldInfo.GetValue(defBook);

			Assert.IsNotNull(dict);
			Assert.That(this.defBook.FootnoteCount, Is.EqualTo(0));
		}

		[Test]
		public void CtorShouldSetValuesProperly()
		{
			Book book = new Book("Some Other Name", "Some Other Author");
			Assert.That(book.BookName, Is.EqualTo("Some Other Name"));
			Assert.That(book.Author, Is.EqualTo("Some Other Author"));
		}

		[TestCase(null)]
		[TestCase("")]
		public void BookNameShouldThrowWhenNullOrEmpty(string bookName)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				Book book = new Book(bookName, "Author");
			}, $"Invalid BookName!");
		}


		[TestCase(null)]
		[TestCase("")]
		public void AuthorShouldThrowWhenNullOrEmpty(string author)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				Book book = new Book("Something", author);
			}, $"Invalid Author!");
		}

		[Test]
		public void FootnoteCountShouldReturnProperCount()
		{
			this.defBook.AddFootnote(1, "1");
			this.defBook.AddFootnote(2, "2");

			Assert.That(this.defBook.FootnoteCount, Is.EqualTo(2));
		}

		[Test]
		public void AddFootnoteShouldThrowWhenKeyExist()
		{
			this.defBook.AddFootnote(1, "1");

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.defBook.AddFootnote(1, "1");
			}, "Footnote already exists!");
		}

		[Test]
		public void AddFootnoteShouldAddFootnoteToCollection()
		{
			this.defBook.AddFootnote(1, "1");

			Type defBookType = this.defBook.GetType();
			FieldInfo fieldInfo = defBookType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.FirstOrDefault(fi => fi.Name == "footnote");

			Dictionary<int, string> dict = (Dictionary<int, string>)fieldInfo.GetValue(defBook);

			Assert.IsTrue(dict.ContainsKey(1));
			Assert.That(dict[1], Is.EqualTo("1"));
		}

		[Test]
		public void AddFootnoteShouldIncreaseCount()
		{
			this.defBook.AddFootnote(1, "1");

			Assert.That(this.defBook.FootnoteCount, Is.EqualTo(1));
		}

		[Test]
		public void FindFootnoteShouldThrowWhenKeyDoesNotExist()
		{
			this.defBook.AddFootnote(1, "1");
			this.defBook.AddFootnote(2, "2");

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.defBook.FindFootnote(55);
			}, "Footnote doesn't exists!");
		}

		[Test]
		public void FindFootnoteShouldReturnProperValue()
		{
			this.defBook.AddFootnote(1, "someFootnote");

			Assert.That(this.defBook.FindFootnote(1), Is.EqualTo("Footnote #1: someFootnote"));
		}

		[Test]
		public void FindFootnoteShouldThrowWhenNoFootnotes()
		{
			Assert.Throws<InvalidOperationException>(() =>
			{
				this.defBook.FindFootnote(1);
			}, "Footnote doesn't exists!");
		}

		[Test]
		public void AlterFootnoteShouldThrowWhenNoFootnotes()
		{
			this.defBook.AddFootnote(1, "1");
			this.defBook.AddFootnote(2, "2");

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.defBook.AlterFootnote(55, "replacement");
			}, "Footnote doesn't exists!");
		}

		[Test]
		public void AlterFootnoteShouldThrowWhenKeyDoesNotExist()
		{

			Assert.Throws<InvalidOperationException>(() =>
			{
				this.defBook.AlterFootnote(1, "replacement");
			}, "Footnote doesn't exists!");
		}

		[Test]
		public void AlterFootnoteShouldChangeFootnote()
		{
			this.defBook.AddFootnote(1, "one");
			this.defBook.AlterFootnote(1, "something");

			Type defBookType = this.defBook.GetType();
			FieldInfo fieldInfo = defBookType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.FirstOrDefault(fi => fi.Name == "footnote");

			Dictionary<int, string> dict = (Dictionary<int, string>)fieldInfo.GetValue(this.defBook);


			Assert.That(dict[1], Is.EqualTo("something"));
		}
	}
}