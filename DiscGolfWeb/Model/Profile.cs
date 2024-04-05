using System.ComponentModel.DataAnnotations;

namespace DiscGolfWeb.Model
{
    public class Profile
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
    }
}
