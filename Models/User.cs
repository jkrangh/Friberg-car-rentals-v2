using System.ComponentModel.DataAnnotations;

namespace Friberg_car_rentals_v2.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Förnamn")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

    }
}
