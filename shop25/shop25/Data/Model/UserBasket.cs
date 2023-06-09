using System.ComponentModel.DataAnnotations;

namespace shop25.Data.Model
{
    public class cart
    {
        public int user_id { get; set; }
        [Key]
        public int item_id { get; set; }
        public int total_cost { get; set; }
    }
}
