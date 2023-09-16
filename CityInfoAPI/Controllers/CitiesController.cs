using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CityInfoAPI.Controllers
{
    [Route("api/Cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesDataStore _citiesDataStore;

        public CitiesController(CitiesDataStore citiesDataStore )
        {
            _citiesDataStore = citiesDataStore;
        }


        [HttpGet]
        public ActionResult<CityDto> GetCitites()
        {
            return Ok(_citiesDataStore.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetOneCity(int id)
        {
            var citytoreturn = _citiesDataStore.Cities.FirstOrDefault(r=>r.Id == id);
            if(citytoreturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(citytoreturn);
            }
        }

    }
}
