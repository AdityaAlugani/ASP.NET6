namespace CityInfo.API.Models
{
    public class pointsOfInterestDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string? description { get; set; }

        /*public pointsOfInterestDto(int Id,string name,string des) 
        {
            id=Id;
            Name=name;
            description=des;
        }*/

    }
}
