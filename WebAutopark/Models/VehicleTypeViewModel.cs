using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class VehicleTypeViewModel
    {
        [Required]
        public int VehicleTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double TaxCoefficient { get; set; }
    }
}
