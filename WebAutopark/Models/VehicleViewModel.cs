using System.ComponentModel.DataAnnotations;
using WebAutopark.BusinessLogic.DataTransferObject;

namespace WebAutopark.Models
{
    public class VehicleViewModel
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Range(0, int.MaxValue)] 
        public int Year { get; set; }

        [Range(0, double.MaxValue)] 
        public double Weight { get; set; }

        [Range(0, double.MaxValue)] 
        public double Mileage { get; set; }

        [Required] 
        public ColorType Color { get; set; }
    }
}