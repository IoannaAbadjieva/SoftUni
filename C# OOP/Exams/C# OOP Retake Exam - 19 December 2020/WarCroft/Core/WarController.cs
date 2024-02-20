using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Item> pool;
        private ICollection<Character> party;

        public WarController()
        {
            this.pool = new List<Item>();
            this.party = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = characterType switch
            {
                nameof(Warrior) => new Warrior(name),
                nameof(Priest) => new Priest(name),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType))
            };
            this.party.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = itemName switch
            {
                nameof(FirePotion) => new FirePotion(),
                nameof(HealthPotion) => new HealthPotion(),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName))
            };

            this.pool.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.party.FirstOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = this.pool.LastOrDefault();
            if (item == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }

            character.Bag.AddItem(item);
            this.pool.Remove(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.party.FirstOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            character.UseItem(character.Bag.GetItem(itemName));
            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            List<Character> orderedCharacters = this.party
                .OrderByDescending(ch => ch.IsAlive)
                .ThenByDescending(ch => ch.Health)
                .ToList();

            foreach (Character character in orderedCharacters)
            {
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth,
                    character.Armor, character.BaseArmor, (character.IsAlive ? "Alive" : " Dead")));
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.party.FirstOrDefault(a => a.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            Character receiver = this.party.FirstOrDefault(r => r.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            Warrior warrior = attacker as Warrior;

            if (warrior == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            warrior.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints,
                    receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (receiver.Health == 0)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.party.FirstOrDefault(a => a.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            Character receiver = this.party.FirstOrDefault(r => r.Name == healingReceiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            Priest priest = healer as Priest;
            if (priest == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            priest.Heal(receiver);

            return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints,
                receiver.Name, receiver.Health);
        }
    }
}
