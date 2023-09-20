using CityInfoAPI.Data;
using CityInfoAPI.Data.Interfaces;
using CityInfoAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPI.Repositories
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CPDbContext _context;

        public CityInfoRepository(CPDbContext context)
        {
           _context = context;
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
           var cities = await _context.cities.OrderBy(r=>r.Name).ToListAsync();
            return cities;
        }

        public async Task<City> GetCityByIdAsync(int id , bool includePointofinterest)
        {
            if (includePointofinterest)
            {
                var Onecity = await _context.cities.Include(p => p.pointOfInterests).FirstOrDefaultAsync(r => r.Id == id);
                if (Onecity == null) return null;
                return Onecity;
            }
                return await _context.cities.FirstOrDefaultAsync(r => r.Id == id);
        }
         
        public async Task<IEnumerable<PointOfInterest>> GetPointOfInterestsAsync(int CityId, int PointOfInterestId)
        {
            var pointointerstincity = await _context.pointOfInterests.Where(r=>r.Id == CityId && r.Id == PointOfInterestId).ToListAsync();
            return pointointerstincity;

        }
    }
}
