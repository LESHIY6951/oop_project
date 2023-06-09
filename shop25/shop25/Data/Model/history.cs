using System.ComponentModel.DataAnnotations;

namespace shop25.Data.Model
{
    public class history
    {
        [Key]
        public int user_id { set; get; }
        public int item_id { set; get; }
        public int total_cost { set; get; }
        public DateTime date { set; get; }
    }
}
