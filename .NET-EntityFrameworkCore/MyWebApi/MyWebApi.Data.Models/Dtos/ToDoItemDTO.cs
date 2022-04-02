namespace MyWebApi.Data.Models.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class ToDoItemDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }
    }
}
