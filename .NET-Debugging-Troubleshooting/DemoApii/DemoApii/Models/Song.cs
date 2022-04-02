using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApii.Models
{
    public class Song
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public int Length { get; set; }

        [MaxLength(20)]
        public string Author { get; set; }
    }
}
