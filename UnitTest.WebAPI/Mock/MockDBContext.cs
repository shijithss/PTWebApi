using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using User.Microservice.Infrastructure.Data;

namespace UnitTest.WebAPI.Mock
{
    public class MockTodoListDbContext : IDisposable
    {
        public class TestDbContext : ApplicationCommandDBContext
        {

            public TestDbContext(DbContextOptions<ApplicationCommandDBContext> options) : base(options)
            {
            }

            public ModelBuilder ModelBuilder { get; private set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<User.Microservice.Domain.Entities.Post>().Ignore(x => x.tags);
                this.ModelBuilder = modelBuilder;
            }
        }

        public TestDbContext InMemoryDBContext { get; private set; }

        public MockTodoListDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationCommandDBContext>()
                .UseInMemoryDatabase("InMemoryDBContext")
                .Options;

            InMemoryDBContext = new TestDbContext(options);

            //InMemoryDBContext.Users.Add(new User());

            // InMemoryDBContext.SaveChanges();
        }

        public void Dispose()
        {
            InMemoryDBContext.Dispose();
        }

    }
}
