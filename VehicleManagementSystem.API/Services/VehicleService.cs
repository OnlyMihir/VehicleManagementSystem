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

        public async Task<List<Vehicle>> CheckOutVehiclesAsync(List<Guid> vehicleGuidList)
        {
            if (vehicleGuidList == null || !vehicleGuidList.Any())
                throw new ArgumentException("Vehicle IDs cannot be null or empty.");

            List<Vehicle> vehicles = await _vehicleRepository.GetVehiclesByIdsAsync(vehicleGuidList);

            if (vehicles.Count > 10)
                throw new InvalidOperationException("Cannot check out more than 10 vehicles at a time.");

            var vehicleTypeCount = vehicles.GroupBy(x => x.VehicleType)
                                           .ToDictionary(x => x.Key, x => x.Count());

            if (vehicleTypeCount.Values.Any(x => x > 4))
                throw new InvalidOperationException("Cannot check out more than 4 vehicles of each type at a time.");

            return vehicles;
        }
    }
}
