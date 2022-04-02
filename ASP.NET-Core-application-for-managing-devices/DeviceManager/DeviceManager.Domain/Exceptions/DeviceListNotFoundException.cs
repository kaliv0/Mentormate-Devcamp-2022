namespace DeviceManager.Domain.Exceptions
{
    public class DeviceListNotFoundException : Exception
    {
        public DeviceListNotFoundException(string? message)
            : base(message)
        {
        }
    }
}
