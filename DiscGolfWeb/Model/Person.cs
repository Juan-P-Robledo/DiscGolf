using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DiscGolfWeb.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required(ErrorMessage = "You must enter the first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter the last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must enter a email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must enter a password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{10,}$", 
        ErrorMessage = "Must be 10 characters long and have at least one letter, digit, and special character.")]
        public string Password { get; set; }

        [Display(Name = "Phone (Optional)")]
         public string? Phone { get; set; }
        [Display(Name ="Last Login Time")]
        public DateTime LastLoginTime { get; set; }


        public bool isAdmin { get; set; }

    }
}
