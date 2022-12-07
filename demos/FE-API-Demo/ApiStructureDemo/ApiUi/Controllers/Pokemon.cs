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
            this._ibus = ibus;
        }

        [HttpGet("CustomerAsync/{id}")]
        public async Task<ActionResult<List<Customer>>> Customers(int? id)
        {
            //checkif the id is null or 0
            if (id == null || id == 0)
            {
                //get the whole list.
                List<Customer> customerList = await this._ibus.GetCustomerListAsync();
                if (customerList == null)
                {
                    return Problem("It's not you. It's us.... We cannot deliver.");
                }
                else return Ok(customerList);
            }
            else
            {
                return null;// TODO
            }

        }

        /// <summary>
        /// This method will post a new customer to the Db
        /// it returns the creatd customer is successful
        /// otherwise, null.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost("PostCustomerAsync")]
        public async Task<ActionResult<Customer>> PostCustomerAsync(Customer c)
        {
            //call a business layer method to deal with this accordingly....
            if (ModelState.IsValid)
            {
                Customer c1 = await this._ibus.PostCustomerAsync(c);
            }
            else
            {
                return NotFound("that modelbinding did't work");
            }
            // return what the business layer returned to this calling method.
            return Created($"https://localhost:7007/api/pokemon/getcustomer/{c.CustomerId}", c);
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

        [HttpGet("register/{name}/{color}/{strength}/{dexterity}")]
        public ActionResult<PokemonClass> RegisterDemo(string name, string color, int strength, int dexterity)
        {
            if (ModelState.IsValid)// check to verify that the modelbinding process was successful.
            {
                PokemonClass p = new PokemonClass(name, color, strength, dexterity);
                // call business layer here
                //PokemonClass p1 = this._ibus.Register(name, color, strength, dexterity);

                return Created("new/entity/located/here", p);
            }
            else return BadRequest("you done messed up, leroy.");
        }

    }
}