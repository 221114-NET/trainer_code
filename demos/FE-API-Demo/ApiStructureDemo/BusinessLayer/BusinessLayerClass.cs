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
        PokemonClass CastingPostPokemonSpecific(object ps);
        Task<List<Customer>> GetCustomerListAsync();
        Task<Customer> PostCustomerAsync(Customer c);
        PokemonClass PostPokemon(PokemonClass p);
        PokemonSpecific PostPokemonSpecific(PokemonSpecific ps);
    }

    public class BusinessLayerClass : IBusinessLayerClass
    {
        private readonly IRepositoryClass _repo;

        public BusinessLayerClass(IRepositoryClass repo)
        {
            _repo = repo;
        }

        public PokemonClass CastingPostPokemonSpecific(object ps)
        {
            if (ps is PokemonClass)// use is to cehck if a type is actually another types.. of a type you want to check for.
            {
                Console.WriteLine($"This object is a {ps.ToString()}");
                PokemonClass? ps1 = ps as PokemonClass;// use as to convert to another type.
                ps1.Name = "Did it work";
                return ps1;
            }
            else if (ps is PokemonSpecific)
            {
                Console.WriteLine($"This object is a {ps.ToString()}");
                return (PokemonClass)ps;
            }
            else
            {
                Console.WriteLine($"This object is a {ps.ToString()}");
                return (PokemonClass)ps;
            }
        }

        public async Task<List<Customer>> GetCustomerListAsync()
        {
            // callt he repo method to get the list.
            List<Customer> l = await this._repo.GetCustomerListAsync();
            return l;

            // Lets play with LINQ!
            // List<Customer> l2 = l.Where(x => x.LastName == "Moore" && x.Remarks.Contains("est")).ToList();// write a 'Predicate' into the arg of the method. 
            // List<Customer> l3 = l.OrderByDescending(x => x.CustomerId).ToList();
            // foreach (Customer c in l3)
            // {
            //     Console.WriteLine($"CustomerId - {c.CustomerId}, Fname- {c.FirstName}, lname -  {c.LastName}");
            // }
        }

        public async Task<Customer> PostCustomerAsync(Customer c)
        {
            // you might want to do some validation here... it's best practice to do validation in every method.

            // alter the data... or manipulate it somehow.

            // pass the data to the Repo layer.
            Customer c1 = await this._repo.PostCustomerAsync(c);
            return c1;
        }

        /// <summary>
        /// This business layer method will do the manipulation of the object
        /// and call an appropriate Repo layer method(if necessary) to interact with the DB.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public PokemonClass PostPokemon(PokemonClass p)
        {
            p.Color = "blue";
            PokemonClass p1 = _repo.PostPokemon(p);
            return p1;

        }

        public PokemonSpecific PostPokemonSpecific(PokemonSpecific ps)
        {
            ps.Dexterity++;
            ps.Color = "Blue";

            // Implicitely convert the derived class to the parent class.
            PokemonClass p = ps;
            Console.WriteLine($"My color is {p.Color}");

            //explicitely cast the parent to the child.
            PokemonSpecific ps1 = (PokemonSpecific)p;
            Console.WriteLine($"My color is {p.Color} and Type is  {ps1.PokemonType} my sentence is\n\t{ps1.SayMyNamePokemon()}");

            // Liskov Substitution Principle
            int myInt = 220;
            double myDouble = myInt;//implicit conversion because the in will not loose data.
            myDouble += .03;
            Console.WriteLine(myDouble);

            int myInt1 = (int)myDouble;// explicit conversion to a smaller data type
            Console.WriteLine(myInt1);

            PokemonSpecific ps2 = this._repo.PostPokemonSpecific(ps);
            return ps2;
        }
    }
}