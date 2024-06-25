using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.API.Models;
using VehicleManagementSystem.API.Services.Interfaces;

namespace VehicleManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        [Route("CheckOut")]
        public async Task<List<Vehicle>> CheckOutVehicles([FromBody] List<Guid> vehicleIds)
        {
            return await _vehicleService.GetVehiclesByIdsAsync(vehicleIds);
        }
    }
}
