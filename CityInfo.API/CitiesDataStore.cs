using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> cities;
        static public CitiesDataStore citystore = new CitiesDataStore()
        {
            cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id= 1,
                    Name= "New York",
                    Description= "American city",
                    pointsofinterest= new List<pointsOfInterestDto>() {
                        new pointsOfInterestDto(){id=1,Name="name",description="description" },
                        new pointsOfInterestDto(){id=2,Name="name2",description="description2" }
                    }
                },
                new CityDto(){
                    Id=2,
                    Name="Hyderabad",
                    Description="Indian City",
                    pointsofinterest= new List<pointsOfInterestDto>() {
                        new pointsOfInterestDto(){id=3,Name="name",description="description" },
                        new pointsOfInterestDto(){id=4,Name="name2",description="description2" },
                        new pointsOfInterestDto(){id=5,Name="name3",description="description3" }
                    }
                },
                new CityDto()
                { 
                    Id=3,
                    Name="Jerussalam",
                    Description="Isaraeili city",
                    pointsofinterest=new List<pointsOfInterestDto>() {
                        new pointsOfInterestDto(){id=6,Name="name",description="description" },
                        new pointsOfInterestDto(){id=7,Name="name2",description="description2" },
                        new pointsOfInterestDto(){id=8,Name="name3",description="description3" }
                    }
                }
            }
        };
    }
}
