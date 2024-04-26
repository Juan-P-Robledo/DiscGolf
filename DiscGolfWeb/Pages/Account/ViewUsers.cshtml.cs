using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DiscGolfWeb.Pages.Account
{
    [Authorize(Policy = "AdminOnly")]
    [BindProperties]
    public class ViewUsersModel : PageModel
    {
        
        public List<Person> Users { get; set; } = new List<Person>();
        public void OnGet()
        {
            PopulateUsers();
        }

        private void PopulateUsers()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Phone, LastLoginTime, UserID FROM Users ORDER BY LastName DESC";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open(); 
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var person = new Person();
                        person.FirstName = reader.GetString(0);
                        person.LastName = reader.GetString(1);
                        person.Email = reader.GetString(2);
                        person.Phone = reader.GetString(3);
                        person.LastLoginTime = reader.GetDateTime(4);
                        person.PersonId = reader.GetInt32(5);
                        Users.Add(person);
                    }
                }
            }
        }
    }
}
