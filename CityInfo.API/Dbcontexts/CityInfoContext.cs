using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Dbcontexts
{
    public class CityInfoContext:DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> dboptions):base(dboptions)
        {

        }
        public DbSet<City> cities { get; set; }
        public DbSet<PointsOfInterest> pointsOfInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "New York",
                    Description = "American city"
                },
                new City()
                {
                    Id = 2,
                    Name = "Hyderabad",
                    Description = "Indian City"
                },
                new City()
                {
                    Id = 3,
                    Name = "Jerusellam",
                    Description = "Isaraeilian city"
                }
                );
            modelBuilder.Entity<PointsOfInterest>().HasData(
                new PointsOfInterest()
                {
                    id = 1,
                    cityId = 1,
                    Name = "Name",
                    Description = "Description"
                },
                new PointsOfInterest()
                {
                    id = 2,
                    cityId = 1,
                    Name = "Name2",
                    Description = "Description2"
                },
                new PointsOfInterest()
                {
                    id = 3,
                    cityId = 2,
                    Name = "Name",
                    Description = "Description"
                },
                new PointsOfInterest()
                {
                    id = 4,
                    cityId = 2,
                    Name = "Name2",
                    Description = "Description2"
                },
                new PointsOfInterest()
                {
                    id = 5,
                    cityId = 3,
                    Name = "Name",
                    Description = "Description"
                },
                new PointsOfInterest()
                {
                    id = 6,
                    cityId = 3,
                    Name = "Name2",
                    Description = "Description2"
                }
                );
            base.OnModelCreating(modelBuilder);
        }



    }
}
