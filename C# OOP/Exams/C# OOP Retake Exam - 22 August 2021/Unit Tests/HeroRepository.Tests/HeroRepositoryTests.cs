using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
	private HeroRepository heroRepository;

	[SetUp]
	public void SetUp()
	{
		this.heroRepository = new HeroRepository();
	}

	[Test]
	public void CtorShouldInitializeCollection()
	{
		Assert.IsNotNull(this.heroRepository.Heroes);
		Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(0));
	}

	[Test]
	public void CreateHeroShouldAddDataToCollection()
	{
		Hero hero = new Hero("hero name", 7);
		this.heroRepository.Create(hero);

		Assert.IsTrue(this.heroRepository.Heroes.Contains(hero));
		Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(1));
	}

	[Test]
	public void CreateHeroShouldThrowWhenAddingHeroWithSameName()
	{
		Hero hero = new Hero("hero name", 7);
		this.heroRepository.Create(hero);

		Assert.Throws<InvalidOperationException>(() =>
		{
			this.heroRepository.Create(hero);
		}, $"Hero with name {hero.Name} already exists");
	}

	[Test]
	public void CreateHeroShouldThrowWhenHeroIsNull()
	{
		Hero hero = null;

		Assert.Throws<ArgumentNullException>(() =>
		{
			this.heroRepository.Create(hero);
		});
	}

	[Test]
	public void RemoveShouldWorkProperlyWhenHeroExist()
	{
		Hero firstHero = new Hero("hero name", 7);
		Hero secondHero = new Hero("second hero name", 4);
		Hero thirdHero = new Hero("thirdd hero name", 2);
		this.heroRepository.Create(firstHero);
		this.heroRepository.Create(secondHero);
		this.heroRepository.Create(thirdHero);

		bool result = this.heroRepository.Remove("hero name");

		Assert.That(result, Is.True);
		Assert.IsFalse(this.heroRepository.Heroes.Contains(firstHero));
		Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(2));
	}

	[Test]
	public void RemoveShouldWorkProperlyWhenHeroDoesNotExist()
	{
		Hero firstHero = new Hero("hero name", 7);
		Hero secondHero = new Hero("second hero name", 4);
		Hero thirdHero = new Hero("thirdd hero name", 2);
		this.heroRepository.Create(firstHero);
		this.heroRepository.Create(secondHero);
		this.heroRepository.Create(thirdHero);

		bool result = this.heroRepository.Remove("other hero name");

		Assert.That(result, Is.False);
		Assert.That(this.heroRepository.Heroes.Count, Is.EqualTo(3));
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("    ")]
	public void RemoveShouldThrowWhenNameIsNullOrEmptyOrWhitespace(string name)
	{
		Hero hero = new Hero("hero name", 7);
		this.heroRepository.Create(hero);

		Assert.Throws<ArgumentNullException>(() =>
		{
			this.heroRepository.Remove(name);
		});
	}

	[Test]
	public void GetHeroWithHighestLevelShouldWorkProperlyWhenHeroesInRepository()
	{
		Hero firstHero = new Hero("hero name", 7);
		Hero secondHero = new Hero("second hero name", 4);
		Hero thirdHero = new Hero("thirdd hero name", 2);
		this.heroRepository.Create(firstHero);
		this.heroRepository.Create(secondHero);
		this.heroRepository.Create(thirdHero);


		Assert.That(this.heroRepository.GetHeroWithHighestLevel, Is.EqualTo(firstHero));
	}

	[Test]
	public void GetHeroShouldWorkProperlyWhenHeroExist()
	{
		Hero firstHero = new Hero("hero name", 7);
		Hero secondHero = new Hero("second hero name", 4);
		Hero thirdHero = new Hero("thirdd hero name", 2);
		this.heroRepository.Create(firstHero);
		this.heroRepository.Create(secondHero);
		this.heroRepository.Create(thirdHero);

		Assert.That(this.heroRepository.GetHero("hero name"), Is.EqualTo(firstHero));
	}

	[Test]
	public void GetHeroShouldWorkProperlyWhenCollectionNotEmptyButNoSuchHero()
	{
		Hero firstHero = new Hero("hero name", 7);
		Hero secondHero = new Hero("second hero name", 4);
		Hero thirdHero = new Hero("thirdd hero name", 2);
		this.heroRepository.Create(firstHero);
		this.heroRepository.Create(secondHero);
		this.heroRepository.Create(thirdHero);

		Assert.That(this.heroRepository.GetHero("some other hero name"), Is.EqualTo(null));
	}

	[Test]
	public void GetHeroShouldWorkProperlyWhenCollectionIsEmpty()
	{
		Hero firstHero = new Hero("hero name", 7);
		Hero secondHero = new Hero("second hero name", 4);
		Hero thirdHero = new Hero("thirdd hero name", 2);

		Assert.That(this.heroRepository.GetHero("some hero name"), Is.EqualTo(null));
	}


}