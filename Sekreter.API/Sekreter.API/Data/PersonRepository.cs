using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sekreter.API.Models;

namespace Sekreter.API.Data
{
    public class PersonRepository : IPersonRepository
    {
        PersonContext _personContext;

        public void Delete(int id)
        {
            using (_personContext = new PersonContext())
            {
                _personContext.People.Remove(_personContext.People.FirstOrDefault(x=>x.PersonID==id));
                _personContext.SaveChanges();
            }
        }

        public IEnumerable<PersonModel> GetAll
        {
            get
            {
                using (_personContext = new PersonContext())
                {
                    var people = _personContext.People.ToList();
                    return people;
                }
                    
            }
        }



        public bool DoesPersonExist(int id)
        {
            using (_personContext = new PersonContext())
            {
               return  _personContext.People.Any(x => x.PersonID == id);
            }
        }

        public PersonModel Find(int id)
        {
            using (_personContext = new PersonContext())
            {
                return _personContext.People.FirstOrDefault(x => x.PersonID == id);
            }
        }

        public void Insert(PersonModel person)
        {
            using (_personContext = new PersonContext())
            {
                _personContext.People.Add(person);
                _personContext.SaveChanges();
                
            }
        }

        public void Update(PersonModel person)
        {
            using (_personContext = new PersonContext())
            {
               
                _personContext.People.Update(person);
                _personContext.SaveChanges();

                  
            }
        }
    }
}
