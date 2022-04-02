using DemoApii.Models;
using DemoApii.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApii.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> CreateAsync(Person newPerson)
        {
            if (newPerson.Height < 0)
            {
                newPerson.Height = 0;
            }

            if (newPerson.Mass < 0)
            {
                newPerson.Mass = 0;
            }

            Person person = await _personRepository.CreateAsync(newPerson);
            return person;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var result = await _personRepository.GetAllAsync();
            return result;
        }

        public async Task<Person> GetByNameAsync(string name)
        {
            var result = await _personRepository.GetByNameAsync(name);
            return result;
        }
    }
}
