using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Infrastructure.Data;
using Entities = User.Microservice.Domain.Entities;
using AutoMapper;

namespace User.Microservice.Application.Features.User.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<Models.UserViewModel>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<Models.UserViewModel>>
        {
            private readonly IApplicationQueryDBContext _context;
            IMapper _mapper;
            public GetAllUsersQueryHandler(IApplicationQueryDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IEnumerable<Models.UserViewModel>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                var userList =  await _context.Users.ToListAsync();
                try
                {

               
                var usersModel = _mapper.Map<List<Entities.UserQuery>, List<Models.UserViewModel>>(userList);
               
                if (usersModel == null)
                {
                    return null;
                }
                return usersModel.AsReadOnly();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
