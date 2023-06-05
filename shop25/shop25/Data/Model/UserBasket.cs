namespace shop25.Data.Model
{
    public class UserBasket
    {
        public int Id { get; set; }
        public string TovapName { get; set; }
        public int TovapPrice { get; set; }
        public int UserId { get; set; }
        public string TovapImageURL { get; set; }
    }
}
