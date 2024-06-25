using VehicleManagementSystem.API.Models;

namespace VehicleManagementSystem.API.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetVehiclesByIdsAsync(List<Guid> vehicleGuidList);
    }
}
