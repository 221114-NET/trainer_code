using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using RepoLayer;

namespace tests.api
{
    public class MockRepoLayer : IRepositoryClass
    {
        public List<Customer> GetCustomerList()
        {
            Customer c1 = new Customer(1, "m1", "m1", DateTime.Now, "my one");
            Customer c2 = new Customer(1, "m2", "m2", DateTime.Now, "my two");
            Customer c3 = new Customer(1, "m3", "m3", DateTime.Now, "my three");
            Customer c4 = new Customer(1, "m4", "m4", DateTime.Now, "my four");
            Customer c5 = new Customer(1, "m5", "m5", DateTime.Now, "my five");
            List<Customer> list = new List<Customer>() { c1, c2, c3, c4, c5 };
            return list;

        }

        public Customer PostCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public PokemonClass PostPokemon(PokemonClass p)
        {
            throw new NotImplementedException();

        }

        public PokemonSpecific PostPokemonSpecific(PokemonSpecific ps)
        {
            throw new NotImplementedException();

        }


    }
}