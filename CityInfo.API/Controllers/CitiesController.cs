using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> getCities()
        {
            return Ok(CitiesDataStore.citystore.cities);
        }
        [HttpGet("{id}")]
        public ActionResult<CityDto> getCitiy(int id)
        {
            CityDto city=CitiesDataStore.citystore.cities.FirstOrDefault(city => city.Id == id);
            if (city == null)
                return NotFound();
            else
                return Ok(city);
        }
    }
}
