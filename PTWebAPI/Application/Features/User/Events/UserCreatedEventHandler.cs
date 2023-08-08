using AutoMapper;
using MediatR;
using Entities = User.Microservice.Domain.Entities;
using User.Microservice.Infrastructure.Data;


namespace User.Microservice.Application.Features.User.Events
{/// <summary>
/// UserCreatedEventHandler logic
/// </summary>
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        IApplicationQueryDBContext _dbQueryContext;
        IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appReadDbContext"></param>
        /// <param name="mapper"></param>
        public UserCreatedEventHandler(IApplicationQueryDBContext appReadDbContext, IMapper mapper)
        {
            _dbQueryContext = appReadDbContext;
            _mapper = mapper;

        }
        /// <summary>
        /// Event driven to insert records from command DB to Query DB
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Create a new Product Read Model for the Query side
            IList<Entities.UserQuery> UserQueries = new List<Entities.UserQuery>();
            foreach (var userWrite in notification.Users)
            {
                //Map command entitity to query entity
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
