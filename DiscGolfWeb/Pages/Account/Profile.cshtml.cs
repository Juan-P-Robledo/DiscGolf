
using DiscGolfBusiness;

using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Claims;


namespace DiscGolfWeb.Pages.Account
{
   [Authorize]
    [BindProperties]
    public class ProfileModel : PageModel
    {


        
        public Profile profile { get; set; } = new Profile();
        public void OnGet()
        {
            PopulateProfile();
            
        }

        private void PopulateProfile()
        {

            String email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT UserID, FirstName, LastName, Phone, LastLoginTime FROM Users WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    profile.PersonId = reader.GetInt32(0);
                    profile.FirstName = reader.GetString(1);
                    profile.LastName = reader.GetString(2);
                    profile.Email = email;
                    profile.Phone = reader.GetString(3);
                    profile.LastLoginTime = reader.GetDateTime(4);
                   
                }
            }

        }
    }
}
