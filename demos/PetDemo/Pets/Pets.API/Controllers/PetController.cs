using Microsoft.AspNetCore.Mvc;
using Pets.Models;
using Pets.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        //Fields
        private readonly IRepository repo;
        private readonly ILogger<PetController> logger;


        //Constructor
        public PetController(IRepository _repo, ILogger<PetController> _logger)
        {
            this.repo = _repo;
            this.logger = _logger;
        }

        //Methods

        // GET: api/<PetController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> Get()
        {
            IEnumerable<Pet> Pets;
            try
            {
                Pets = await repo.GetAllPets();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
            return Pets.ToList();
        }

        // GET api/<PetController>/5
        //[HttpGet("{id}")]
        //public Pet Get(int id)
        //{
        //    return Pets[id];
        //}

        // POST api/<PetController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Pet>>> Post([FromBody] Pet value)
        {
            IEnumerable<Pet> Pets;
            try
            {
                Pets = await repo.AddPet(value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
            return Pets.ToList();
        }

        // PUT api/<PetController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PetController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
