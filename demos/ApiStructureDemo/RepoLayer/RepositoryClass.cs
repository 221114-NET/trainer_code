using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ModelsLayer;

namespace RepoLayer
{
    public interface IRepositoryClass
    {
        PokemonClass PostPokemon(PokemonClass p);
    }

    public class RepositoryClass : IRepositoryClass
    {

        //Giving it a Logger
        private readonly IMyLogger _logger;

        public RepositoryClass(IMyLogger logger){
            _logger = logger;
        }

        public PokemonClass PostPokemon(PokemonClass p)
        {
            p.Dexterity = 100;
            if (File.Exists("PokemonList.json"))
            {
                string oldPlist = File.ReadAllText("PokemonList.json");

                // do the file saving
                List<PokemonClass> plist = JsonSerializer.Deserialize<List<PokemonClass>>(oldPlist)!;// the ! is to permanently denot tht I know it may be a null value

                plist.Add(p);

                string pliststr = JsonSerializer.Serialize(plist);

                File.WriteAllText("PokemonList.json", pliststr);

                _logger.LogStuff(p);

                return p;
            }
            else
            {
                List<PokemonClass> plist = new List<PokemonClass>();
                plist.Add(p);

                string pliststr = JsonSerializer.Serialize(plist);

                File.WriteAllText("PokemonList.json", pliststr);
                _logger.LogStuff(p);
                return p;
            }

        }
    }
}