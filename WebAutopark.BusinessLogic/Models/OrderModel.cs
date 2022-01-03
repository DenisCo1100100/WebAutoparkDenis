using System.ComponentModel.DataAnnotations;

namespace WebAutopark.BusinessLogic.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        [Required] public int VehicleId { get; set; }
    }
}