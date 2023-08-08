using System.Collections.ObjectModel;
using User.Microservice.Domain.Entities;

namespace User.Microservice.Application.Models
{
    public class UserPostsViewModel
    {
        public int id { get;  set; }
        public string username { get;  set; }


        public IList<PostQuery> Posts { get; set; } = new List<PostQuery>();

    }
}
