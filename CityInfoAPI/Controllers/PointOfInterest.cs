using CityInfoAPI.Models;
using CityInfoAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Xml.XPath;

namespace CityInfoAPI.Controllers
{
    [Route("api/Cities/{CityId}/PointOfInterest")]
    [ApiController]

    public class PointOfInterest : ControllerBase
    {
        private readonly ILogger<PointOfInterest> _logger;
        private readonly CitiesDataStore _citiesDataStore;
        private readonly IMailService _mailService;

        public PointOfInterest(ILogger<PointOfInterest> logger , CitiesDataStore citiesDataStore , IMailService mailService)
        {
            _logger = logger;
            _citiesDataStore = citiesDataStore;
            _mailService = mailService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterests>> GetPointOfCities(int Cityid)
        {
            try
            {
                var citieswithpoints = _citiesDataStore.Cities.FirstOrDefault(r => r.Id == Cityid);
                if (citieswithpoints == null)
                {
                    throw new Exception($"City with ID {Cityid} not found.");
                }
                else
                {
                    return Ok(citieswithpoints.pointOfInterests);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error happened while getting your city {Cityid}.", ex);
                return StatusCode(500, $"Couldn't Handle Your Request: {ex.Message}");
            }
        }


        [HttpGet("{pointofinterestId}" , Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterest> GetPointOfInterest(int Cityid, int pointofinterestId)
        {

            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == Cityid);
            if (city == null)
            {
                return NotFound("City not found");
            }

            var pointOfInterest = city.pointOfInterests.FirstOrDefault(p => p.Id == pointofinterestId);
            if (pointOfInterest == null)
            {
                return NotFound("Point of interest not found");
            }

            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterest> cratepointofinterest(int  Cityid, PointOfInterestCreatingDtos pointOfInterestCreatingDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            } 

            var city = _citiesDataStore.Cities.FirstOrDefault(c=>c.Id == Cityid);
            if(city == null)
            {
                return NotFound();
            }
            var maxpointofinterestRN = _citiesDataStore.Cities.SelectMany(c=>c.pointOfInterests).Max(poi=>poi.Id);

            var Nopointofinterst = new PointOfInterests()
            {
                Id = ++maxpointofinterestRN,
                Name = city.Name,
                Description = city.Description,

            };
            city.pointOfInterests.Add(Nopointofinterst);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    Cityid = Cityid,
                    PointofinterestId = Nopointofinterst.Id,
                },
                Nopointofinterst);

        }

        [HttpPut("{pointofinterestId}")]
        public ActionResult UpdatePointofinterest(int cityid , int pointofinterestId , UpdatingPointOfInterestDto pointOfInterestDto)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c=>c.Id ==  cityid);
            if(city == null)
            {
                return NotFound();
            }
            var pointofinterest = _citiesDataStore.Cities.FirstOrDefault(r=>r.Id == pointofinterestId);
            if(pointofinterest == null)
            {
                return NotFound();
            }

            pointOfInterestDto.Name = pointOfInterestDto.Name;
            pointOfInterestDto.Description = pointOfInterestDto.Description;

            return NoContent();



        }

        [HttpPatch("{pointofinterestId}")]

        public ActionResult UpdatePartiallyPointOfInterest(int cityid , int pointofinterstId , JsonPatchDocument<UpdatingPointOfInterestDto> updatingPointOfInterestDto)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c=>c.Id == cityid);
            if(city == null)
            {
                return NotFound();
            }
            var pointofinterest = _citiesDataStore.Cities.FirstOrDefault(r=>r.Id==pointofinterstId);
            if(pointofinterest == null)
            {
                return NotFound();
            }
            var pointofinterestToPatch = new UpdatingPointOfInterestDto()
            {
                Name = pointofinterest.Name,
                Description = pointofinterest.Description,
            };

            updatingPointOfInterestDto.ApplyTo(pointofinterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pointofinterest.Name = pointofinterestToPatch.Name;
            pointofinterest.Description = pointofinterestToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{pointofinterestId}")]
        public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestToRemove = city.pointOfInterests.FirstOrDefault(p => p.Id == pointOfInterestId);
            if (pointOfInterestToRemove == null)
            {
                return NotFound();
            }

            city.pointOfInterests.Remove(pointOfInterestToRemove);
            _mailService.Send(
                "Point of interest deleted.",
                $"Point of interest {pointOfInterestToRemove.Name} with id {pointOfInterestToRemove.Id} was deleted.");


            return NoContent();
        }



    }
}
