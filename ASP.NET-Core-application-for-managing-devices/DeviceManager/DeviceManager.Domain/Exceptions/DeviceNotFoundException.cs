namespace DeviceManager.Domain.Exceptions
{
    public class DeviceNotFoundException : Exception
    {
        public DeviceNotFoundException(string? message)
            : base(message)
        {
        }
    }
}
