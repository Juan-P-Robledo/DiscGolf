using DiscGolfBusiness;
using DiscGolfWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace DiscGolfWeb.Pages.Menus
{
   
    [BindProperties]
    public class ViewItemsModel : PageModel
    {
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public List<Items> DiscItems { get; set; } = new List<Items>();

        public int SelectedID { get; set; }
        
       public void OnGet()
        {
            PopulateSpecificationDDL();
        }

        public void OnPost() 
        {
            PopulateItems(SelectedID);
            PopulateSpecificationDDL();
        }

        private void PopulateItems(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT Products.Code, Products.Name, Products.Description, Products.Price, Products.ProductID, Products.Image, Products.Brand, Category.CategoryName FROM Products JOIN Category ON Products.CategoryID = Category.CategoryID WHERE Products.CategoryID=@CatID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@CatID", id);
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
                        item.ItemBrand = reader.GetString(6);
                        item.itemCategory = reader.GetString(7);
                        DiscItems.Add(item);
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
    }
    
}
