using DeviceManager.Business.Services;
using DeviceManager.Data.Repositories;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Exceptions;
using DeviceManager.Domain.Models;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DeviceManager.Tests
{
    public class DeviceManagerServiceTest
    {
        private Mock<IDeviceManagerRepository> _deviceManagerRepository;
        private DeviceManagerService _deviceManagerService;

        public DeviceManagerServiceTest()
        {
            _deviceManagerRepository = new Mock<IDeviceManagerRepository>();

            _deviceManagerService = new DeviceManagerService(
                _deviceManagerRepository.Object);
        }

        [Fact]
        public async Task DeviceManagerService_GetDeviceAsync_ShouldReturnValidDevice()
        {
            //Arrange
            var deviceId = 1;
            var deviceFromRepo = new Device
            {
                Name = "Redmi Note",
                Manufacturer = "Xiomi",
                Model = "11 Pro",
                ReleaseDate = new DateTime(2021, 06, 01),
                DateTaken = null
            };

            var expectedDevice = new DeviceModel()
            {
                Id = deviceFromRepo.Id,
                Name = deviceFromRepo.Name,
                Model = deviceFromRepo.Model,
                Manufacturer = deviceFromRepo.Manufacturer,
                ReleaseDate = deviceFromRepo.ReleaseDate.ToShortDateString(),
                DateTaken = ""
            };


            _deviceManagerRepository
                .Setup(_ => _.GetDeviceByIdAsync(deviceId))
                .ReturnsAsync(deviceFromRepo);

            DeviceModel result = null;

            //Act
            Func<Task> act = async () => result = await _deviceManagerService.GetDeviceByIdAsync(deviceId);
            await act();

            //Assert
            result.Should()
             .BeEquivalentTo(expectedDevice);
        }

        [Fact]
        public async Task DeviceManagerService_UpdateDeviceAsync_ShouldThrowDeviceNotFoundExceptionWhenDeviceIsNull()
        {
            //Arrange
            var deviceId = -1;
            var testDevice = new CreateOrUpdateDeviceModel
            {
                Name = "Redmi Note",
                Manufacturer = "Xiomi",
                Model = "11 Pro",
                ReleaseDate = new DateTime(2021, 06, 01),
                DateTaken = new DateTime(2021, 07, 23)
            };


            _deviceManagerRepository
                .Setup(_ => _.GetDeviceByIdAsync(deviceId))
                .Returns<Device>(null);

            //Act
            Func<Task> act = async () => await _deviceManagerService.UpdateDeviceAsync(deviceId, testDevice);

            //Assert
            act.Should()
                .ThrowAsync<DeviceNotFoundException>()
                .WithMessage(ErrorMessageConstants.NoDeviceFoundMessage);
        }
    }
}