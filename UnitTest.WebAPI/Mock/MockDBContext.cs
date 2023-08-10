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
    public class MockApplicationtDbContext : IDisposable
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

        public class TestReadDbContext : ApplicationQueryDBContext
        {

            public TestReadDbContext(DbContextOptions<ApplicationQueryDBContext> options) : base(options)
            {
            }

            public ModelBuilder ModelBuilder { get; private set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<User.Microservice.Domain.Entities.PostQuery>().Ignore(x => x.tags);
                this.ModelBuilder = modelBuilder;
            }
        }

        public TestDbContext InMemoryDBContext { get; private set; }

        public TestReadDbContext InMemoryReadDBContext { get; private set; }

         public MockApplicationtDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationCommandDBContext>()
                .UseInMemoryDatabase("InMemoryDBContext")
                .Options;

            InMemoryDBContext = new TestDbContext(options);

            var optionsRead = new DbContextOptionsBuilder<ApplicationQueryDBContext>()
               .UseInMemoryDatabase("InMemoryDBContext")
               .Options;

            InMemoryReadDBContext = new TestReadDbContext(optionsRead);

        }

        public void Dispose()
        {
            InMemoryDBContext.Dispose();
            InMemoryReadDBContext.Dispose();
        }

    }
}
