using Pets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Repo
{
    public interface IRepository
    {
        //Method Signatures
        public Task<IEnumerable<Pet>> AddPet(Pet newPet);
    }
}
