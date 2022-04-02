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
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Song>>> GetAllAsync()
        {
            var songs = await _songService.GetAllAsync();
            return Ok(songs);
        }

        [HttpPost]
        public async Task<ActionResult<Song>> CreateAsync(Song newSong)
        {
            try
            {
                Song createdSong = await _songService.CreateAsync(newSong);
                return Ok(createdSong);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
