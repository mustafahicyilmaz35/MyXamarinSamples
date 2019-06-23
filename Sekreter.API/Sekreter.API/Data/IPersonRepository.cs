using Sekreter.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekreter.API.Data
{
    public interface IPersonRepository
    {

        IEnumerable<PersonModel> GetAll { get; }
        bool DoesPersonExist(int id);
        PersonModel Find(int id);
        void Insert(PersonModel person);
        void Delete(int id);
        void Update(PersonModel person);
    }
}
