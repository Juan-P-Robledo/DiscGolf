using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;

namespace DiscGolfWeb.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public List<SelectListItem> Filters { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public List<Items> DiscItems { get; set; } = new List<Items>();

        public Person Person { get; set; } = new Person();

        public int SelectedID { get; set; }

        public int SelectedFilterID { get; set; }


        public void OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                PopulateUser();
            }
           
            PopulateItems(SelectedID, SelectedFilterID);
            PopulateFilterDDL();
            PopulateSpecificationDDL();
        }

        public void OnPost() 
        {
            if (User.Identity.IsAuthenticated)
            {
                PopulateUser();
            }

            PopulateItems(SelectedID, SelectedFilterID);
            PopulateSpecificationDDL();
            PopulateFilterDDL();
            
            
        }


        private void PopulateItems(int catID, int filID)
        {

            if (catID > 1)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "SELECT Products.Code, Products.Name, Products.Description, Products.Price, Products.ProductID, Products.Image, Products.Brand, Category.CategoryName FROM Products JOIN Category ON Products.CategoryID = Category.CategoryID WHERE Products.CategoryID=@CatID";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@CatID", catID);

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
                            DiscItems.Add(item);
                        }
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "SELECT Products.Code, Products.Name, Products.Description, Products.Price, Products.ProductID, Products.Image, Products.Brand, Category.CategoryName FROM Products JOIN Category ON Products.CategoryID = Category.CategoryID";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
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
                            DiscItems.Add(item);
                        }
                    }
                }
            }
                if(filID == 1)
                {
                    DiscItems = DiscItems.ToList();

                }
                if (filID == 2)
                {
                    DiscItems = DiscItems.OrderBy(item => item.ItemName).ToList();

                }
                if(filID == 3)
                {
                    DiscItems = DiscItems.OrderByDescending(item => item.ItemName).ToList();

                }
                if (filID == 4)
                {
                    DiscItems = DiscItems = DiscItems.OrderBy(item => item.ItemPrice).ToList(); 
                }
                if(filID == 5)
                {
                    DiscItems = DiscItems.OrderByDescending(item => item.ItemPrice).ToList();

                }

            
        }

        public IActionResult OnPostAddToCollection(int itemId, int userId)
        {
           
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Collection(ProductID, UserID) VALUES (@itemID, @userID)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@itemID", itemId);
                    cmd.Parameters.AddWithValue("@userID", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("/Index");
                }
            
        }
        private void PopulateFilterDDL()
        {

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FilterID, FilterName FROM Filter";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var filter = new SelectListItem();
                        filter.Value = reader.GetInt32(0).ToString();
                        filter.Text = reader.GetString(1);
                        Filters.Add(filter);
                    }
                }
            }
        }
        private void PopulateSpecificationDDL()
        {

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT CategoryID, CategoryName FROM Category";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var category = new SelectListItem();
                        category.Value = reader.GetInt32(0).ToString();
                        category.Text = reader.GetString(1);
                        Categories.Add(category);
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
