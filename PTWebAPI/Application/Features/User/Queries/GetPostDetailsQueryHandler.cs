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

namespace User.Microservice.Application.Features.User.Queries
{
    /// <summary>
    /// GetPostDetailsQueryHandler logic
    /// </summary>
    public class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery, IEnumerable<Models.PostViewModel>>
    {
        private readonly IApplicationQueryDBContext _context;
        IMapper _mapper;
        public GetPostDetailsQueryHandler(IApplicationQueryDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Models.PostViewModel>> Handle(GetPostDetailsQuery query, CancellationToken cancellationToken)
        {
            var userList = await _context.Users.ToListAsync();

            var result = _context.Users.SelectMany(p => p.Posts, (p, c) => new PostViewModel { PostId = c.postid, UserName = p.username, hasFictionTag = c.hasFictionTag, hasFrenchTag = c.hasFrenchTag, hasMorethanTwoReactions = c.hasMorethanTwoReactions });


            if (result == null)
            {
                return null;
            }
            return result.ToList();

        }
    }
}
