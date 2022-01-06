using System.ComponentModel.DataAnnotations;

namespace WebAutopark.Models
{
    public class ComponentViewModel
    {
        [Required]
        public int ComponentId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}