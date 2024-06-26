﻿using VehicleManagementSystem.API.Models;

namespace VehicleManagementSystem.API.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> CheckOutVehiclesAsync(List<Guid> vehicleGuidList);
    }
}
