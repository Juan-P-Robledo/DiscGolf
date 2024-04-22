using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace DiscGolfWeb.Pages.Menus
{
    //[Authorize()]
    [BindProperties]
    public class AddItemModel : PageModel
    {
        public Items newItem { get; set; } = new Items();

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
            PopulateSpecificationsDDL();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Products(Code, Name, Description, Price, Brand, Image, CategoryID)" +
                        "VALUES (@ItemCode, @ItemName, @ItemDescription, @ItemPrice, @ItemBrand, @ItemImage, @ItemCategory)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@ItemCode", newItem.ItemCode);
                    cmd.Parameters.AddWithValue("@ItemName", newItem.ItemName);
                    cmd.Parameters.AddWithValue("@ItemDescription", newItem.ItemDescription);
                    cmd.Parameters.AddWithValue("@ItemPrice", newItem.ItemPrice);
                    cmd.Parameters.AddWithValue("@ItemBrand", newItem.ItemBrand);
                    cmd.Parameters.AddWithValue("@ItemImage", newItem.ItemImage);
                    cmd.Parameters.AddWithValue("@ItemCategory", newItem.ItemCategory);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewItems");



                }
            }
            else
            {
                PopulateSpecificationsDDL();
                return Page();
                
            }
        }

        private void PopulateSpecificationsDDL()
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
    }
}
