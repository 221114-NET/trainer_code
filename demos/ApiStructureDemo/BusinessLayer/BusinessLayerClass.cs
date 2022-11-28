using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using RepoLayer;

/**
The business layer is used for manipulating data, creating mondels, etc.. that can be sent to the 
repo layer and returned to the UI layer.
*/
namespace BusinessLayer 
{
    public interface IBusinessLayerClass
    {
        PokemonClass PostPokemon(PokemonClass p);
    }

    public class BusinessLayerClass : IBusinessLayerClass
    {
        private readonly IRepositoryClass _repo;

        public BusinessLayerClass(IRepositoryClass repo)
        {
            _repo = repo;
        }

        public PokemonClass PostPokemon(PokemonClass p)
        {
            p.Color = "blue";
            PokemonClass p1 = _repo.PostPokemon(p);
            return p1;

        }
    }
}