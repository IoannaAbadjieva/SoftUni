using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; private set; }

        public List<Pokemon> Pokemons { get; set; }

        public void CheckPokemon(string element)
        {
            if (Pokemons.Any(p => p.Element == element))
            {
                Badges++;
                return;
            }

            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemon pokemon = Pokemons[i];

                pokemon.Health -= 10;

                if (pokemon.Health <= 0)
                {
                    Pokemons.Remove(pokemon);
                }
            }
            
        }
    }
}
