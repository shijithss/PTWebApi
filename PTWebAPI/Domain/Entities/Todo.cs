using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Domain.Entities
{
    public class Todo : BaseEntity
    {
        [Key]
        public int todoid { get; private set; }
        public string todo { get; private set; }
        public bool completed { get; private set; }
        public int userId { get; private set; }
    }
}
