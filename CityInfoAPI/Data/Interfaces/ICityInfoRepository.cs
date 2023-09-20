using CityInfoAPI.Entities;

namespace CityInfoAPI.Data.Interfaces
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City> GetCityByIdAsync(int id , bool includePointofinterest);

        Task<IEnumerable<PointOfInterest>> GetPointOfInterestsAsync(int CityId , int PointOfInterestId);


    }
}
