using Microsoft.EntityFrameworkCore;
using System.Net;
using Entities = User.Microservice.Domain.Entities ;
namespace User.Microservice.Infrastructure.Data
{
    public class ApplicationCommandDBContext : DbContext, IApplicationCommandDBContext
    {

        public ApplicationCommandDBContext(DbContextOptions<ApplicationCommandDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.User>().HasOne(x => x.address);
            modelBuilder.Entity<Entities.User>().OwnsOne(x => x.bank);

            modelBuilder.Entity<Entities.User>().OwnsOne(x => x.company, c => {
                c.HasOne(x => x.address);
            });
            modelBuilder.Entity<Entities.User>().OwnsOne(x => x.hair);

            modelBuilder.Entity<Entities.Address>().OwnsOne(x => x.coordinates);

        }

        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Todo> Todos { get; set; }
        public DbSet<Entities.Post> Posts { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
