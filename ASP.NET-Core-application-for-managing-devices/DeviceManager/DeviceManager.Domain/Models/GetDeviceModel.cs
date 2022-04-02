namespace DeviceManager.Domain.Models
{
    public class GetDeviceModel
    {
        public DateTime? TakenSince { get; set; }
        public string? Manufacturer { get; set; }
        public DateTime? ReleaseStart { get; set; }
        public DateTime? ReleaseEnd { get; set; }
        public bool? IsTaken { get; set; }
    }
}
