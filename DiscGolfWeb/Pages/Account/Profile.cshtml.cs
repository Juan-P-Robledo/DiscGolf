using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiscGolfWeb.Pages.Account
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public Profile ProfileUser { get; set; } = new Profile();
        public void OnGet()
        {
            PopulateProfile();
            
        }

        private void PopulateProfile()
        {
            ProfileUser = new Profile();
            ProfileUser.FirstName = "Juan";
            ProfileUser.LastName = "Robledo";
            ProfileUser.Email = "Robledojp@jacks.sfasu.edu";
            ProfileUser.Password = "Poop";
            ProfileUser.Phone = "None";
        }
    }
}
