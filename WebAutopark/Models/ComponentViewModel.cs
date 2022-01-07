using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class ComponentViewModel
    {
        [Required]
        public int ComponentId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}