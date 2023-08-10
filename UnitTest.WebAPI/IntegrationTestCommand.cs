using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.WebAPI.Mock;
using User.Microservice.Application.Features.User.Commands;
using User.Microservice.Application.Features.User.Events;
using User.Microservice.Infrastructure.Data;
using User.Microservice.Infrastructure.Mapper;
using User.Microservice.Infrastructure.Repositories;

namespace UnitTest.WebAPI
{
    public class IntegrationTestCommand
    {
        private readonly Mock<IMediator> mediatorMoq;
        public IntegrationTestCommand()
        {
            mediatorMoq = new Mock<IMediator>();
        }
        [Fact]
        public void CreateProductCommand_Test()
        {
            //Assign
            MockApplicationtDbContext mockTodoListDbContext = new MockApplicationtDbContext();
            DummyJsonRepository mockJsonRepository = new DummyJsonRepository();
            var userProfile = new UserProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userProfile));
            var mapper = new Mapper(configuration);
            var handler = new CreateUserCommandHandler(mockTodoListDbContext.InMemoryDBContext, mediatorMoq.Object, mockJsonRepository, mapper);

            //Act
            var result = handler.Handle(new User.Microservice.Application.Features.User.Commands.CreateUserCommand(), CancellationToken.None);

            //Assert
            mediatorMoq.Verify(x => x.Publish(It.IsAny<UserCreatedEvent>(), It.IsAny<CancellationToken>()));

        }
    }
}
