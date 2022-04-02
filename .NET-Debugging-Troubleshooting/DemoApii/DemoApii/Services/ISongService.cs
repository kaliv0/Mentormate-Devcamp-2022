using DemoApii.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApii.Services
{
    public interface ISongService
    {
        Task<Song> GetByNameAsync(string name);
        Task<List<Song>> GetAllAsync();
        Task<Song> CreateAsync(Song newSong);
    }
}
