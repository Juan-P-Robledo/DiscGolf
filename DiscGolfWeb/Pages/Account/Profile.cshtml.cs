
using DiscGolfBusiness;

using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;


namespace DiscGolfWeb.Pages.Account
{
    [Authorize]
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

            String email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Phone FROM Users WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    ProfileUser.FirstName = reader.GetString(0);
                    ProfileUser.LastName = reader.GetString(1);
                    ProfileUser.Email = email;
                    ProfileUser.Phone = reader.GetString(2);
                   // Profile.LastLoginTime = reader.GetDateTime;
                }
            }

        }
    }
}
