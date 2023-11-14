using System.ComponentModel.DataAnnotations;

namespace shop25.Data.Model
{
    public class cart
    {
        public int item_id { get; set; }
        public int user_id { get; set; }
        public int col { get; set; }
        [Key] 
        public int cart_id {  get; private set; }
    }
}
