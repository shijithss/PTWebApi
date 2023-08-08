namespace User.Microservice.Application.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string UserName { get; set; }
        public bool hasFrenchTag { get; set; }
        public bool hasFictionTag { get; set; }
        public bool hasMorethanTwoReactions { get; set; }
    }

}
