using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace DiscGolfWeb.Model
{
    public class Items
    {
        public int ItemID { get; set; }
        [Display(Name ="Item Code")]
        public string ItemCode { get; set; }
        [Display(Name ="Name")]
        public string ItemName { get; set;}
        [Display(Name ="Description")]
        public string ItemDescription { get; set; }

        [Display(Name ="Price")]
        public decimal ItemPrice { get; set; }
        [Display(Name ="Brand")]
        public string ItemBrand {  get; set; }
        [Display(Name ="Category")]
        public int ItemCategory {  get; set; }

        public string itemCategory {  get; set; }
        [Display(Name ="Image")]
        public string ItemImage { get; set; }
    }
}
