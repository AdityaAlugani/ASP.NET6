using CityInfo.API.Dbcontexts;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _cityInfoContext;
        public CityInfoRepository(CityInfoContext cityInfoContext)
        {
            _cityInfoContext = cityInfoContext;
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            var Cities = await _cityInfoContext.cities.ToListAsync();
            //Console.WriteLine(Cities);
            return Cities;
        }

        
        public async Task<City?> GetCityAsync(int cityId,bool includepointsofinterest)
        {
            if (includepointsofinterest == false)
            return await _cityInfoContext.cities.FirstOrDefaultAsync(c => c.Id == cityId);
            return await _cityInfoContext.cities.Include(c => c.pointsofinterest).FirstOrDefaultAsync(c => c.Id == cityId);   
        }
        public async Task<IEnumerable<PointsOfInterest>> GetPointsOfInterestAsync(int cityId)
        {
            var city = await _cityInfoContext.cities.Include(c => c.pointsofinterest).Where(c => c.Id == cityId).FirstOrDefaultAsync();
            return city.pointsofinterest;
        }

        public async Task<PointsOfInterest?> GetPointOfInterestAsync(int cityId,int pointofinterestid)
        {
            return await _cityInfoContext.pointsOfInterests.Where(p => p.cityId == cityId && p.id==pointofinterestid).FirstOrDefaultAsync();

        }

        public async Task<City?> CityExistsAsync(int cityId)
        {
            return await _cityInfoContext.cities.Include(c => c.pointsofinterest).FirstOrDefaultAsync(c => c.Id == cityId);
        }
    }
}
