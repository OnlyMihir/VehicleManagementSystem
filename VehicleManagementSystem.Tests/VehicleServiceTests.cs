using Moq;
using VehicleManagementSystem.API.Models;
using VehicleManagementSystem.API.Repositories.Interfaces;
using VehicleManagementSystem.API.Services;

namespace VehicleManagementSystem.Tests
{
    public class VehicleServiceTests
    {
        private VehicleService _vehicleService;
        private Mock<IVehicleRepository> _vehicleRepositoryMock;

        public VehicleServiceTests()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _vehicleService = new VehicleService(_vehicleRepositoryMock.Object);
        }

        [Fact]
        public void CreateVehicleInstances_ShouldCreateInstancesCorrectly()
        {
            var car = new Car(Guid.NewGuid(), "Toyota", "Camry", 2021, 4, false);
            var truck = new Truck(Guid.NewGuid(), "Ford", "F-150", 2020, 2000, true);
            var motorcycle = new Motorcycle(Guid.NewGuid(), "Honda", "CBR600RR", 2019, 600, true);

            Assert.NotNull(car);
            Assert.NotNull(truck);
            Assert.NotNull(motorcycle);
        }

        [Fact]
        public void VehicleProperties_ShouldSetAndRetrieveCorrectly()
        {
            var car = new Car(Guid.NewGuid(), "Toyota", "Camry", 2021, 5, false);
            Assert.Equal("Toyota", car.Make);
            Assert.Equal("Camry", car.Model);
            Assert.Equal(2021, car.ManufacturingYear);
            Assert.Equal(5, car.NumberOfDoors);
            Assert.False(car.IsConvertible);
        }

        [Fact]
        public async Task CheckOutVehicles_ShouldReturnVehicles()
        {
            var vehicleIds = new List<Guid> { new Guid("9f3dd1be-0417-4acf-b9bc-e12f7ca451eb"), new Guid("7b25b95c-987f-4d4d-b8d4-e761a757ae7e") };
            var vehicles = new List<Vehicle>
            {
                new Car(new Guid("9f3dd1be-0417-4acf-b9bc-e12f7ca451eb"), "Toyota", "Camry", 2021, 4, false),
                new Truck(new Guid("7b25b95c-987f-4d4d-b8d4-e761a757ae7e"), "Ford", "F-150", 2020, 2000, true)
            };

            _vehicleRepositoryMock.Setup(repo => repo.GetVehiclesByIdsAsync(vehicleIds)).ReturnsAsync(vehicles);

            var result = await _vehicleService.CheckOutVehiclesAsync(vehicleIds);

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task CheckOutVehicles_ShouldEnforceVehicleLimit()
        {
            var vehicleIds = new List<Guid>();
            for (int i = 0; i < 11; i++)
            {
                vehicleIds.Add(Guid.NewGuid());
            }

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await _vehicleService.CheckOutVehiclesAsync(vehicleIds));
        }

        [Fact]
        public async Task CheckOutVehicles_ShouldEnforceVehicleTypeLimit()
        {
            var vehicleIds = new List<Guid> 
            {
                new Guid("7a73630d-3193-44e8-a99c-84997cad47be"),
                new Guid("d429fb3a-1747-44ce-8b4a-e62a50a193e7"),
                new Guid("95cfb585-977b-4c23-ae62-154da144ac2d"),
                new Guid("0d3d0c8d-f55b-4b0c-8312-b60eacb6a34f"),
                new Guid("77a6f5d1-8724-48c8-9101-945e6a179dfb")
            };
            var vehicles = new List<Vehicle>
        {
            new Car(new Guid("7a73630d-3193-44e8-a99c-84997cad47be"), "Toyota", "Camry", 2021, 4, false),
            new Car(new Guid("d429fb3a-1747-44ce-8b4a-e62a50a193e7"), "Toyota", "Camry", 2021, 4, false),
            new Car(new Guid("95cfb585-977b-4c23-ae62-154da144ac2d"), "Toyota", "Camry", 2021, 4, false),
            new Car(new Guid("0d3d0c8d-f55b-4b0c-8312-b60eacb6a34f"), "Toyota", "Camry", 2021, 4, false),
            new Car(new Guid("77a6f5d1-8724-48c8-9101-945e6a179dfb"), "Toyota", "Camry", 2021, 4, false)
        };

            _vehicleRepositoryMock.Setup(repo => repo.GetVehiclesByIdsAsync(vehicleIds)).ReturnsAsync(vehicles);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await _vehicleService.CheckOutVehiclesAsync(vehicleIds));
        }
    }
}
