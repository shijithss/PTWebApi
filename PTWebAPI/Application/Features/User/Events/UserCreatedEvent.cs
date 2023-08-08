using MediatR;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Infrastructure.Data;
using Entities = User.Microservice.Domain.Entities;
using User.Microservice.Domain.Entities;
using User.Microservice.Application.Models;
using AutoMapper;

namespace User.Microservice.Application.Features.User.Events
{
    public class UserCreatedEvent : INotification
    {

        public List<Entities.User> Users { get; set; } = new();
    }

    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        IApplicationQueryDBContext _dbQueryContext;
        IMapper _mapper;

        public UserCreatedEventHandler(IApplicationQueryDBContext appReadDbContext, IMapper mapper)
        {
            _dbQueryContext = appReadDbContext;
            _mapper = mapper;

        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Create a new Product Read Model for the Query side
            IList<UserQuery> UserQueries = new List<UserQuery>();
            foreach (var userWrite in notification.Users)
            {
                var userQuery = _mapper.Map<Entities.User, Entities.UserQuery>(userWrite);
                userQuery.AddTodo(userWrite.Todos.ToList());
                var postQuery = _mapper.Map<List<Entities.Post>, List<Entities.PostQuery>>(userWrite.Posts.ToList());
                userQuery.AddPostQuery(postQuery);
                UserQueries.Add(userQuery);
            }
            _dbQueryContext.Users.AddRange(UserQueries);
            await _dbQueryContext.SaveChanges();

            
        }
    }
}
