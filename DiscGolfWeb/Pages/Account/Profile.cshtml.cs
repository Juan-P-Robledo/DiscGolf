using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DiscGolfWeb.Model;

namespace DiscGolfWeb.Pages.Account
{
    public class ProfileModel : PageModel
    {
        
        public Profile profile {  get; set; }
        public void OnGet()
        {
        profile = new Profile();
            profile.FirstName = "Hi";
            profile.LastName = "Hello";
            profile.Email = "hi@gmail.com";
            profile.Phone = "1234567890";
            //profile.LastLoginTime = DateTime.now;
        }
    }
}
