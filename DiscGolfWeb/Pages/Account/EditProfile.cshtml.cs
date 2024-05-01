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
                if (ModelState.IsValid)
                {
                    
                    string confirmPassword = Request.Form["ConfirmPassword"];

                    
                    if (ValidateCredentials(confirmPassword))
                    {
                        using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                        {
                            string cmdText = "UPDATE Users SET FirstName=@FirstName, LastName=@LastName, Phone=@Phone, Email=@Email, Password=@Password WHERE UserID=@userId";
                            SqlCommand cmd = new SqlCommand(cmdText, conn);
                            cmd.Parameters.AddWithValue("@FirstName", Person.FirstName);
                            cmd.Parameters.AddWithValue("@LastName", Person.LastName);
                            cmd.Parameters.AddWithValue("@Phone", Person.Phone);
                            cmd.Parameters.AddWithValue("@Email", Person.Email);
                            cmd.Parameters.AddWithValue("@Password", SecurityHelper.GeneratedPasswordHash(Person.Password));
                            cmd.Parameters.AddWithValue("@userId", id);


                            conn.Open();
                            cmd.ExecuteNonQuery();
                            return RedirectToPage("Profile");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ConfirmPassword", "The confirm password does not match the current password.");
                        return Page();
                    }
                    
                    
                }
                else
                {

                    return Page();

                }
            }
        }

        private IActionResult ProcessChangePassword()
        {

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {

                string cmdText = "SELECT Password FROM Users WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", Person.Email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.VerifyPassword(Person.Password, passwordHash))
                        {
                            return RedirectToPage("/Index");
                        }
                        else
                        {
                            ModelState.AddModelError("LoginError", "Invalid credentials. Try Again");
                            return Page();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("LoginError", "Invalid credentials. Try Again");
                        return Page();
                    }

                }
                else
                {
                    ModelState.AddModelError("LoginError", "Invalid credentials. Try Again");
                    return Page();
                }
            }

        }
        private bool ValidateCredentials(string ConfirmPassword)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {


                //  string cmdText = "SELECT Password FROM Users WHERE Email=@email";
                string cmdText = "SELECT Password, UserID, FirstName, isAdmin FROM Users WHERE Email=@email";

                SqlCommand cmd = new SqlCommand(cmdText, conn);

                cmd.Parameters.AddWithValue("@email", Person.Email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    if (reader.IsDBNull(0))
                    {
                        return false;
                    }
                    else
                    {
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.VerifyPassword(ConfirmPassword, passwordHash))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }


                }
                else
                {
                    return false;
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
