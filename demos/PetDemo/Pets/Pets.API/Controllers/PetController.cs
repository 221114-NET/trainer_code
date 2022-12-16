using Microsoft.AspNetCore.Mvc;
using Pets.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        //Fields
        private static List<Pet> Pets = new List<Pet>();

        //Constructor
        public PetController()
        {

        }

        //Methods

        // GET: api/<PetController>
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return Pets;
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return Pets[id];
        }

        // POST api/<PetController>
        [HttpPost]
        public IEnumerable<Pet> Post([FromBody] Pet value)
        {
            Pets.Add(value);
            return Pets;
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
