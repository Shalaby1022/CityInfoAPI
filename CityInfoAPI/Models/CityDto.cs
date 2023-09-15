namespace CityInfoAPI.Models
{
    public class CityDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }
        public int NoOfPointInterests
        {
            get
            {
                return pointOfInterests.Count;
            }
        }

        public ICollection<PointOfInterests> pointOfInterests { get; set; } = new List<PointOfInterests>();


        
    }
}
