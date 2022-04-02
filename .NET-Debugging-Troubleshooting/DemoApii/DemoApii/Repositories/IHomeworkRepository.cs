using DemoApii.Models;

namespace DemoApii.Repositories
{
    public interface IHomeworkRepository
    {

        public Person GetByName(string name);
    }
}
