using CityInfoAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Xml.XPath;

namespace CityInfoAPI.Controllers
{
    [Route("api/Cities/{CityId}/PointOfInterest")]
    [ApiController]

    public class PointOfInterest : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterests>> GetPointOfCities(int Cityid)
        {
            var citieswithpoints = CitiesDataStore.Current.Cities.FirstOrDefault(r=>r.Id == Cityid);
            if(citieswithpoints == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(citieswithpoints.pointOfInterests);
            }

        }

        [HttpGet("{pointofinterestId}" , Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterest> GetPointOfInterest(int Cityid, int pointofinterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == Cityid);
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

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id == Cityid);
            if(city == null)
            {
                return NotFound();
            }
            var maxpointofinterestRN = CitiesDataStore.Current.Cities.SelectMany(c=>c.pointOfInterests).Max(poi=>poi.Id);

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
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id ==  cityid);
            if(city == null)
            {
                return NotFound();
            }
            var pointofinterest = CitiesDataStore.Current.Cities.FirstOrDefault(r=>r.Id == pointofinterestId);
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
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id == cityid);
            if(city == null)
            {
                return NotFound();
            }
            var pointofinterest = CitiesDataStore.Current.Cities.FirstOrDefault(r=>r.Id==pointofinterstId);
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



    }
}
