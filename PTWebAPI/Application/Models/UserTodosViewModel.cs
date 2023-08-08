using System.Collections.ObjectModel;
using User.Microservice.Domain.Entities;

namespace User.Microservice.Application.Models
{
    public class UserTodosViewModel
    {
        public int id { get; set; }
        public string username { get; set; }

        public IList<Todo> Todos { get; set; } = new List<Todo>();
    }
}
