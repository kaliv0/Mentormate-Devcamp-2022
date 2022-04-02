using DemoApii.Models;
using DemoApii.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApii.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private const string AUTHOR_FIELD_MISSING = "AUTHOR FIELD NOT SPECIFIED";

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<Song> CreateAsync(Song newSong)
        {
            newSong.Name = NameNormalizer(newSong.Name);

            if (string.IsNullOrEmpty(newSong.Author))
            {
                //Songs with no authors are allowed
                //but if they exist then the author should be the name of the song.
                if (newSong.Name.Length <= 20)
                {
                    newSong.Author = newSong.Name;
                }
                else
                {
                    throw new ArgumentException(AUTHOR_FIELD_MISSING);
                }
            }

            Song song = await _songRepository.CreateAsync(newSong);
            return song;
        }

        private string NameNormalizer(string name)
        {
            string[] words = name.Split(',', ' ');
            foreach (string word in words)
            {
                name = name.Replace(word, $"{word.First().ToString().ToUpper()}{word.Substring(1, word.Length - 1)}");
            }
            return name;
        }

        public async Task<List<Song>> GetAllAsync()
        {
            var result = await _songRepository.GetAllAsync();
            return result;
        }

        public async Task<Song> GetByNameAsync(string name)
        {
            var result = await _songRepository.GetByNameAsync(name);
            return result;
        }
    }
}
