using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApii.Models
{
    public class FakeDbContext
    {
        public List<Person> Person { get; set; } = new List<Person>();
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
