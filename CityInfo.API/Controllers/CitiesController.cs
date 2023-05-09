using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesDataStore _citiesDataStore;
        private readonly ICityInfoRepository _repository;
        private readonly IMapper _mapper;

        public CitiesController(CitiesDataStore citiesDataStore,ICityInfoRepository repository,IMapper mapper) 
        {
            _citiesDataStore= citiesDataStore;
            _repository = repository;
            _mapper = mapper;   
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDtoWithoutPointsOfInterests>>> getCities()
        {
            var Cities = await _repository.GetCitiesAsync();
            return Ok(_mapper.Map<IEnumerable<CityDtoWithoutPointsOfInterests>>(Cities));  
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getCitiy(int id,bool includepointsofinterest=false)
        {
            var city = await _repository.GetCityAsync(id, includepointsofinterest);
            if (city == null)
                return NotFound();
            return includepointsofinterest == true ? Ok(_mapper.Map<CityDto>(city)) : Ok(_mapper.Map<CityDtoWithoutPointsOfInterests>(city));
        }
    }
}
