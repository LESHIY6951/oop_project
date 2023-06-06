namespace shop25.Data.Model
{
    public class forum
    {
        public int forum_id { get; private set; }
        public int cert_id { set;  get; }
        public string name {  set; get; }
        public int score { set; get; }
        public string text { set; get; }
        public int likes {  set; get; }
        public int dislikes { set; get; }
    }
}
