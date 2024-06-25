namespace VehicleManagementSystem.API.Models
{
    public class Motorcycle : Vehicle
    {
        public int EngineDisplacement { get; set; }
        public bool HasAntiLockBrakes { get; set; }

        public Motorcycle(Guid id, string make, string model, int manufacturingYear, int engineDisplacement, bool hasAntiLockBrakes) 
            : base(id, make, model, manufacturingYear, VehicleType.Motorcycle)
        {
            EngineDisplacement = engineDisplacement;
            HasAntiLockBrakes = hasAntiLockBrakes;
        }
    }
}
