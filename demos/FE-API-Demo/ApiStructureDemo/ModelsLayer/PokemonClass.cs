using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class PokemonClass
    {
        public PokemonClass(string name, string color, int strength, int dexterity)
        {
            this.Name = name;
            Color = color;
            Strength = strength;
            Dexterity = dexterity;
        }

        public string Name { get; set; }
        public string Color { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }

    }
}