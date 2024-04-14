using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace DiscGolfWeb.Pages.Menus
{
    [BindProperties]
    public class EditItemModel : PageModel
    {
        public Items Item { get; set; } = new Items();

        public List<SelectListItem> Specifications { get; set; } = new List<SelectListItem>();
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
                    string cmdText = "UPDATE Products SET Code=@ItemCode, Name=@ItemName, Description=@ItemDescription, Price=@ItemPrice, Specification=@Specification, Image=@ItemImage WHERE ProductID=@itemId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@ItemCode", Item.ItemCode);
                    cmd.Parameters.AddWithValue("@ItemName", Item.ItemName);
                    cmd.Parameters.AddWithValue("@ItemDescription", Item.ItemDescription);
                    cmd.Parameters.AddWithValue("@ItemPrice", Item.ItemPrice);
                    cmd.Parameters.AddWithValue("@Specification", Item.Specification);
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
            Specifications.Add(new SelectListItem { Value = "None", Text = "None" });
            Specifications.Add(new SelectListItem { Value = "Putter", Text = "Putter" });
            Specifications.Add(new SelectListItem { Value = "Midrange", Text = "Midrange" });
            Specifications.Add(new SelectListItem { Value = "Fairway", Text = "Fairway" });
            Specifications.Add(new SelectListItem { Value = "Driver", Text = "Driver" });
        }

        private void PopulateMenuItem(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT ProductID, Code, Name, Description, Price, Specification, Image FROM Products WHERE ProductID=@itemId";
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
                    Item.Specification = reader.GetString(5);
                    Item.ItemImage = reader.GetString(6);

                }
            }
        }
    }
}
