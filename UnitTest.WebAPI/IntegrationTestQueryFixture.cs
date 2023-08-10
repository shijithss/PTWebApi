using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.WebAPI.Mock;
using User.Microservice.Application.Features.User.Commands;
using User.Microservice.Application.Features.User.Events;
using User.Microservice.Application.Features.User.Queries;
using User.Microservice.Application.Models;
using User.Microservice.Infrastructure.Mapper;
using User.Microservice.Infrastructure.Repositories;
using static UnitTest.WebAPI.Mock.MockApplicationtDbContext;
using Xunit;

namespace UnitTest.WebAPI
{
    public class IntegrationTestQueryFixture : IDisposable
    {
        public readonly Mock<IMediator> mediatorMoq;
        public MockApplicationtDbContext mockApplicationDbContext;
        public Mapper mapper;
        public IntegrationTestQueryFixture()
        {
            mediatorMoq = new Mock<IMediator>();
            mockApplicationDbContext = new MockApplicationtDbContext();
            DummyJsonRepository mockJsonRepository = new DummyJsonRepository();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile()));
             mapper = new Mapper(configuration);
            var readhandler = new UserCreatedEventHandler(mockApplicationDbContext.InMemoryReadDBContext, mapper);


            var handler = new CreateUserCommandHandler(mockApplicationDbContext.InMemoryDBContext, mediatorMoq.Object, mockJsonRepository, mapper);

            var result = handler.Handle(new User.Microservice.Application.Features.User.Commands.CreateUserCommand(), CancellationToken.None);

            var dataModel = mockApplicationDbContext.InMemoryDBContext.Users.Include(x => x.Todos).Include(x => x.Posts).ToList();

            var productCreatedEvent = new UserCreatedEvent
            {

                Users = dataModel
            };
            //Populates the in memory ReadDBContext
            readhandler.Handle(productCreatedEvent, CancellationToken.None);
           

        }

        public void Dispose()
        {
            //clean up test data from the database
            mockApplicationDbContext.Dispose();
        }

    }

    public class UnitTestReadQueries : IClassFixture<IntegrationTestQueryFixture>
    {
        IntegrationTestQueryFixture fixture;

        public UnitTestReadQueries(IntegrationTestQueryFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async void GetAllUsersQuery_Test()
        {
            //Assign
             MockApplicationtDbContext _dbcontext = fixture.mockApplicationDbContext;
            var _mapper = fixture.mapper;

            ////Act
            var handler = new GetAllUsersQueryHandler(_dbcontext.InMemoryReadDBContext, _mapper);
            var result = await handler.Handle(new GetAllUsersQuery(), CancellationToken.None);

            ////Assert
        
            Assert.IsType<ReadOnlyCollection<UserViewModel>>(result);
            Assert.True(result.ToList().Count > 0, "Expected actualCount to be greater than 0.");


        }

        [Fact]
        public async void GetPostDetailsQuery_Test()
        {
            //Assign
            MockApplicationtDbContext _dbcontext = fixture.mockApplicationDbContext;
            var _mapper = fixture.mapper;

            ////Act
            var handler = new GetPostDetailsQueryHandler(_dbcontext.InMemoryReadDBContext, _mapper);
            var result = await handler.Handle(new GetPostDetailsQuery(), CancellationToken.None);

            ////Assert

            Assert.IsType<List<PostViewModel>>(result);
            Assert.True(result.ToList().Count > 0, "Expected actualCount to be greater than 0.");

        }

        [Theory]
        [InlineData("mastercard")]
        public async void GetUsersByCardTypeQuery_Test(string cardType)
        {
            //Assign
            MockApplicationtDbContext _dbcontext = fixture.mockApplicationDbContext;
            var _mapper = fixture.mapper;

            ////Act
            var handler = new GetUsersByCardTypeQueryHandler(_dbcontext.InMemoryReadDBContext, _mapper);
            var result = await handler.Handle(new GetUsersByCardTypeQuery() { CardType=cardType}, CancellationToken.None);

            ////Assert
            Assert.IsType<List<UserPostsViewModel>>(result);
            Assert.True(result.ToList().Count > 0, "Expected actualCount to be greater than 0.");

        }
        [Theory]
        [InlineData(0)] // Number of posts greater than 0

        public async void GetUsersByPostCount_Test(int postCount)
        {
            //Assign
            MockApplicationtDbContext _dbcontext = fixture.mockApplicationDbContext;
            var _mapper = fixture.mapper;

            ////Act
            var handler = new GetUsersByPostCountQueryHandler(_dbcontext.InMemoryReadDBContext, _mapper);
            var result = await handler.Handle(new GetUsersByPostCountQuery() { PostCount = postCount }, CancellationToken.None);

            ////Assert
            Assert.IsType<List<UserTodosViewModel>>(result);
            Assert.True(result.ToList().Count > 0, "Expected actualCount to be greater than 0.");

        }
    }
}
