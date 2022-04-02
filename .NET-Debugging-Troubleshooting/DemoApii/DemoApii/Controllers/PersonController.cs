using DemoApii.Models;
using DemoApii.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService; 
        }

        [HttpGet]
        public async Task<List<Person>> GetAllAsync()
        {
            var person = await _personService.GetAllAsync();
            return person;
        }

        [HttpPost]
        public async Task<Person> CreateAsync(Person newPerson)
        {
            List<string> allowedEyeColors = new List<string>()
            {
                "Coral",
                "Magenta",
                "Cyan",
                "Turquoise"
            };

            if (allowedEyeColors.Contains(newPerson.EyeColor))
            {
                newPerson.EyeColor = "N/A";
            }

            Person createdPerson = await _personService.CreateAsync(newPerson);
            return createdPerson;
        }
    }
}
