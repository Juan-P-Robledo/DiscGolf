using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace DiscGolfWeb.Model
{
    public class Items
    {
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        [Display(Name ="Name")]
        public string ItemName { get; set;}
        [Display(Name ="Description")]
        public string ItemDescription { get; set; }

        [Display(Name ="Price")]
        public decimal ItemPrice { get; set; }

        public string ItemBrand {  get; set; }

        public int ItemCategory {  get; set; }
        [Display(Name ="Image")]
        public string ItemImage { get; set; }
    }
}
