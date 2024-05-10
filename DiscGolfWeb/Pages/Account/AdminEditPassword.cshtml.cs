using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace DiscGolfWeb.Pages.Account
{
    [Authorize]
    [BindProperties]
    public class AdminEditPasswordModel : PageModel
    {
        public Person Person { get; set; } = new Person();

        public void OnGet(int id)
        {
            PopulateUser(id);

        }

        public IActionResult OnPost(int id)
        {
            ModelState.Remove("Person.FirstName");
            ModelState.Remove("Person.LastName");
            ModelState.Remove("Person.Email");
            ModelState.Remove("Person.Phone");
            ModelState.Remove("Person.LastLoginTime");
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE Users SET Password=@Password WHERE UserID=@userId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@Password", SecurityHelper.GeneratedPasswordHash(Person.Password));
                    cmd.Parameters.AddWithValue("@userId", id);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewUsers");
                }
            }
            else
            {
                return Page();
            }
                             
        }

        


        private void PopulateUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT Password FROM Users WHERE UserID=@userId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Person.Password = reader.GetString(0);
                }
            }



        }
    }
}
