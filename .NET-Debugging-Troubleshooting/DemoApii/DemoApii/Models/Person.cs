using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApii.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public double Height { get; set; }
        public double Mass { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
    }
}
