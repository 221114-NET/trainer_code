using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace consoleFE
{
    public class PokemonClass1
    {
        public PokemonClass1(string name, string color, int strength, int dexterity)
        {
            this.Name = name;
            this.Color = color;
            this.strength = strength;
            this.dexterity = dexterity;
        }

        [JsonPropertyName("name")]// use this to tell the runtime that hthe name in the incoming JSON string will be different
        public string Name { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        public int strength { get; set; }
        public int dexterity { get; set; }

    }
}