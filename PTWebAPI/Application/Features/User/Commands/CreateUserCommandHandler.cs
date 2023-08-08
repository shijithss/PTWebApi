using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Application.Features.User.Events;
using User.Microservice.Infrastructure.Data;
using User.Microservice.Infrastructure.Repositories;
using Entities = User.Microservice.Domain.Entities;

namespace User.Microservice.Application.Features.User.Commands
{
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
            var posts = _dummyJsonRepository.GetAllPosts().Result;
            var users = _dummyJsonRepository.GetAllUsers().Result;
            var todos = _dummyJsonRepository.GetAllTodos().Result;


            var usersList = _mapper.Map<List<Models.User>, List<Entities.User>>(users);
            var todoList = _mapper.Map<List<Models.Todo>, List<Entities.Todo>>(todos);
            var postsList = _mapper.Map<List<Models.Post>, List<Entities.Post>>(posts);
            foreach (var useritem in usersList)
            {

                useritem.AddTodo(todoList.Where(x => x.userId.Equals(useritem.id)).ToList());
                useritem.AddPost(postsList.Where(x => x.userId.Equals(useritem.id)).ToList());
                try
                {
                    _context.Users.Add(useritem);
                }
                catch (Exception ex)
                {

                    var t = ex.Message;
                }

            }


            await _context.SaveChanges();
            var dataModel = _context.Users.Include(x => x.Todos).Include(x => x.Posts).ToList();
            // Reload the product to get the Id
            // await _context.Entry(product).ReloadAsync(cancellationToken);

            var productCreatedEvent = new UserCreatedEvent
            {

                Users = dataModel
            };

            await _mediator.Publish(productCreatedEvent, cancellationToken);

            return dataModel.Count;
        }
    }
}
