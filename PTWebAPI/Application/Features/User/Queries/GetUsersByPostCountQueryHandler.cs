using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Infrastructure.Data;
using Entities = User.Microservice.Domain.Entities;
using AutoMapper;
using User.Microservice.Application.Models;
using User.Microservice.Domain.Entities;

namespace User.Microservice.Application.Features.User.Queries
{
    /// <summary>
    /// GetUsersByPostCountQueryHandler to get GetUsers By PostCount
    /// </summary>
    public class GetUsersByPostCountQueryHandler : IRequestHandler<GetUsersByPostCountQuery, IEnumerable<Models.UserTodosViewModel>>
    {
        private readonly IApplicationQueryDBContext _context;
        IMapper _mapper;
        public GetUsersByPostCountQueryHandler(IApplicationQueryDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Models.UserTodosViewModel>> Handle(GetUsersByPostCountQuery query, CancellationToken cancellationToken)
        {
            var userList = await _context.Users.ToListAsync();
            //Get the users Viewmodel based on the post count filter condition
            var result = _context.Users.Where(p => p.Posts.Count() > query.PostCount).SelectMany(p => p.Posts, (p, c) => new UserTodosViewModel { id = p.userid, username = p.username, Todos = _mapper.Map<List<Entities.Todo>, List<Models.Todo>>(p.Todos.ToList()) });

            if (result == null)
            {
                return null;
            }
            return await result.ToListAsync();

        }
    }
}
