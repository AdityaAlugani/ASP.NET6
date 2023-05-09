using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityid}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterest : ControllerBase
    {
        private readonly ILogger<PointsOfInterest> _logger;
        private readonly IMailService _mailservice;
        private readonly CitiesDataStore _citiesDataStore;
        public PointsOfInterest(ILogger<PointsOfInterest> logger,IMailService mailservice, CitiesDataStore citiesDataStore)
        {
            _logger = logger;
            _mailservice = mailservice;
            _citiesDataStore = citiesDataStore;
        }
        [HttpGet]
        public ActionResult<IEnumerable<pointsOfInterestDto>> getPoints(int cityId)
        {
            try
            {
                //throw new Exception("demo exception");
                CityDto city = _citiesDataStore.cities.FirstOrDefault(city => city.Id == cityId);
                if (city == null)
                {
                    _logger.LogInformation("The City you are trying to find is not found");
                    return NotFound();
                }
                return Ok(city.pointsofinterest);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception occured while fetching the city",ex);
                return StatusCode(500, "Internal server Error");
            }            
        }
        [HttpGet("{id}",Name ="getpoint")]
        public ActionResult<pointsOfInterestDto> getPoint(int cityid,int id)
        {
            CityDto city = _citiesDataStore.cities.FirstOrDefault(city => city.Id == cityid);
            if (city == null)
            {
                return NotFound();
            }
            pointsOfInterestDto place = city.pointsofinterest.FirstOrDefault(interest => interest.id == id);
            if(place==null)
                return NotFound();
            return Ok(place);
        }
        [HttpPost("createpointofinterest")]
        public ActionResult<pointsOfInterestDto> createpointofinterest(int cityid, [FromBody] pointsOfInterestForCreatingDto creation)
        {
            CityDto city= _citiesDataStore.cities.FirstOrDefault(city=>city.Id==cityid);
            if (city == null)
                return NotFound();
            int max_id= _citiesDataStore.cities.SelectMany(city => city.pointsofinterest).Max(pointinterest => pointinterest.id);
            pointsOfInterestDto newlycreated = new pointsOfInterestDto()
            {
                id = ++max_id,
                description = creation.Description,
                Name = creation.Name
            };
            city.pointsofinterest.Add(newlycreated);
            return CreatedAtRoute("getpoint", new { cityid = cityid, id = max_id }, newlycreated);
        }
        [HttpPut("{pointofinterestid}")]
        public ActionResult UpdatePointOfInterest(int cityid,int pointofinterestid, [FromBody] UpdatePointOfInterestDto update)
        {
            
            CityDto city= _citiesDataStore.cities.FirstOrDefault(city=>city.Id==cityid);
            if(city == null) 
                return NotFound();


            pointsOfInterestDto interest = city.pointsofinterest.FirstOrDefault(pointofI => pointofI.id == pointofinterestid);
            if(interest == null) 
                return NotFound();
            
            
            interest.Name=update.Name;
            interest.description=update.Description;


            return NoContent();
        }
        [HttpPatch("{pointofinterestid}")]
        public ActionResult PartialUpdatePointOfInterest(int cityid, int pointofinterestid, [FromBody] JsonPatchDocument<UpdatePointOfInterestDto> Patch)
        {

            CityDto city = _citiesDataStore.cities.FirstOrDefault(city => city.Id == cityid);
            if (city == null)
                return NotFound();


            pointsOfInterestDto interest = city.pointsofinterest.FirstOrDefault(pointofI => pointofI.id == pointofinterestid);
            if (interest == null)
                return NotFound();


            UpdatePointOfInterestDto updatedpoint = new UpdatePointOfInterestDto()
            {
                Name = interest.Name,
                Description = interest.description
            };

            Patch.ApplyTo(updatedpoint, ModelState);
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!TryValidateModel(updatedpoint))
            {
                return BadRequest(ModelState);
            }
            interest.Name = updatedpoint.Name;
            interest.description = updatedpoint.Description;
            return NoContent();
        }
        [HttpDelete("{pointofinterestid}")]
        public ActionResult Deletepointofinterest(int cityid,int pointofinterestid)
        {
            CityDto city= _citiesDataStore.cities.FirstOrDefault(c => c.Id == cityid);
            if (city == null) return NotFound();
            pointsOfInterestDto interest = city.pointsofinterest.FirstOrDefault(interest => interest.id == pointofinterestid);
            if(interest== null) return NotFound();

            city.pointsofinterest.Remove(interest);
            _mailservice.send("Deleted successfully", $"Deleted pointofinterest {pointofinterestid}");
            return NoContent();

        }

    }
}
