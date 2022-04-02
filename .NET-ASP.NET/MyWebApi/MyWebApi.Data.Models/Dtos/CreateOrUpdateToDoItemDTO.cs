namespace MyWebApi.Data.Models.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using MyWebApi.Data.Models.Entities.Enums;

    public class CreateOrUpdateToDoItemDTO
    {
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
