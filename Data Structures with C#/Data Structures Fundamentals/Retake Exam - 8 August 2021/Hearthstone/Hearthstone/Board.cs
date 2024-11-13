namespace Hearthstone
{
	using System;
	using System.Collections.Generic;
    
	public class Board : IBoard
	{
		private Dictionary<string, Card> cards = new Dictionary<string, Card>();
		private Dictionary<string, Card> cardsByHealth = new Dictionary<string, Card>();


		public bool Contains(string name)
		{
			return this.cards.ContainsKey(name);
		}

		public int Count()
		{
			return this.cards.Count;
		}

		public void Draw(Card card)
		{
			if (this.cards.ContainsKey(card.Name))
			{
				throw new ArgumentException();
			}

			this.cards.Add(card.Name, card);
			
		}

		public IEnumerable<Card> GetBestInRange(int start, int end)
		{
			return this.cards.Values
				.Where(c => c.Score >= start && c.Score <= end)
				.OrderByDescending(c => c.Level);
		}

		public void Heal(int health)
		{
			var card = this.cards.Values
				.OrderBy(c => c.Health)
				.Take(1)
				.FirstOrDefault();


			if (card != null)
			{
				card.Health += health;
			}
		}

		public IEnumerable<Card> ListCardsByPrefix(string prefix)
		{
			return this.cards.Values
				.Where(c => c.Name.StartsWith(prefix))
				.OrderBy(c => new string(c.Name.Reverse().ToArray()))
				.ThenBy(c => c.Level)
				;
		}

		public void Play(string attackerCardName, string attackedCardName)
		{
			if (!this.cards.ContainsKey(attackerCardName) || !this.cards.ContainsKey(attackedCardName))
			{
				throw new ArgumentException();
			}

			var attacker = this.cards[attackerCardName];
			var attacked = this.cards[attackedCardName];


			if (attacker.Level != attacked.Level)
			{
				throw new ArgumentException();
			}

			if (attacked.Health <= 0)
			{
				return;

			}
			attacked.Health -= attacker.Damage;

			if (attacked.Health <= 0)
			{
				attacker.Score += attacked.Level;
				this.cardsByHealth.Add(attacked.Name, attacked);
			}

		}

		public void Remove(string name)
		{
			if (!this.cards.ContainsKey(name))
			{
				throw new ArgumentException();
			}

			this.cards.Remove(name);

			if (this.cardsByHealth.ContainsKey(name))
			{
				this.cardsByHealth.Remove(name);
			}

		}

		public void RemoveDeath()
		{
			foreach (var cardName in this.cardsByHealth.Keys)
			{
				this.cards.Remove(cardName);
			}

			this.cardsByHealth.Clear();
		}

		public IEnumerable<Card> SearchByLevel(int level)
		{
			return this.cards.Values
				.Where(c => c.Level == level)
				.OrderByDescending(c => c.Score);
		}
	}
}
