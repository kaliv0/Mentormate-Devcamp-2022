namespace DeviceManager.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrUpdateDeviceModel
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Model { get; set; }

        [Required]
        [MaxLength(255)]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }

        public DateTime? DateTaken { get; set; }
    }
}
