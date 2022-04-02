namespace DeviceManager.Business.Services
{
    using DeviceManager.Domain.Models;

    public interface IDeviceManagerService
    {
        Task<List<DeviceModel>> GetAllDevicesAsync(GetDeviceModel getDeviceModel);

        Task<DeviceModel> GetDeviceByIdAsync(int id);

        Task<DeviceModel> AddDeviceAsync(CreateOrUpdateDeviceModel device);

        Task UpdateDeviceAsync(int id, CreateOrUpdateDeviceModel device);

        Task DeleteDeviceAsync(int id);
    }
}
