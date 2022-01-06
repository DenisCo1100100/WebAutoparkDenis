using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Required] public int VehicleId { get; set; }
    }
}