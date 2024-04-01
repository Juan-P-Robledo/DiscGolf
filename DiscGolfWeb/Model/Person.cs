using System.ComponentModel.DataAnnotations;

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
        public string Password { get; set; }

        [Display(Name = "Phone (Optional)")]
         public string Phone { get; set; }

    }
}
