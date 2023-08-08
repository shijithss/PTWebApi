using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Domain.Entities
{
    public class TodoQuery : BaseEntity
    {
        [Key]
        public int id { get; private set; }
        public string todo { get; private set; }
        public bool completed { get; private set; }
        public int userId { get; private set; }
    }
}
