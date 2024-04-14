using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace DiscGolfWeb.Pages.Menus
{
    [BindProperties]
    public class ViewItemsModel : PageModel
    {
        public List<SelectListItem> Specifications { get; set; } = new List<SelectListItem>();

        public List<Items> DiscItems { get; set; } = new List<Items>();

        public string SelectedSpecification { get; set; }
        
       public void OnGet()
        {
            PopulateSpecificationDDL();
        }

        public void OnPost() 
        {
            PopulateItems(SelectedSpecification);
            PopulateSpecificationDDL();
        }

        private void PopulateItems(string Spec)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT Code, Name, Description, Price, ProductID, Image FROM Products WHERE Specification=@itemSpec";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@itemSpec", Spec);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var item = new Items();
                        item.ItemCode = reader.GetString(0);
                        item.ItemName = reader.GetString(1);
                        item.ItemDescription = reader.GetString(2);
                        item.ItemPrice = reader.GetDecimal(3);
                        item.ItemID = reader.GetInt32(4);
                        item.ItemImage = reader.GetString(5);
                        DiscItems.Add(item);
                    }
                }
            }
        }

        private void PopulateSpecificationDDL()
        {
            
            Specifications.Add(new SelectListItem { Value = "None", Text = "None" });
            Specifications.Add(new SelectListItem { Value = "Putter", Text = "Putter" });
            Specifications.Add(new SelectListItem { Value = "Midrange", Text = "Midrange" });
            Specifications.Add(new SelectListItem { Value = "Fairway", Text = "Fairway" });
            Specifications.Add(new SelectListItem { Value = "Driver", Text = "Driver" });
        }
    }
    
}
