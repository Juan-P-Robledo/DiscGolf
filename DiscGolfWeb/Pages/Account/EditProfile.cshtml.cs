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
    public class EditProfileModel : PageModel
    {
        public Person Person { get; set; } = new Person();

        public void OnGet(int id)
        {
            PopulateUser(id);

        }

        public IActionResult OnPost(int id)
        {

            // Check if the request is for deletion
            if (Request.Form["Delete"] == "true")
            {
                // Call the method to delete the item
                DeleteUser(id);
                return RedirectToPage("ViewUsers");
            }
            else
            {
                ModelState.Remove("Person.Password");
                if (ModelState.IsValid)
                {
                   
                    using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                        {
                            string cmdText = "UPDATE Users SET FirstName=@FirstName, LastName=@LastName, Phone=@Phone, Email=@Email WHERE UserID=@userId";
                            SqlCommand cmd = new SqlCommand(cmdText, conn);
                            cmd.Parameters.AddWithValue("@FirstName", Person.FirstName);
                            cmd.Parameters.AddWithValue("@LastName", Person.LastName);
                            cmd.Parameters.AddWithValue("@Phone", Person.Phone);
                            cmd.Parameters.AddWithValue("@Email", Person.Email);
                            
                            cmd.Parameters.AddWithValue("@userId", id);


                            conn.Open();
                            cmd.ExecuteNonQuery();
                            return RedirectToPage("Profile");
                        }
                   
              
                }
                else
                {

                    return Page();

                }
            }
        }

        private void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Users WHERE UserID=@userId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@userId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void PopulateUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Password, Phone FROM Users WHERE UserID=@userId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Person.PersonId = id;
                    Person.FirstName = reader.GetString(0);
                    Person.LastName = reader.GetString(1);
                    Person.Email = reader.GetString(2);
                    Person.Password = reader.GetString(3);
                    Person.Phone = reader.GetString(4);
                    
                }
            }
        }
    }
}
