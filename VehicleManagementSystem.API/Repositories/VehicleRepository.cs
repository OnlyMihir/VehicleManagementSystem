using VehicleManagementSystem.API.Models;
using VehicleManagementSystem.API.Repositories.Interfaces;

namespace VehicleManagementSystem.API.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        public Task<List<Vehicle>> GetVehiclesByIdsAsync(List<Guid> vehicleGuidList)
        {
            throw new NotImplementedException();
        }
    }
}
