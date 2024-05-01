using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using System.Linq;
namespace DiscGolfWeb.Pages.Account
{
    [BindProperties]
    [Authorize]
    public class CartModel : PageModel
    {
        public List<Items> CartItems { get; set; } = new List<Items>();

        public Person Person { get; set; } = new Person();

        public decimal TotalPrice {  get; set; }
        public void OnGet(int id)
        {
            PopulateUser();
            PopulateItems();
            TotalPrice = CartItems.Sum(item => item.ItemPrice);
        }

        private void PopulateItems()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT Products.Code, Products.Name, Products.Description, Products.Price, Products.ProductID, Products.Image, Products.Brand, Category.CategoryName FROM Products JOIN Category ON Products.CategoryID = Category.CategoryID  JOIN Cart ON Products.ProductID = Cart.ProductID WHERE Cart.UserID = @UserID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@userID", Person.PersonId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var item = new Items();
                        item.ItemCode = reader.GetString(0);
                        item.ItemName = reader.GetString(1);
                        item.ItemDescription = reader.GetString(2);
                        item.ItemPrice = reader.GetDecimal(3);
                        item.ItemID = reader.GetInt32(4);
                        item.ItemImage = reader.GetString(5);
                        item.ItemBrand = reader.GetString(6);
                        item.itemCategory = reader.GetString(7);
                        CartItems.Add(item);
                    }
                }
            }
        }
        private void PopulateUser()
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT UserID, FirstName, LastName, Phone, LastLoginTime FROM Users WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Person.PersonId = reader.GetInt32(0);
                    Person.FirstName = reader.GetString(1);
                    Person.LastName = reader.GetString(2);
                    Person.Email = email;
                    Person.Phone = reader.GetString(3);
                    Person.LastLoginTime = reader.GetDateTime(4);

                }
            }
        }
    }
}
