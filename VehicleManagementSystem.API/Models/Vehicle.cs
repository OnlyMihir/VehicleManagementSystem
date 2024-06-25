namespace VehicleManagementSystem.API.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int ManufacturingYear { get; set; }

        public Vehicle(Guid id, string make, string model, int manufacturingYear)
        {
            Id = id;
            Make = make;
            Model = model;
            ManufacturingYear = manufacturingYear;
        }
    }
}
