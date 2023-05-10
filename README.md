# ASP.NET6

using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CityInfo.API.Entities;
using System;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityid}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterest : ControllerBase
    {
        private readonly ILogger<PointsOfInterest> _logger;
        private readonly IMailService _mailservice;
        private readonly CitiesDataStore _citiesDataStore;
        private readonly ICityInfoRepository _context;
        private readonly IMapper _mapper;
        public PointsOfInterest(ILogger<PointsOfInterest> logger,IMailService mailservice, CitiesDataStore citiesDataStore,ICityInfoRepository context,IMapper mapper)
        {
            _logger = logger;
            _mailservice = mailservice;
            _citiesDataStore = citiesDataStore;
            _context=context;
            _mapper=mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<pointsOfInterestDto>>> getPoints(int cityId)
        {
            var city=await _context.CityExistsAsync(cityId);
            if(city==null)
            return NotFound();
            //console.log(city);
            return Ok(_mapper.Map<IEnumerable<pointsOfInterestDto>>(city.pointsofinterest));
            
        }
        [HttpGet("{id}",Name ="getpoint")]
        public async Task<ActionResult<pointsOfInterestDto>> getPoint(int cityid,int id)
        {

            var city=await _context.CityExistsAsync(cityid);
            if(city==null)
            return NotFound();
            var place=await _context.GetPointOfInterestAsync(cityid,id);
            return place!=null?Ok(_mapper.Map<pointsOfInterestDto>(place)):NotFound();
        }
        [HttpPost("createpointofinterest")]
        public async Task<ActionResult<pointsOfInterestDto>> createpointofinterest(int cityid, [FromBody] pointsOfInterestForCreatingDto creation)
        {
            var city=await _context.GetCityAsync(cityid,false);
            if(city==null)
            return NotFound();
            
            var newlycreatedEntity=_mapper.Map<Entities.PointsOfInterest>(creation);
            city.pointsofinterest.Add(newlycreatedEntity);

            bool c=await _context.SavedChangesAsync();
            //console.log(c);

            var newlycreatedDto=_mapper.Map<pointsOfInterestDto>(newlycreatedEntity);

            return CreatedAtRoute("getpoint", new { cityid = cityid, id = newlycreatedEntity.id }, newlycreatedDto);
        }
        [HttpPut("{pointofinterestid}")]
        public async Task<ActionResult> UpdatePointOfInterest(int cityid,int pointofinterestid, [FromBody] UpdatePointOfInterestDto update)
        {
            
            
            if(await _context.CityExistsAsync(cityid)==null)
            return NotFound("City not found");

            var pointofinterestretrived=await _context.GetPointOfInterestAsync(cityid,pointofinterestid);
            if(pointofinterestretrived==null)
            return NotFound("Point of interest not retrived");

            // pointofinterestretrived.Name=update.Name;
            // pointofinterestretrived.Description=update.Description;   
            _mapper.Map(update,pointofinterestretrived);

            await _context.SavedChangesAsync();

            return NoContent();

        }
        [HttpPatch("{pointofinterestid}")]
        public async Task<ActionResult> PartialUpdatePointOfInterest(int cityid, int pointofinterestid, [FromBody] JsonPatchDocument<UpdatePointOfInterestDto> Patch)
        {

            if(await _context.CityExistsAsync(cityid)==null)
            return NotFound("City not found");

            var pointofinterestretrived=await _context.GetPointOfInterestAsync(cityid,pointofinterestid);
            if(pointofinterestretrived==null)
            return NotFound("Point of interest not retrived");

            var newpoiDto=_mapper.Map<UpdatePointOfInterestDto>(pointofinterestretrived);
            Patch.ApplyTo(newpoiDto,ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!TryValidateModel(newpoiDto))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(newpoiDto,pointofinterestretrived);
            await _context.SavedChangesAsync();

            return NoContent();
        }
        [HttpDelete("{pointofinterestid}")]
        public async Task<ActionResult> Deletepointofinterest(int cityid,int pointofinterestid)
        {
            var city=await _context.CityExistsAsync(cityid);
            if(city==null)
            return NotFound("City not found");

            var pointofinterestretrived=await _context.GetPointOfInterestAsync(cityid,pointofinterestid);
            if(pointofinterestretrived==null)
            return NotFound("Point of interest not retrived");

            city.pointsofinterest.Remove(pointofinterestretrived);
            await _context.SavedChangesAsync();

            _mailservice.send("Deleted successfully", $"Deleted pointofinterest {pointofinterestid}");
            return NoContent();

        }

    }
}


  
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

  
  
  
public async Task<bool> SavedChangesAsync()
        {
            int n=await _cityInfoContext.SaveChangesAsync();
            return n>=1;
        }
  
  
  
  
  
  
  
  using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        public Task<IEnumerable<City>> GetCitiesAsync();
        public Task<City?> GetCityAsync(int cityId,bool includepointsofinterest);
        public Task<IEnumerable<PointsOfInterest>> GetPointsOfInterestAsync(int cityId);
        public Task<PointsOfInterest?> GetPointOfInterestAsync(int cityId,int pointofinterestid);
        public Task<City?> CityExistsAsync(int cityId);
        public Task<bool> SavedChangesAsync();
    }
}

  
  
  using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;

namespace CityInfo.API.Profiles
{
    public class CityProfile:Profile
    {
        public CityProfile() 
        {
            CreateMap<City,CityDtoWithoutPointsOfInterests>();
            CreateMap<City, CityDto>();

        }
    }
}

  
  
  
  
  using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;

namespace CityInfo.API.Profiles
{
    public class pointsofinterestprofile:Profile
    {
        public pointsofinterestprofile() 
        {
            CreateMap<PointsOfInterest,pointsOfInterestDto>();

            CreateMap<PointsOfInterest,pointsOfInterestForCreatingDto>();

            CreateMap<pointsOfInterestForCreatingDto,PointsOfInterest>();

            CreateMap<UpdatePointOfInterestDto,PointsOfInterest>();
            
            CreateMap<PointsOfInterest,UpdatePointOfInterestDto>();
            
        }
    }
}

  
  
  
