using Microsoft.EntityFrameworkCore;
using Entities = User.Microservice.Domain.Entities;

namespace User.Microservice.Infrastructure.Data
{
    public interface IApplicationQueryDBContext
    {
        DbSet<Entities.UserQuery> Users { get; set; }
        public DbSet<Entities.TodoQuery> Todos { get; set; }
        public DbSet<Entities.PostQuery> Posts { get; set; }
        Task<int> SaveChanges();
    }
}
