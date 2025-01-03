namespace Blog.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int User_id { get; set; }
        public int Blogpost_id { get; set; }
        public Comments()
        {
            
        }
    }
}
