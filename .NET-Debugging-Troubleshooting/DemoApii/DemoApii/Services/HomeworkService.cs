using DemoApii.Models;
using DemoApii.Repositories;

namespace DemoApii.Services
{
    public class HomeworkService : IHomeworkService
    {
        private readonly IHomeworkRepository _homeworkRepository;

        public HomeworkService(IHomeworkRepository homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }


        public Person GetByName(string name)
        {
            var result = _homeworkRepository.GetByName(name);

            if (result.Height > 9000)
            {
                result.Height = 900;
            }

            return result;
        }
    }
}
