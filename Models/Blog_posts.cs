using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Blog_posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [ForeignKey("Id")]
        public int User_id { get; set; }
        public Blog_posts()
        {
            
        }
    }
}
