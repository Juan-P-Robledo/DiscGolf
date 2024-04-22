using System.ComponentModel.DataAnnotations;

namespace DiscGolfWeb.Model
{
    public class Profile
    {

            public int PersonId { get; set; }
            
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            
            public string Email { get; set; }
            
            public string Password { get; set; }

          
            public string? Phone { get; set; }

            public DateTime LastLoginTime { get; set; }
     
    }
}
