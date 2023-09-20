using AutoMapper;
using CityInfoAPI.Data.Interfaces;
using CityInfoAPI.Entities;
using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CityInfoAPI.Controllers
{
    [Route("api/Cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
       
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository , IMapper mapper )
        {
          
            _cityInfoRepository = cityInfoRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointofinteresrsDTO>>> GetCitites()
        {
            var citiesall = await _cityInfoRepository.GetCitiesAsync();

            // using auto mapper here.
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointofinteresrsDTO>>(citiesall));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCity(int id , bool Includepointofinterest = true)
        {
            var citytoreturn = await _cityInfoRepository.GetCityByIdAsync(id , Includepointofinterest);
            if(citytoreturn == null)
            {
                return NotFound();
            }
            
            if(Includepointofinterest) 
            {
             return Ok(_mapper.Map<CityDto>(citytoreturn));
            }

            return Ok(_mapper.Map<CityWithoutPointofinteresrsDTO>(citytoreturn));
        }


    }
}
