namespace VehicleManagementSystem.API.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ManufacturingYear { get; set; }
        public VehicleType VehicleType { get; set; }

        public Vehicle(Guid id, string make, string model, int manufacturingYear, VehicleType vehicleType)
        {
            Id = id;
            Make = make;
            Model = model;
            ManufacturingYear = manufacturingYear;
            VehicleType = vehicleType;
        }
    }

    public enum VehicleType
    {
        Car = 0,
        Truck = 1,
        Motorcycle = 2,
    }
}
