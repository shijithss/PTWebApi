using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Application.Features.User.Events;
using User.Microservice.Infrastructure.Data;
using User.Microservice.Infrastructure.Repositories;
using Entities = User.Microservice.Domain.Entities;

namespace User.Microservice.Application.Features.User.Commands
{
    /// <summary>
    /// CreateUserCommandHandler logic to create all the tables for User, Todo and Post
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationCommandDBContext _context;
        IMediator _mediator;
        IMapper _mapper;
        IDummyJsonRepository _dummyJsonRepository;
        public CreateUserCommandHandler(IApplicationCommandDBContext context, IMediator mediator, IDummyJsonRepository dummyJsonRepository, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _dummyJsonRepository = dummyJsonRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            //Get all the json list from the json repository
            var posts = _dummyJsonRepository.GetAllPosts().Result;
            var users = _dummyJsonRepository.GetAllUsers().Result;
            var todos = _dummyJsonRepository.GetAllTodos().Result;

            //map from model to entities
            var usersList = _mapper.Map<List<Models.User>, List<Entities.User>>(users);
            var todoList = _mapper.Map<List<Models.Todo>, List<Entities.Todo>>(todos);
            var postsList = _mapper.Map<List<Models.Post>, List<Entities.Post>>(posts);
            foreach (var useritem in usersList)
            {
                //Add todo and posts
                useritem.AddTodo(todoList.Where(x => x.userId.Equals(useritem.userId)).ToList());
                useritem.AddPost(postsList.Where(x => x.userId.Equals(useritem.userId)).ToList());
                _context.Users.Add(useritem);



            }
            //Save the user aggregate to Database
            await _context.SaveChanges();


            var dataModel = _context.Users.Include(x => x.Todos).Include(x => x.Posts).ToList();

            var productCreatedEvent = new UserCreatedEvent
            {

                Users = dataModel
            };

            //Raise the Event to publish the command data to the Read/Query Database
            await _mediator.Publish(productCreatedEvent, cancellationToken);

            return dataModel.Count;
        }
    }
}
