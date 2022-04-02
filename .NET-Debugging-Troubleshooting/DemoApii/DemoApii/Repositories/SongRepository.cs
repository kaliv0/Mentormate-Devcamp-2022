using DemoApii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApii.Repositories
{
    public class SongRepository : BaseRepository, ISongRepository
    {
        public async Task<Song> CreateAsync(Song newSong)
        {
            //You should NEVER do this. This is just because we don't have actual DB.
            var lastId = (await _Context()).Songs.Max(x => x.Id);
            newSong.Id = lastId + 1;
            //-------------------------------------------------------

            if ((await _Context())
                        .Songs.Exists(
                            s => s.Name == newSong.Name &&
                            s.Author == newSong.Author))
            {
                throw new ArgumentException("Song with same name and author already exists");
            }

            if ((await _Context())
                        .Person.Exists(
                            p => p.Name == newSong.Author) == false)
            {
                var lastPersonId = (await _Context()).Person.Max(x => x.Id);
                var newPerson = new Person()
                {
                    Id = lastId + 1,
                    Name = newSong.Author
                };

                (await _Context()).Person.Add(newPerson);
            }

            (await _Context()).Songs.Add(newSong);
            return newSong;
        }

        public async Task<List<Song>> GetAllAsync()
        {
            var result = (await _Context())
                        .Songs
                        .ToList();

            return result;
        }

        public async Task<Song> GetByNameAsync(string name)
        {
            var result = (await _Context())
                        .Songs
                        .Where(x => x.Name == name)
                        .FirstOrDefault();

            return result;
        }
    }
}
