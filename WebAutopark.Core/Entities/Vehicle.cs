using WebAutopark.Core.Enums;

namespace WebAutopark.Core.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public double Weight { get; set; }
        public int Year { get; set; }
        public double Mileage { get; set; }
        public ColorType Color { get; set; }
    }
}
