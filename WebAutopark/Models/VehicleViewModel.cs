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
        [StringLength(50, MinimumLength = 3)]
        public string Model { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string RegistrationNumber { get; set; }

        [Range(0d, int.MaxValue)] 
        public int Year { get; set; }

        [Range(0d, double.MaxValue)] 
        public double Weight { get; set; }

        [Range(0d, double.MaxValue)] 
        public double Mileage { get; set; }

        [Required] 
        public ColorType Color { get; set; }
    }
}