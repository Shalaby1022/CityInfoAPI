using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CityInfoAPI.Controllers
{
    [Route("api/Cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<CityDto> GetCitites()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetOneCity(int id)
        {
            var citytoreturn = CitiesDataStore.Current.Cities.FirstOrDefault(r=>r.Id == id);
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
