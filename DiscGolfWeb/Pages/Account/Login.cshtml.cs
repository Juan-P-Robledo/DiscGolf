using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using DiscGolfBusiness;
using DiscGolfWeb.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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

              //  string cmdText = "SELECT Password FROM Users WHERE Email=@email";
                string cmdText = "SELECT Password, UserID, FirstName FROM Users WHERE Email=@email"; 
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

                            string name = reader.GetString(2);
                           
                            //1. Create a list of claims
                            Claim emailClaim = new Claim(ClaimTypes.Email, LoginUser.Email);
                            Claim nameClaim = new Claim(ClaimTypes.Name, name);

                            List<Claim> claims = new List<Claim> { emailClaim, nameClaim };

                            //2. Create a Claims Identity
                            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            //3. Create a ClaimsPrincipal
                            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                            //4. Create an authentication cookie
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);





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
    }
}
