using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace DiscGolfWeb.Pages.Menus
{
    [BindProperties]
    public class AddItemModel : PageModel
    {
        public Items newItem { get; set; } = new Items();

        public List<SelectListItem> Specifications { get; set; } = new List<SelectListItem>();
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
                    string cmdText = "INSERT INTO Products(Code, Name, Description, Price, Specification, Image)" +
                        "VALUES (@ItemCode, @ItemName, @ItemDescription, @ItemPrice, @Specification, @ItemImage)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@ItemCode", newItem.ItemCode);
                    cmd.Parameters.AddWithValue("@ItemName", newItem.ItemName);
                    cmd.Parameters.AddWithValue("@ItemDescription", newItem.ItemDescription);
                    cmd.Parameters.AddWithValue("@ItemPrice", newItem.ItemPrice);
                    cmd.Parameters.AddWithValue("@Specification", newItem.Specification);
                    cmd.Parameters.AddWithValue("@ItemImage", newItem.ItemImage);

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
    }
}
