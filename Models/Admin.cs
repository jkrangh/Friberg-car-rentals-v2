using System.ComponentModel.DataAnnotations;

namespace Friberg_car_rentals_v2.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required]
        public string AdminFirstName { get; set; }
        [Required]
        public string AdminLastName { get; set; }
        [Required]
        [EmailAddress]
        public string AdminEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
    }
}
