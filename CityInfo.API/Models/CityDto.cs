using CityInfo.API.Models;
namespace CityInfo.API.Models
{
    public class CityDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int? numberofpointsofinterest
        {
            get {
                return pointsofinterest.Count;
            }
        }

        public List<pointsOfInterestDto>? pointsofinterest { get; set; } = new List<pointsOfInterestDto>();
        

        


        /*public CityDto(int id,string name, string description,List<pointsOfInterestDto> pointsofinterest_)
        {
            Id = id;
            Name = name;
            Description = description;
            this.pointsofinterest = pointsofinterest_;
        }*/
    }
}
