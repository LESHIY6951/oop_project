using System.ComponentModel.DataAnnotations;

namespace shop25.Data.Model
{
    public class history
    {
        public int user_id { set; get; }
        public int item_id { set; get; }
        public int total_cost { set; get; }
        [Key]
        public DateTime date { set; get; }
    }
}
