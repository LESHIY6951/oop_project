using System.ComponentModel.DataAnnotations;

namespace shop25.Data.Model
{
    public class order_history2
    {
        public int item_id { get; set; }
        public string item_name { get; set; }
        public string item_description { get; set; }
        public int item_cost { get; set; }
        public string item_img { get; set; }
        public int col { get; set; }
        public DateTime date { set; get; }
    }
}
