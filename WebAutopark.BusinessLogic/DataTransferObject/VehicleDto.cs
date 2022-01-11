namespace WebAutopark.BusinessLogic.DataTransferObject
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleTypeDto VehicleType { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int Year { get; set; }
        public double Weight { get; set; }
        public double Mileage { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public ColorType Color { get; set; }
    }
}