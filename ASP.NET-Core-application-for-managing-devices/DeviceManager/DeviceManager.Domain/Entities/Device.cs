namespace DeviceManager.Domain.Entities
{
    using System;

    public class Device
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime? DateTaken { get; set; }
    }
}
