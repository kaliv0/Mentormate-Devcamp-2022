namespace DeviceManager.Business.Services
{
    using DeviceManager.Domain.Models;
    using DeviceManager.Domain.Entities;
    using DeviceManager.Data.Repositories;
    using DeviceManager.Domain.Exceptions;

    public class DeviceManagerService : IDeviceManagerService
    {
        private readonly IDeviceManagerRepository _deviceManagerRepository;

        public DeviceManagerService(IDeviceManagerRepository deviceManagerRepository)
        {
            _deviceManagerRepository = deviceManagerRepository;
        }

        public async Task<List<DeviceModel>> GetAllDevicesAsync(GetDeviceModel getDeviceModel)
        {
            var devices = await _deviceManagerRepository.GetAllDevicesAsync(getDeviceModel);

            var deviceModels = devices
                .OrderByDescending(d => d.ReleaseDate)
                .Select(device => new DeviceModel()
                {
                    Id = device.Id,
                    Name = device.Name,
                    Model = device.Model,
                    Manufacturer = device.Manufacturer,
                    ReleaseDate = device.ReleaseDate.ToShortDateString(),
                    DateTaken = device.DateTaken != null ?
                                ((DateTime)device.DateTaken).ToShortDateString() : ""
                })
              .ToList();

            return deviceModels;
        }

        public async Task<DeviceModel> GetDeviceByIdAsync(int id)
        {
            var device = await _deviceManagerRepository.GetDeviceByIdAsync(id);

            return new DeviceModel()
            {
                Id = device.Id,
                Name = device.Name,
                Model = device.Model,
                Manufacturer = device.Manufacturer,
                ReleaseDate = device.ReleaseDate.ToShortDateString(), //???
                DateTaken = device.DateTaken != null ?
                                ((DateTime)device.DateTaken).ToShortDateString() : ""
            };
        }

        public async Task<DeviceModel> AddDeviceAsync(CreateOrUpdateDeviceModel device)
        {
            var newDevice = new Device()
            {
                Name = device.Name,
                Model = device.Model,
                Manufacturer = device.Manufacturer,
                ReleaseDate = device.ReleaseDate,
                DateTaken = device.DateTaken != null ? ((DateTime)device.DateTaken) : null
            };

            await _deviceManagerRepository.AddDeviceAsync(newDevice);

            return new DeviceModel()
            {
                Id = newDevice.Id,
                Name = device.Name,
                Model = device.Model,
                Manufacturer = device.Manufacturer,
                ReleaseDate = device.ReleaseDate.ToShortDateString(), //???
                DateTaken = device.DateTaken != null ?
                                ((DateTime)device.DateTaken).ToShortDateString() : ""
            };
        }

        public async Task UpdateDeviceAsync(int id, CreateOrUpdateDeviceModel deviceModel)
        {
            var deviceToUpdate = await _deviceManagerRepository.GetDeviceByIdAsync(id);

            if (deviceToUpdate == null)
            {
                throw new DeviceNotFoundException(ErrorMessageConstants.NoDeviceFoundMessage);
            }

            deviceToUpdate.Name = deviceModel.Name;
            deviceToUpdate.Model = deviceModel.Model;
            deviceToUpdate.Manufacturer = deviceModel.Manufacturer;
            deviceToUpdate.ReleaseDate = deviceModel.ReleaseDate;
            deviceToUpdate.DateTaken = deviceModel.DateTaken;

            await _deviceManagerRepository.UpdateDeviceAsync(id, deviceToUpdate);
        }

        public async Task DeleteDeviceAsync(int id)
        {
            var deviceToDelete = await _deviceManagerRepository.GetDeviceByIdAsync(id);

            if (deviceToDelete == null)
            {
                throw new DeviceNotFoundException(ErrorMessageConstants.NoDeviceFoundMessage);
            }

            await _deviceManagerRepository.DeleteDeviceAsync(deviceToDelete);
        }
    }
}
