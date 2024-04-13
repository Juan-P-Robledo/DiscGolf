using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using DiscGolfBusiness;
using DiscGolfWeb.Model;
using System.ComponentModel.DataAnnotations;


namespace DiscGolfWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginUser { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        { 
            if (ModelState.IsValid)
            {

                

                if(ValidateCredentials())
                {
                    return RedirectToPage("Profile");
                }
                else
                {

                    ModelState.AddModelError("LoginError", "Invalid credentials. Try Again");

                    return Page();
                }
            }
            else
            {

                

                return Page();
            }
        }


        private IActionResult ProcessLogin()
        {
        
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {

                    string cmdText = "SELECT Password FROM Users WHERE Email=@email";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@email", LoginUser.Email);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (!reader.IsDBNull(0))
                        {
                            string passwordHash = reader.GetString(0);
                            if (SecurityHelper.VerifyPassword(LoginUser.Password, passwordHash))
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


        private bool ValidateCredentials()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {


                string cmdText = "SELECT Password FROM Users WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);

                cmd.Parameters.AddWithValue("@email", LoginUser.Email);
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
                        if (SecurityHelper.VerifyPassword(LoginUser.Password, passwordHash))
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

        private void UpdateLastLoginTime(int userId)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "UPDATE Person SET LastLoginTime=@lastLoginTime WHERE UserId=@userId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@userId", userId);
                conn.Open();
                cmd.ExecuteNonQuery();



            }
        }
    }
}
