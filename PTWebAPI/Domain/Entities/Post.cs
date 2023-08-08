using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Domain.Entities
{
    public class Post : BaseEntity
    {
        [Key]
        public int postid { get; private set; }
        public string title { get; private set; }
        public string body { get; private set; }
        public int userId { get; private set; }

        public List<string> tags { get; private set; }
        public int reactions { get; private set; }
    }
}
