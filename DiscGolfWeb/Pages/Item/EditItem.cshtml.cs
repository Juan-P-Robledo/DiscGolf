using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace DiscGolfWeb.Pages.Item
{
    [Authorize(Policy = "AdminOnly")]
    [BindProperties]
    public class EditItemModel : PageModel
    {
        public Items Item { get; set; } = new Items();

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public void OnGet(int id)
        {
            PopulateMenuItem(id);
            PopulateSpecificationsDDL();
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE Products SET Code=@ItemCode, Name=@ItemName, Description=@ItemDescription, Price=@ItemPrice, Brand=@ItemBrand, CategoryID=@ItemCategory, Image=@ItemImage WHERE ProductID=@itemId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@ItemCode", Item.ItemCode);
                    cmd.Parameters.AddWithValue("@ItemName", Item.ItemName);
                    cmd.Parameters.AddWithValue("@ItemDescription", Item.ItemDescription);
                    cmd.Parameters.AddWithValue("@ItemPrice", Item.ItemPrice);
                    cmd.Parameters.AddWithValue("@ItemBrand", Item.ItemBrand);
                    cmd.Parameters.AddWithValue("@ItemCategory", Item.ItemCategory);
                    cmd.Parameters.AddWithValue("@ItemImage", Item.ItemImage);
                    cmd.Parameters.AddWithValue("@itemId", id);

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

        private void PopulateMenuItem(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT ProductID, Code, Name, Description, Price, Brand, CategoryID, Image FROM Products WHERE ProductID=@itemId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@itemId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Item.ItemID = id;
                    Item.ItemCode = reader.GetString(1);
                    Item.ItemName = reader.GetString(2);
                    Item.ItemDescription = reader.GetString(3);
                    Item.ItemPrice = reader.GetDecimal(4);
                    Item.ItemBrand = reader.GetString(5);
                    Item.ItemCategory = reader.GetInt32(6);
                    Item.ItemImage = reader.GetString(7);

                }
            }
        }
    }
}
