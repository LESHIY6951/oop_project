using System.ComponentModel.DataAnnotations;

namespace shop25.Data.Model
{
    public class ORDER
    {
        public int user_id { set; get; }
        public int item_id { set; get; }
        public int total_cost { set; get; }
        public string card_num { set; get; }
        public string CVV { set; get; }
        public string card_name { set; get; }
        public DateTime data { set; get; }
        [Key]
        public int order_id {private set; get; }   

    }
}
