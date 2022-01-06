using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class OrderItemViewModel
    {
        [Required] 
        public int OrderItemId { get; set; }

        [Required] 
        public int OrderId { get; set; }

        [Required] 
        public int ComponentId { get; set; }

        [Range(1, int.MaxValue)] 
        public int Quantity { get; set; }
    }
}