using System.Collections.Generic;

namespace User.Microservice.Application.Models
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
        public List<string> tags { get; set; }
        public int reactions { get; set; }
    }

    public class RootPost
    {
        public List<Post> posts { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }



}
