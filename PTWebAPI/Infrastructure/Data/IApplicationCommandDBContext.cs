using Microsoft.EntityFrameworkCore;
using Entities = User.Microservice.Domain.Entities;

namespace User.Microservice.Infrastructure.Data
{
    public interface IApplicationCommandDBContext
    {
        DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Todo> Todos { get; set; }
        public DbSet<Entities.Post> Posts { get; set; }
        Task<int> SaveChanges();
    }
}
