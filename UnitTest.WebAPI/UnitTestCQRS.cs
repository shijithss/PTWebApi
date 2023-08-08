using AutoMapper;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.WebAPI.Mock;
using User.Microservice.Application.Features.User.Commands;
using User.Microservice.Application.Features.User.Events;
using User.Microservice.Infrastructure.Mapper;
using User.Microservice.Infrastructure.Repositories;

namespace UnitTest.WebAPI
{
        public class UnitTestCQRS
        {
            private readonly Mock<IMediator> mediatorMoq;
            public UnitTestCQRS()
            {
                mediatorMoq = new Mock<IMediator>();
            }
            [Fact]
            public void CreateProductCommand_Once()
            {
                MockTodoListDbContext mockTodoListDbContext = new MockTodoListDbContext();
                DummyJsonRepository mockJsonRepository = new DummyJsonRepository();
                var userProfile = new UserProfile();
                var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userProfile));
                var mapper = new Mapper(configuration);

                var handler = new CreateUserCommandHandler(mockTodoListDbContext.InMemoryDBContext, mediatorMoq.Object, mockJsonRepository, mapper);

                var result = handler.Handle(new User.Microservice.Application.Features.User.Commands.CreateUserCommand(), CancellationToken.None);

                mediatorMoq.Verify(x => x.Publish(It.IsAny<UserCreatedEvent>(), It.IsAny<CancellationToken>()));
            }
        }
    }
