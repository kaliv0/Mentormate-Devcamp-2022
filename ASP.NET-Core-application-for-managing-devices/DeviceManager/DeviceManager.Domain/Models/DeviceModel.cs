namespace DeviceManager.Domain.Models
{
    public class DeviceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string ReleaseDate { get; set; }

        public string? DateTaken { get; set; }
    }
}
