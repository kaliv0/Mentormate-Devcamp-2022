using DemoApii.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApii.Repositories
{
    public class BaseRepository
    {
        private static FakeDbContext _fakeDbContext { get; set; } = new FakeDbContext()
        {
            Songs = new List<Song>()
            {
                new Song()
                {
                    Id = 1,
                    Name = "Never Gonna Give You Up",
                    Author = "Rick Astley",
                    Length = 184,
                    Lyrics = @"Never gonna give you up
                               Never gonna let you down
                               Never gonna run around and desert you
                               Never gonna make you cry
                               Never gonna say goodbye
                               Never gonna tell a lie and hurt you"
                },
                new Song()
                {
                    Id = 2,
                    Name = "Oops!...I Did It Again",
                    Author = "Britney Spears",
                    Length = 165,
                    Lyrics = @"Oops, I did it again
                                I played with your heart, got lost in the game
                                Oh baby, baby
                                Oops, you think I'm in love
                                That I'm sent from above
                                I'm not that innocent"
                },
                new Song()
                {
                    Id = 3,
                    Name = "Down with the Sickness",
                    Author = "Disturbed",
                    Length = 666,
                    Lyrics = @"Get up, come on get down with the sickness
                                Get up, come on get down with the sickness
                                Get up, come on get down with the sickness
                                Open up your hate, and let it flow into me"
                }
            },
            Person = new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    Name = "Britney Spears",
                    EyeColor = "Red",
                    Gender = "Female",
                    Height = 170,
                    Mass = 33.3
                },
                new Person()
                {
                    Id = 2,
                    Name = "Rick Astley",
                    EyeColor = "Yellow",
                    Gender = "Male",
                    Height = 180,
                    Mass = 44.4
                }
            }
        };

        protected async Task<FakeDbContext> _Context()
        {
            await Task.Delay(1000);
            return _fakeDbContext;
        }
    }
}
