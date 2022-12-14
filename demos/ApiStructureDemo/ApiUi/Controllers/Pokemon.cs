using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using BusinessLayer;
using System.Text.Json;


namespace ApiUi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Pokemon : ControllerBase
    {

        private readonly IBusinessLayerClass _ibus;

        public Pokemon(IBusinessLayerClass ibus)
        {
            _ibus = ibus;
        }

        //model binding happens here.
        // The model binding system will look at all the properties of the json string 
        // and try to match them with the designated model
        // "localhost://api/pokemon/myguyishere"
        [HttpPost("myguyishere")]
        public ActionResult<PokemonClass> PostPokemon(PokemonClass p)
        {
            // action methods (what this method is) are for routing to the correct busiess layet method. 
            // do as little manipulation as possible here.
            p.Name = "Marizard";
            PokemonClass p1 = _ibus.PostPokemon(p);

            return Created("mydb/pokemon/itshere", p1);
        }

        [HttpPost("postpokemonspecific")]
        public ActionResult<PokemonSpecific> PostPS(PokemonSpecific ps)
        {
            PokemonSpecific ps1 = this._ibus.PostPokemonSpecific(ps);
            return Created("mydb/pokemon/itshere", ps1);
        }

        [HttpPost("castingpostpokemonspecific")]
        public ActionResult<PokemonSpecific> PostPS(PokemonClass ps)
        {
            PokemonClass ps2 = this._ibus.CastingPostPokemonSpecific((object)ps);
            return Created("mydb/pokemon/itshere", ps2);
        }

        [HttpPost("test")]
        public ActionResult<PokemonSpecific> PostPS(object o)
        {
            var r = Request.Body;
            r.Position = 0;



            var reader = new StreamReader(HttpContext.Request.Body);
            // InputStream.Position = 0;

            string rawBod = reader.ReadToEnd()!;
            Console.WriteLine(rawBod);
            var req = JsonSerializer.Deserialize<PokemonClass>(rawBod)!;

            Console.WriteLine($"color is => {req.Color}");

            PokemonSpecific ps = new PokemonSpecific("mark", "christopher", "moore", 1, 1);
            return Created("mydb/pokemon/itshere", ps);
        }

    }
}