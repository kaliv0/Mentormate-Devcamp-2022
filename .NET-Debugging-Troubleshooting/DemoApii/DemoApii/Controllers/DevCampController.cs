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
    public class DevCampController : ControllerBase
    {
        //----------------1------------------
        private static readonly string[] _SongLyrics = new[]
        {
            "It's my life and it's now or never",
            "I ain't gonna live forever."
        };

        public DevCampController()
        {
        }


        [Route("drunkUncleAtBbq")]
        [HttpGet]
        public string DrunkUncleAtBbq(int verse)
        {
            string drunkVerse = _SongLyrics[verse - 1];

            Thread.Sleep(3000 - verse * 1000);

            return drunkVerse;
        }






    }
}
