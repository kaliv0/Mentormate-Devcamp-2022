namespace DeviceManager.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using DeviceManager.Domain.Entities;
    using DeviceManager.Domain.Exceptions;
    using DeviceManager.Domain.Models;

    public class DeviceManagerRepository : IDeviceManagerRepository
    {

        private readonly DeviceManagerDbContext _dbContext;

        public DeviceManagerRepository(DeviceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Device>> GetAllDevicesAsync(GetDeviceModel getDeviceModel)
        {
            var devices = _dbContext.Devices.AsQueryable();

            if (getDeviceModel.TakenSince != null)
            {
                devices = devices.Where(d => d.DateTaken <= getDeviceModel.TakenSince);
            }

            if (getDeviceModel.Manufacturer != null)
            {
                devices = devices.Where(d => d.Manufacturer == getDeviceModel.Manufacturer);
            }

            if (getDeviceModel.ReleaseStart != null)
            {
                devices = devices.Where(d => d.ReleaseDate >= getDeviceModel.ReleaseStart);
            }

            if (getDeviceModel.ReleaseEnd != null)
            {

                devices = devices.Where(d => d.ReleaseDate <= getDeviceModel.ReleaseEnd);
            }

            if (getDeviceModel.IsTaken != null)
            {
                if ((bool)getDeviceModel.IsTaken)
                {
                    devices = devices.Where(d => d.DateTaken != null);
                }
                else
                {
                    devices = devices.Where(d => d.DateTaken == null);
                }
            }

            var result = await devices.ToListAsync();

            if (!result.Any())
            {
                throw new DeviceListNotFoundException(ErrorMessageConstants.NoEntriesMessage);
            }

            return result;
        }

        public async Task<Device?> GetDeviceByIdAsync(int id)
        {
            var device = await _dbContext.Devices
                .FirstOrDefaultAsync(device => device.Id == id);

            if (device == null)
            {
                throw new DeviceNotFoundException(ErrorMessageConstants.NoDeviceFoundMessage);
            }

            return device;
        }

        public async Task AddDeviceAsync(Device newDevice)
        {
            await _dbContext.Devices.AddAsync(newDevice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDeviceAsync(int id, Device deviceToUpdate)
        {
            _dbContext.Devices.Update(deviceToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDeviceAsync(Device deviceToDelete)
        {
            _dbContext.Devices.Remove(deviceToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
