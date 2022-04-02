using DemoApii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApii.Repositories
{
    public class HomeworkRepository: IHomeworkRepository
    {
        static readonly HttpClient _HttpClient = new HttpClient();

        private async Task<List<Person>> _GetPerson()
        {
            var swApiResponse = await _HttpClient.GetFromJsonAsync<SwApiResponse>("https://swapi.dev/api/people/");
            var swPeople = swApiResponse.results;
            return swPeople;
        }


        public Person GetByName(string name)
        {
            var result = _GetPerson().Result
                            .Where(x => x.Name == name)
                            .FirstOrDefault();

            Thread.Sleep(1500);

            return result;
        }
    }
}
