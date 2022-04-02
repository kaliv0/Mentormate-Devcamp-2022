using DemoApii.Models;

namespace DemoApii.Services
{
    public interface IHomeworkRepository
    {

        public Person GetByName(string name);
    }
}
