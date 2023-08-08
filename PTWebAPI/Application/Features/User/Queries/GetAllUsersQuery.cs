using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Infrastructure.Data;
using Entities = User.Microservice.Domain.Entities;

namespace User.Microservice.Application.Features.User.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<Entities.UserQuery>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<Entities.UserQuery>>
        {
            private readonly IApplicationQueryDBContext _context;
            public GetAllUsersQueryHandler(IApplicationQueryDBContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Entities.UserQuery>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                var userList =  await _context.Users.ToListAsync();
                if (userList == null)
                {
                    return null;
                }
                return userList.AsReadOnly();
            }
        }
    }
}
