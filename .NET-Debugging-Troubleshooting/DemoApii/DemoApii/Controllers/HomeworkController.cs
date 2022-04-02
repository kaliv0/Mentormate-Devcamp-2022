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
    public class HomeworkController : ControllerBase
    {
        private readonly string[] _Victims = new[]
        {
            "Daniel Todorov",
            "Dragomir Mitev",
            "Iliya Nikolov",
            "Kristian Budov",
            "Maria Dimitrova",
            "Mihail Gerganchev",
            "Nadya Nencheva",
            "Samir Dermendzhiev",
            "Veronica Kolarska",
            "Viktor Ivanov"
        };
        private readonly string[] _Tortures = new[]
        {
            ".NET", "Java", "Node", "Ruby", "React", "Angular", "PHP"
        };

        private readonly IHomeworkService _homeworkService;

        public HomeworkController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }


        [Route("victim")]
        [HttpGet]
        public async Task<string> Victim()
        {
            var fate = new Random();
            int index = fate.Next(_Victims.Count());
            string vic = _Victims[index];

            await Task.Delay(2000);

            return vic;
        }

        [Route("torture")]
        [HttpGet]
        public string Torture()
        {
            var fate = new Random();
            int index = fate.Next(_Tortures.Count());
            string vic = _Tortures[index];

            Thread.Sleep(3000);

            return vic;
        }

        [Route("person")]
        [HttpGet]
        public Person GetPerson(string name)
        {
            var swPerson = _homeworkService.GetByName(name);
            return swPerson;
        }


    }
}
