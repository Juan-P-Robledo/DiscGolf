using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using DiscGolfWeb.Model;
using DiscGolfBusiness;

namespace DiscGolfWeb.Pages.Account
{

    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Person NewPerson { get; set; }
        
        public void OnGet()
        {

        }
        public ActionResult OnPost()    
        {
            if (ModelState.IsValid)
            {
                if (!EmailExists(NewPerson.Email))
                {
                    RegisterUser();
                    return RedirectToPage("Login");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "The email already exists. Try a different one.");
                    return Page();
                }
            }
            else
            {
                return Page();
            }
            
        }

        private void RegisterUser()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                String cmdText = "INSERT INTO Users(Firstname, LastName, Email, Password, Phone)" +
                    "VALUES(@firstName, @lastName, @email, @password, @phone)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
                cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratedPasswordHash(NewPerson.Password));
                cmd.Parameters.AddWithValue("@phone", NewPerson.Phone);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private bool EmailExists(string email)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                String cmdText = "SELECT * FROM Users WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
