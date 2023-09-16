using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfoAPI.Entities
{
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("cityId")]
        public int cityId { get; set; }
        public City? city { get; set; }

        public PointOfInterest(string name)
        {
            Name = name;
        }

    }
}
