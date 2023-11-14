using System.ComponentModel.DataAnnotations;

namespace shop25.Data.Model
{
    public class Products
    {
        [Key]
        public int item_id { get; set; }
        public string item_name { get; set; }
        public string item_description { get; set; }
        public int item_cost { get; set; }
        public string item_img { get; set; }
    }
}
