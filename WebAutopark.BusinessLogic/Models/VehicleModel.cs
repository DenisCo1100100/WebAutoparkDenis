using System.ComponentModel.DataAnnotations;
using WebAutopark.Core.Enums;

namespace WebAutopark.BusinessLogic.Models
{
    public class VehicleModel
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }

        public VehicleTypeModel VehicleType { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        [Range(0, int.MaxValue)] public int Year { get; set; }
        [Range(0, double.MaxValue)] public double Weight { get; set; }
        [Range(0, double.MaxValue)] public double Mileage { get; set; }
        [Required] public ColorType Color { get; set; }
    }
}