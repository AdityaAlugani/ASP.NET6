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
    }
}
