namespace VehicleManagementSystem.API.Models
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public bool IsConvertible { get; set; }

        public Car(Guid id, string make, string model, int manufacturingYear, int numberOfDoors, bool isConvertible) 
            : base(id, make, model, manufacturingYear)
        {
            NumberOfDoors = numberOfDoors;
            IsConvertible = isConvertible;
        }
    }
}
