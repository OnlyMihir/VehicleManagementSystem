using VehicleManagementSystem.API.Models;
using VehicleManagementSystem.API.Repositories.Interfaces;
using VehicleManagementSystem.API.Services.Interfaces;

namespace VehicleManagementSystem.API.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<Vehicle>> GetVehiclesByIdsAsync(List<Guid> vehicleGuidList)
        {
            if (vehicleGuidList == null || !vehicleGuidList.Any())
                throw new ArgumentException("Vehicle IDs cannot be null or empty.");

            if (vehicleGuidList.Count > 10)
                throw new InvalidOperationException("Cannot check out more than 10 vehicles at a time.");

            List<Vehicle> vehicles = await _vehicleRepository.GetVehiclesByIdsAsync(vehicleGuidList);

            var vehicleTypeCount = vehicles.GroupBy(x => x.GetType())
                                           .ToDictionary(x => x.Key, x => x.Count());

            if (vehicleTypeCount.ContainsKey(typeof(Car)) && vehicleTypeCount[typeof(Car)] > 4 ||
                vehicleTypeCount.ContainsKey(typeof(Truck)) && vehicleTypeCount[typeof(Truck)] > 4 ||
                vehicleTypeCount.ContainsKey(typeof(Motorcycle)) && vehicleTypeCount[typeof(Motorcycle)] > 4)
            {
                throw new InvalidOperationException("Cannot check out more than 4 vehicles of each type at a time.");
            }

            return vehicles;
        }
    }
}
