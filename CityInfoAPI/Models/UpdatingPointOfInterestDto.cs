using System.ComponentModel.DataAnnotations;

namespace CityInfoAPI.Models
{
    public class UpdatingPointOfInterestDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Dsecription is required")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
        public string? Description { get; set; }
    }
}
