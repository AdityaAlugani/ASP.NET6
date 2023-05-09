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
        }
    }
}
