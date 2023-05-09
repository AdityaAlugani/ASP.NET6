using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities
{
    public class PointsOfInterest
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }=string.Empty;

        public string? Description { get; set; }


        [ForeignKey("cityId")]
        public City? city { get; set; }
        public int cityId { get; set; }

    }
}
