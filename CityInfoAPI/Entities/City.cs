using CityInfoAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfoAPI.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        //navigation property.
        [NotMapped]
        public ICollection<PointOfInterests> pointOfInterests { get; set; } = new List<PointOfInterests>();


        public City(string name)
        {
            Name = name;
        }
    }
}
