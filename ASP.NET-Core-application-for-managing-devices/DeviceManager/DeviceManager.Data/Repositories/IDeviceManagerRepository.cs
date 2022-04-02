namespace DeviceManager.Data.Repositories
{
    using DeviceManager.Domain.Entities;
    using DeviceManager.Domain.Models;

    public interface IDeviceManagerRepository
    {
        Task<Device?> GetDeviceByIdAsync(int id);

        Task<List<Device>> GetAllDevicesAsync(GetDeviceModel getDeviceModel);

        Task AddDeviceAsync(Device newDevice);

        Task UpdateDeviceAsync(int id, Device deviceToUpdate);

        Task DeleteDeviceAsync(Device deviceToDelete);
    }
}
