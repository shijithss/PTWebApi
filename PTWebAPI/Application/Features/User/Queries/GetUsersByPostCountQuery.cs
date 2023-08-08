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
    /// GetUsersByPostCountQuery object
    /// </summary>
    public class GetUsersByPostCountQuery : IRequest<IEnumerable<Models.UserTodosViewModel>>
    {
        public int PostCount { get; set; }
    }
}
