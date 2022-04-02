using DemoApii.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApii.Services
{
    public interface IPersonService
    {
        Task<Person> GetByNameAsync(string name);
        Task<List<Person>> GetAllAsync();
        Task<Person> CreateAsync(Person newSong);
    }
}
