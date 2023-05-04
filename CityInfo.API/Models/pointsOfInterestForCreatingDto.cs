using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class pointsOfInterestForCreatingDto
    {
        [Required(ErrorMessage ="You cannot leave the name field blank")]
        [MaxLength(50,ErrorMessage ="Length cannot exceed 50 characters")]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
