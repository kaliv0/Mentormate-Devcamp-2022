using DemoApii.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApii.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public async Task<Person> CreateAsync(Person newPerson)
        {
            //You should NEVER do this. This is just because we don't have actual DB.
            var lastId = (await _Context()).Person.Max(x => x.Id);
            newPerson.Id = lastId + 1;
            //-------------------------------------------------------

            (await _Context()).Person.Add(newPerson);
            return newPerson;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var result =  (await _Context())
                        .Person
                        .ToList();

            return result;
        }

        public async Task<Person> GetByNameAsync(string name)
        {
            var result = (await _Context())
                        .Person
                        .Where(x => x.Name == name)
                        .FirstOrDefault();

            return result;
        }
    }
}
