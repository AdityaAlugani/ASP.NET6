using CityInfo.API.Models;
namespace CityInfo.API.Models
{
    public class CityDtoWithoutPointsOfInterests
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        

        


        /*public CityDto(int id,string name, string description,List<pointsOfInterestDto> pointsofinterest_)
        {
            Id = id;
            Name = name;
            Description = description;
            this.pointsofinterest = pointsofinterest_;
        }*/
    }
}
