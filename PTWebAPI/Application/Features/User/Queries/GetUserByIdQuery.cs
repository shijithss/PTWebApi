using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Entities = User.Microservice.Domain.Entities;
using User.Microservice.Infrastructure.Data;

namespace User.Microservice.Application.Features.User.Queries
{
    /// <summary>
    /// Depreciated. Not in scope for the task
    /// </summary>
    public class GetUserByIdQuery : IRequest<Entities.UserQuery>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Entities.UserQuery>
        {
            private readonly IApplicationQueryDBContext _context;
            public GetProductByIdQueryHandler(IApplicationQueryDBContext context)
            {
                _context = context;
            }
            public async Task<Entities.UserQuery> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var user = _context.Users.Where(a => a.userid == query.Id).FirstOrDefault();
                if (user == null) return null;
                return user;
            }
        }
    }
}
