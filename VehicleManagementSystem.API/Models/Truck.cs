namespace VehicleManagementSystem.API.Models
{
    public class Truck : Vehicle
    {
        public int PayloadCapacity { get; set; }
        public bool HasFourWheelDrive { get; set; }

        public Truck(Guid id, string make, string model, int manufacturingYear, int payloadCapacity, bool hasFourWheelDrive) 
            : base(id, make, model, manufacturingYear, VehicleType.Truck)
        {
            PayloadCapacity = payloadCapacity;
            HasFourWheelDrive = hasFourWheelDrive;
        }
    }
}
