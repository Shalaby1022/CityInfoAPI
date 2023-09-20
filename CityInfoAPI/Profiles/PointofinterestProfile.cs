using AutoMapper;

namespace CityInfoAPI.Profiles
{
    public class PointofinterestProfile : Profile
    {
        public PointofinterestProfile() 
        {
            CreateMap<Entities.PointOfInterest , Models.PointOfInterests>();

        }
    }
}
