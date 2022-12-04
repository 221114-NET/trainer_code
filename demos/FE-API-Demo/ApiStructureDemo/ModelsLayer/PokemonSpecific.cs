using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class PokemonSpecific : PokemonClass
    {
        public PokemonSpecific(string pokemonType, string name, string color, int strength, int dexterity) : base(name, color, strength, dexterity)
        {
            PokemonType = pokemonType;
        }

        public string PokemonType { get; set; }// fire, water, air, land, 

        public string SayMyNamePokemon()
        {
            return $"Hi. Mee-sa named {this.Name}.\nI's is {this.Color}.\nMy strength is {this.Strength}";
        }

    }
}