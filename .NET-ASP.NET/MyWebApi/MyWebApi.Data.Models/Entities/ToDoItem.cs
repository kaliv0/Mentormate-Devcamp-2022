namespace MyWebApi.Data.Models.Entities
{
    using MyWebApi.Data.Models.Entities.Enums;
    using System.ComponentModel.DataAnnotations;

    public class ToDoItem
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Range(1, 3)]
        public Priority Priority { get; set; }

        [Range(1, 3)]
        public Status Status { get; set; }
    }
}
