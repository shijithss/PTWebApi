using Microsoft.EntityFrameworkCore;
using System.Net;
using Entities = User.Microservice.Domain.Entities;

namespace User.Microservice.Infrastructure.Data
{
    public class ApplicationQueryDBContext : DbContext, IApplicationQueryDBContext
    {

        public ApplicationQueryDBContext(DbContextOptions<ApplicationQueryDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.UserQuery>().HasOne(x => x.address);
            modelBuilder.Entity<Entities.UserQuery>().OwnsOne(x => x.bank);

            modelBuilder.Entity<Entities.UserQuery>().OwnsOne(x => x.company, c => {
                c.HasOne(x => x.address);
            });
            modelBuilder.Entity<Entities.UserQuery>().OwnsOne(x => x.hair);

            modelBuilder.Entity<Entities.AddressQuery>().OwnsOne(x => x.coordinates);

        }

        public DbSet<Entities.UserQuery> Users { get; set; }
        public DbSet<Entities.TodoQuery> Todos { get; set; }
        public DbSet<Entities.PostQuery> Posts { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
