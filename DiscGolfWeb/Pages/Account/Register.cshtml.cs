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
                //1. Create a database connection string
               // string connString = "Server=(localdb)\\MSSQLLocalDB;Database=DiscGolfDatabase;Trusted_Connection=true;";
                SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString());
                //2. Create a SQL command
                string cmdText = "INSERT INTO Users(Firstname, LastName, Email, Password, Phone)" +
                    "VALUES(@firstName, @lastName, @email, @password, @phone)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
                cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratedPasswordHash(NewPerson.Password));
                cmd.Parameters.AddWithValue("@phone", NewPerson.Phone);

                // cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now.ToString());
                //3. Open the database
                conn.Open();
                //4. Execute the SQL command
                cmd.ExecuteNonQuery();
                //5. Close the Database
                conn.Close();
                /*
                string firstName = NewPerson.FirstName;
                string lastName = NewPerson.LastName;
                string email = NewPerson.Email;
                string password = NewPerson.Password;
                */
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
