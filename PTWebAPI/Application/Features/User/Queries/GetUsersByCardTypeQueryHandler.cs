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
    /// GetUsersByCardTypeQueryHandler Logic
    /// </summary>
    public class GetUsersByCardTypeQueryHandler : IRequestHandler<GetUsersByCardTypeQuery, IEnumerable<Models.UserPostsViewModel>>
    {
        private readonly IApplicationQueryDBContext _context;
        IMapper _mapper;
        public GetUsersByCardTypeQueryHandler(IApplicationQueryDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Models.UserPostsViewModel>> Handle(GetUsersByCardTypeQuery query, CancellationToken cancellationToken)
        {
            var userList = await _context.Users.ToListAsync();

            //Filter based on the card type and populate the view model

            var result = _context.Users.Where(p => p.bank.cardType.Contains(query.CardType)).SelectMany(p => p.Posts, (p, c) => new UserPostsViewModel { id = p.userid, username = p.username, Posts = p.Posts.ToList() });

            if (result == null)
            {
                return null;
            }
            return await result.ToListAsync();

        }
    }
}
