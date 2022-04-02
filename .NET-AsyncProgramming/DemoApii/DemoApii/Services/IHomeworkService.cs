using DemoApii.Models;

namespace DemoApii.Services
{
    public interface IHomeworkService
    {
        Person GetByName(string name);
    }
}
