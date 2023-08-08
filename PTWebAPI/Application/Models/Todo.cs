using System.Collections.Generic;

namespace User.Microservice.Application.Models
{
    public class Todo
    {
        public int id { get; set; }
        public string todo { get; set; }
        public bool completed { get; set; }
        public int userId { get; set; }
    }

    public class RootTodo
    {
        public List<Todo> todos { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }


}
