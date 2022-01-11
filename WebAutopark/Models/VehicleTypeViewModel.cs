using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class VehicleTypeViewModel
    {
        [Required]
        public int VehicleTypeId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1d, 10d)]
        public double TaxCoefficient { get; set; }
    }
}
