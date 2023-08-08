using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using User.Microservice.Infrastructure.Data;
using User.Microservice.Infrastructure.Repositories;

using User.Microservice.Application.Features.User.Events;

namespace User.Microservice.Application.Features.User.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        
    }
}
